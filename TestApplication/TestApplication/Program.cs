using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.InformationProtectionAndControl;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication
{
    public class Program
    {
        private const string CLIENT_ID = "6b069eef-9dde-4a29-b402-8ce866edc897";
        static void Main(string[] args)
        {

            SafeNativeMethods.IpcInitialize();

            var currentAdal = new currentAdalAuth
            {
                username = "adkgupta@microsoft.com",
                password = "Gethealthy~1"
            };

            // OAUTH2 callback setup
            _callbackContext = new Lazy<OAuth2CallbackContext>(() =>
            {
                return new OAuth2CallbackContext(null,
                    (object context, NameValueCollection authSettings) =>
                    {
                        var authContext = new AuthenticationContext(authSettings["authorization"], null);
                        var authResult = authContext.AcquireTokenAsync(authSettings["resource"],
                                CLIENT_ID,
                                new UserPasswordCredential(currentAdal.username, currentAdal.password));
                        return SafeNativeMethods.IpcCreateOAuth2Token(authResult.Result.AccessToken);
                    },
                    false);
            });

            var templateIssuer = SafeNativeMethods.IpcGetTemplateIssuerList(null,
                false,
                false,
                false,
                true,
                IntPtr.Zero,
                CredentialInfo
                );
            string file = "e:\\Test\\test01.txt";

            System.Collections.ObjectModel.Collection<string> rightList = new System.Collections.ObjectModel.Collection<string>();
            System.Collections.ObjectModel.Collection<UserRights> userrightList = new System.Collections.ObjectModel.Collection<UserRights>();
            var license = SafeNativeMethods.IpcCreateLicenseFromScratch(templateIssuer[0]);
             rightList.Add("VIEW");
            UserRights user = new UserRights(UserIdType.Email, "adkgupta@microsoft.com", rightList);
            userrightList.Add(user);
            SafeNativeMethods.IpcSetLicenseUserRightsList(license, userrightList);
            //encrypting

            SafeFileApiNativeMethods.IpcfEncryptFile(file, license, SafeFileApiNativeMethods.EncryptFlags.IPCF_EF_FLAG_DEFAULT, false, false, true, IntPtr.Zero,null);

        }


        public static object credentialInfo;

        private static Object getCredentialLock = new Object();
        private static Lazy<OAuth2CallbackContext> _callbackContext;

        private static object CredentialInfo
        {
            get
            {
                lock (getCredentialLock)
                {
                    if (credentialInfo == null)
                    {
                        credentialInfo = GetADALAuthCallback();
                    }
                }
                return credentialInfo;
            }
            set
            {
                credentialInfo = value;
            }
        }


        private static object GetADALAuthCallback()
        {
            return _callbackContext != null ? _callbackContext.Value : null;
        }
    }

    public class currentAdalAuth
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
