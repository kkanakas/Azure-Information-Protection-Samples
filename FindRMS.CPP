// FindRMS.cpp
//
#include "stdafx.h"
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <Windows.h>
#include <ole2.h>
#include "D:\Programming\Visual Studio 2010\zlib\include\zlib.h"
#include "D:\Programming\Visual Studio 2010\zlib\include\zconf.h"

//the global variables for the passed-in parameters
PSTR	g_File = NULL;

#define ZLIB_BUFFER_SIZE  (4 * 1024)
#define ZLIB_DRM_HEADER_MAGIC (0x0FA0)

typedef struct
{
	ULONG ulCheck;
	ULONG cbUncompressed;
	ULONG cbCompressed;
} ZLIBDRMHEADER;

bool ParseCommandLine(int Argc, char** Argv)
{
    while (--Argc > 0)
    {
        Argv++;

        if(!strcmp(*Argv, "-f"))
        {
            if (Argc < 2)
                printf("Error: -f missing file name\n");

            Argv++;
            Argc--;

            g_File = *Argv;
        }
        else 
        {
            printf("Error: Unknown command line argument '%s'\n", *Argv);
        }
    }

    if (g_File == NULL)
		//No param has been set
		return false;
    else
		return true;
}

bool CheckReturnCode(HRESULT hRes, char* str1, char* str2)
{
	if (FAILED(hRes))
	{
		printf("%s", str2);
		return true;
	}
	else
	{
		printf("%s", str1);
		return false;
	}
}

HRESULT RewindStream(LPSTREAM pstm)
{
    HRESULT        hRes = S_OK;
    LARGE_INTEGER  liOrigin = {0,0};

    // Seek to 0
    hRes = pstm->Seek(liOrigin, STREAM_SEEK_SET, NULL);
    return hRes;
}

