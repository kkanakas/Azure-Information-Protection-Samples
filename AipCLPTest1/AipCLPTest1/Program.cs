﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using System.IO;


namespace AipClpTest1
{
    class AipClpTest1
    {
        static void Main(string[] args)
        {

            try
            {
                Console.WriteLine("Enter a pathname of a directory where your documents reside:");
                string pathname = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(pathname))
                    throw new ArgumentException(nameof(pathname));
                if (!Directory.Exists(pathname))
                    throw new ArgumentException(nameof(pathname));
                ListAipStatus(pathname);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("The Directory name cannot be blank and should exist");
            }



        }
        public static void ListAipStatus(string pathname)
        {


            //only gets the documents

            string[] items = Directory.GetFiles(pathname, "*.docx");
            // string[] items = Directory.GetFiles(pathname);
            foreach (string item in items)
            {
                var ps = PowerShell.Create();
                ps.AddCommand("Get-AIPFilestatus");
                ps.AddParameter("-Path", item);

                foreach (PSObject result in ps.Invoke())
                {

                    //var resultStrBuilder = new StringBuilder();
                    Console.WriteLine("File Name: {0}\nIs it Labelled:{1} \n Label Name: {2}", result.Members["FileName"].Value, result.Members["IsLabelled"].Value,result.Members["MainLabelName"].Value);
                    //foreach (var member in result.Members)
                    //{
                    //    if (member.MemberType == PSMemberTypes.Property)
                        
                    //        //Console.WriteLine(member.Name.ToString());
                    //        //Console.WriteLine(member.Value.ToString());
                    //        resultStrBuilder.AppendFormat("{0}\t:{1}", member.Name, member.Value).AppendLine();
                      
                            
                    //}
                    //var resultStr = resultStrBuilder.ToString();
                    //Console.WriteLine(resultStr);
                    //Console.WriteLine();

                }
            }

        }
    }
}
