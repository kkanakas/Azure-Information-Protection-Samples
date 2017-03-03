using System;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.InformationProtectionAndControl;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Security;

namespace SelectFileandEncryptForm
{
    public partial class fileEncrypt : Form
    {
        public fileEncrypt()
        {
            InitializeComponent();
            SafeNativeMethods.IpcInitialize();
        }

        private static object credentialInfo;
        private static Object getCredentialLock = new Object();
        private static Lazy<OAuth2CallbackContext> _callbackContext;
        private static Collection<TemplateInfo> templates = null;
        private static string CLIENT_ID = null;
        

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



        private void selectFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog1.Filter = "Office Files (*.docx,*.xlsx,*.pptx)|*.docx;*.xlsx;*.pptx|Text Files (*.txt)|*.txt|pdf files (*.pdf)|*.pdf|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                try
                {
                    if (openFileDialog1.OpenFile() != null)
                    {
                        filePath.Text = openFileDialog1.FileName;
                       
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: selected file has an error" + ex.Message);
                }
            }
        }

        private void encryptButton_Click(object sender, EventArgs e)
        {
            
            var checkEncryptionStatus = SafeFileApiNativeMethods.IpcfIsFileEncrypted(filePath.Text.Trim());
            if (checkEncryptionStatus.ToString().ToLower().Contains("encrypted"))
            {
                DialogResult isEncrypted = MessageBox.Show("Selected file is already encrypted");
                if (isEncrypted == DialogResult.OK)
                    Application.Exit();
            } else
            {
                

                try
                {
                    int templateNum = templateListBox.SelectedIndex;
                    //MessageBox.Show(templateNum.ToString());
                    TemplateInfo selectedTemplateInfo = templates.ElementAt(templateNum);
                    var license = SafeNativeMethods.IpcCreateLicenseFromTemplateId(selectedTemplateInfo.TemplateId);
                    string encryptedFilePath = SafeFileApiNativeMethods.IpcfEncryptFile(filePath.Text.Trim(),license, SafeFileApiNativeMethods.EncryptFlags.IPCF_EF_FLAG_DEFAULT, false, false, true, IntPtr.Zero, null);
                    DialogResult result = MessageBox.Show("File has been Encrypted and is at the following location: " + encryptedFilePath);
                    if (result == DialogResult.OK)
                    {
                        Application.Exit();
                    }
                }
                catch (Exception ex)
                {
                    DialogResult error = MessageBox.Show("Error: " + ex);
                    if (error == DialogResult.OK)
                    {
                        Application.Exit();
                    }

                }

            }
          
        }

        

        
        

        private void getTemplateButton_Click(object sender, EventArgs e)
        {



            //var currentAdal = new currentAdalAuth
            //{
            //    username = usernameBox.Text,
            //    password = passwordBox.Text
            //};
            SecureString password = new SecureString();
            foreach (char p in passwordBox.Text)
            {
                password.AppendChar(p);
            }

            CLIENT_ID = clientidBox.Text;
            _callbackContext = new Lazy<OAuth2CallbackContext>(() =>
            {
                return new OAuth2CallbackContext(null, (object context, NameValueCollection authSettings) =>
                {
                    var authContext = new AuthenticationContext(authSettings["authorization"], null);
                    var authResult = authContext.AcquireTokenAsync(authSettings["resource"], CLIENT_ID.Trim(),
                        new UserPasswordCredential(usernameBox.Text.Trim(), password));
                    return SafeNativeMethods.IpcCreateOAuth2Token(authResult.Result.AccessToken);
                });
            });

             templates = SafeNativeMethods.IpcGetTemplateList(null, false, true, false, true, null, null, CredentialInfo);
            if (templates.Count() == 0)
            {
                MessageBox.Show("Templates did not load. Please check your credentials ");
               
            } 
            else
            {
                templateListBox.Items.Clear();
            }
            
            
            for (int i = 0; i < templates.Count; i++)
            {
                templateListBox.Items.Add(templates.ElementAt(i).Name);
                //MessageBox.Show(templates.ElementAt(i).Name);
            }
        }

        private void exitButton_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

         /*public static bool isEmailValid(String email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }*/

    }

   
}