void CheckRMSAttachment(LPTSTR szTempInFileName)
{
	HRESULT		hRes = NULL;
	ULONG		cbRead = {0};
	HANDLE		ProcHeap = NULL;
	CHAR		szAppPath[MAX_PATH];
	CHAR		szTempOutFileName[MAX_PATH];
	FILE*		StreamIn = NULL;
	FILE*		StreamOut = NULL;

	ProcHeap = GetProcessHeap();
	if(ProcHeap == NULL)
		return;
		
	//Get the application directory
	GetCurrentDirectoryA(MAX_PATH, szAppPath);
	strcat(szAppPath, "\\");
	
	//Open the temporary file to start the decompress
	StreamIn = fopen((char*) szTempInFileName, "rb");

	if (StreamIn != NULL)
	{
		//bingo, got it - do all the decompress stuff right now
		static const char c_szCompressedDrmMessageHeader[] = "\x76\xE8\x04\x60\xC4\x11\xE3\x86";
		CHAR szHeader[sizeof(c_szCompressedDrmMessageHeader)] = {0};
		byte rgbOriginal[ZLIB_BUFFER_SIZE];
		byte rgbCompressed[ZLIB_BUFFER_SIZE*2];

		//Read the header
		if (fread(szHeader, 1, sizeof(szHeader)-1, StreamIn) == 0)
		{
			printf("Failed to get RMS header\n");
			fclose(StreamIn);
			return;
		}

		if (strcmp(szHeader, c_szCompressedDrmMessageHeader) != 0)
		{
			printf("Not a RMS header");
			fclose(StreamIn);
			return;
		}

		//Now do the decompress stuff, create the output-file first
		GetTempFileNameA(szAppPath, "XrML", 0, szTempOutFileName);
		StreamOut = fopen(szTempOutFileName, "wb");
		if (StreamOut == NULL)
		{
			printf("Failed to open temporay file for writing!\n");
			return;
		}

		DWORD dwGetTick = GetTickCount();

		//Inít the zlib stuff
		z_stream zcpr;
		ZLIBDRMHEADER theHeader = {0};
		int ret = Z_OK;
		long lOrigDone = 0;
		int step = 0;
					
		memset(&zcpr, 0, sizeof(z_stream));
		inflateInit(&zcpr);

		//Run the decompress
		while (true)
		{
			ZeroMemory(rgbOriginal, sizeof(rgbOriginal));
			if (fread(&theHeader, sizeof(theHeader), 1, StreamIn) == 0)
			{
				//printf("read failed");
				break;
			}

			if (theHeader.ulCheck != ZLIB_DRM_HEADER_MAGIC)
			{
				//printf("Header Check failed!");
				break;
			}

			if (fread(rgbCompressed, theHeader.cbCompressed, 1, StreamIn) == 0)
			{
				//printf("read failed");
				break;
			}

			zcpr.next_in = rgbCompressed;
			zcpr.next_out = rgbOriginal;
			zcpr.avail_in = theHeader.cbCompressed;
			zcpr.avail_out = sizeof(rgbOriginal);

			printf("cbUncompressed: %d cbCompressed: %d\n", theHeader.cbUncompressed, theHeader.cbCompressed);

			do
			{
				ret = inflate(&zcpr, Z_SYNC_FLUSH);
				printf("Inflate return code: %d\n", ret);
				step++;
			} while (ret == Z_OK);

			fwrite(rgbOriginal, 1, theHeader.cbUncompressed, StreamOut);
		}

		//all decompress stuff is done
		inflateEnd(&zcpr);
		dwGetTick = GetTickCount() - dwGetTick;
		printf("\nDecompress took %d msec\nRequired loops: %d\n\n", dwGetTick, step);
		fclose(StreamIn);
		fclose(StreamOut);
		
		
		//Now open the storage container and read the XrML header
		//Declaration stuff copied from http://msdn.microsoft.com/en-us/windows/cc530381(v=vs.71).aspx
		short char_six=6;
		short char_nine=9;
		WCHAR StorageName_DataSpaces[12]    =    L"*DataSpaces";
		WCHAR StorageName_TransformInfo[14] =    L"TransformInfo";
		WCHAR StorageName_DRMTransform[14]  =    L"*DRMTransform";
		WCHAR StreamName_Primary[9]         =    L"*Primary";
								
		//convert the ansi file name into wide char
		TCHAR 	StrFileOutput[MAX_PATH];
		mbstowcs(&StrFileOutput[0], szTempOutFileName, MAX_PATH);

		IStorage *pStorage = NULL;
		IStorage *pSub1Storage = NULL;
		IStorage *pSub2Storage = NULL;
		IStorage *pSub3Storage = NULL;
		IStream  *pSub4Stream = NULL;

		hRes = StgOpenStorageEx(StrFileOutput, STGM_READ | STGM_SHARE_EXCLUSIVE,  STGFMT_STORAGE, 0, NULL, 0, IID_IStorage, (void **)&pStorage);
		if(S_OK == hRes)
		{
			memcpy(StorageName_DataSpaces, &char_six, 2);
			hRes = pStorage->OpenStorage(StorageName_DataSpaces, NULL, STGM_READ | STGM_SHARE_EXCLUSIVE, NULL, 0, &pSub1Storage);
			if(S_OK == hRes)
			{
				hRes = pSub1Storage->OpenStorage(StorageName_TransformInfo, NULL, STGM_READ | STGM_SHARE_EXCLUSIVE, NULL, 0, &pSub2Storage);
				if(S_OK == hRes)
				{
					memcpy(StorageName_DRMTransform, &char_nine,2);
					hRes = pSub2Storage->OpenStorage(StorageName_DRMTransform, NULL, STGM_READ | STGM_SHARE_EXCLUSIVE, NULL, 0, &pSub3Storage);
					if(S_OK == hRes)
					{
						//Got it, now read the stream
						memcpy(StreamName_Primary, &char_six, 2);
						hRes = pSub3Storage->OpenStream(StreamName_Primary, NULL, STGM_READ | STGM_SHARE_EXCLUSIVE, 0, &pSub4Stream);
						if(S_OK == hRes)
						{
							//Got it
							STATSTG		StatInfoRMS;
							hRes = pSub4Stream->Stat(&StatInfoRMS, STATFLAG_NONAME);
							if((hRes == S_OK) && (StatInfoRMS.cbSize.LowPart > 0))
							{
								//Create a buffer to hold the XrML header
								LPBYTE		pBuffer = NULL;
								LPBYTE		pBufferToFree = NULL;
								//Use the new heap functions
								pBuffer = (LPBYTE) HeapAlloc(ProcHeap, HEAP_ZERO_MEMORY, StatInfoRMS.cbSize.LowPart);
										
								//Save the buffer address to free it later
								pBufferToFree = pBuffer;

								if (pBuffer)
								{
									//Copy the stream into the buffer
									hRes = RewindStream(pSub4Stream);
									pSub4Stream->Read((LPVOID) pBuffer, StatInfoRMS.cbSize.LowPart, &cbRead);

									//Dump the buffer
									for(ULONG cnt = 0; cnt<cbRead; cnt++)
									{
										printf("%c", *pBuffer);
										pBuffer++;
									}

									//release the buffer which holds the stream info
									//Use the new heap functions
									HeapFree(ProcHeap, 0, pBufferToFree);
								}
							}
									
							if(pSub4Stream)
								pSub4Stream->Release();
						}
						if(pSub3Storage)
							pSub3Storage->Release();
					}
					if(pSub2Storage)
						pSub2Storage->Release();
				}
				if (pStorage != NULL)
					pStorage->Release();
			}
		}
		else
		{
			printf("StgOpenStorageEx to %s failed with: %0x\n", szTempOutFileName, hRes);
		}

		//Delete the output file
		DeleteFileA(szTempOutFileName);
	}
	else
	{
		printf("Failed to open temporay file for reading!\n");
	}

	return;
}
int main(int argc, char* argv[])
{
	printf("RMS message analyzer (c) Thomno@Microsoft, 2014\n");
	printf("-----------------------------------------------\n");
	printf("FindRMS.exe -f <File name>\n");
	printf("Dump the XrML header for the given file (message.rpmsg)\n");
	printf("-----------------------------------------------\n\n");

	if (ParseCommandLine(argc, argv) != true)
	{
		printf("Error: Parsing command-line parameters has failed\n");
		return 0;
	}

	if(g_File != NULL)
	{
		CheckRMSAttachment((LPTSTR) g_File);
		return 0;
	}
		
	return 0;
}