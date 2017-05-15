using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using Microsoft.InformationProtectionAndControl;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.IO;
using System.Collections.Generic;


namespace AzureIP_Unprotect
{
    class Unprotect
    {
        private static Collection<TemplateInfo> templates = null;
        private static SafeFileApiNativeMethods.DecryptFlags IPCF_DF_FLAG_DEFAULT = 0;
        //Loads credentials for the service principal from App.Config 
        private static SymmetricKeyCredential symmetricKeyCred = new SymmetricKeyCredential();
        
        static void Main()
        {
            


            //Prompt user to choose a directory to decrypt files 
            Console.WriteLine("Enter the directory that you would like to decrypt");
            string dirName = Console.ReadLine();

            if (dirName.Trim() != "")
            {
                if (Directory.Exists(dirName))
                {
                    //Call the Unprotect function
                    Unprotect_Files(dirName);
                }
                else
                {
                    Console.WriteLine("Please enter a valid directory that exists");
                    Environment.Exit(0);
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid directory name");
                Environment.Exit(0);
            }


        }

        public static void Unprotect_Files(string nameDir)
        {
            //Load the MSIPC dll 
            SafeNativeMethods.IpcInitialize();
            SafeNativeMethods.IpcSetAPIMode(APIMode.Server);
            SafeNativeMethods.IpcSetStoreName("Uprot");

            //Loads credentials for the service principal from App.Config 

            symmetricKeyCred.AppPrincipalId = ConfigurationManager.AppSettings["AppPrincipalId"];
            symmetricKeyCred.Base64Key = ConfigurationManager.AppSettings["Base64Key"];
            symmetricKeyCred.BposTenantId = ConfigurationManager.AppSettings["BposTenantId"];

            byte[] fileLicense;
            SafeInformationProtectionKeyHandle keyHandle;
            keyHandle = null;
            var list = new List<KeyValuePair<string, string>>();

            //Getting templates (this function is not needed but just checking it out) 
            /*templates = SafeNativeMethods.IpcGetTemplateList(null, false, true,
               false, true, null, null, symmetricKeyCred); */
            string[] files = Directory.GetFiles(nameDir);
            foreach (string file in files)
            {
                var checkEncryptionStatus = SafeFileApiNativeMethods.IpcfIsFileEncrypted(file);
                if (checkEncryptionStatus.ToString().ToLower().Contains("encrypted"))
                {
                    fileLicense = SafeFileApiNativeMethods.IpcfGetSerializedLicenseFromFile(file);
                    try
                    {
                        keyHandle = SafeNativeMethods.IpcGetKey(fileLicense, false, false, true,null,symmetricKeyCred);

                    } catch
                    {
                    }
                    string rights = getRights(fileLicense, keyHandle);
                    if (rights.ToLower().Contains("without authorization"))
                    {
                        list.Add(new KeyValuePair<string, string>(file, rights));
                        Console.WriteLine("Cannot Decrypt Content: {0}", file);
                        continue;
                    } else
                    {

                        string decryptedFile = SafeFileApiNativeMethods.IpcfDecryptFile(file, IPCF_DF_FLAG_DEFAULT, false, false, false, IntPtr.Zero, symmetricKeyCred, null, null);
                        list.Add(new KeyValuePair<string, string>(file, "Decrypted"));
                        Console.WriteLine("File {0} Decrypted", file);
                    }

                }

            }
            

        }

        private static string getRights(byte[] FileLicense, SafeInformationProtectionKeyHandle Keyhandle)
        {
            string returnValue;
            Collection<UserRights> rightsValues;
            if(Keyhandle == null)
            {
                returnValue = "<Can't access rights without authorization>";
            } else
            {
                returnValue = "";
                try
                {
                    bool firstRight = true;
                    rightsValues = SafeNativeMethods.IpcGetSerializedLicenseUserRightsList(FileLicense, Keyhandle);
                    foreach(UserRights r  in rightsValues)
                    {
                        foreach (string s in r.Rights)
                        {
                            returnValue += (firstRight ? "" : ",") + s;
                            firstRight = false;
                        }
                    }
                } catch
                {
                }

            }
            return returnValue;
        }
    }
}
