using System;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.InformationProtectionAndControl;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Specialized;

namespace SelectFileandEncryptForm
{
    public partial class fileEncrypt : Form
    {
        public fileEncrypt()
        {
            InitializeComponent();
        }



        private void selectFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog1.Filter = "Office Files (*.docx,*.xlsx,*.pptx)|*.docx;*.xlsx;*.pptx|Text Files (*.txt)|*.txt| All Files (*.*)| *.*";
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
                    MessageBox.Show("Error: selected file does not exist" + ex.Message);
                }
            }
        }

        private void encryptButton_Click(object sender, EventArgs e)
        {


        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void templateListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SafeNativeMethods.IpcInitialize();
            private string CLIENT_ID = clientidBox.Text;

        var currentAdal = new currentAdalAuth
            {
                username = usernameBox.Text,
                password = passwordBox.Text
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
                    });
            });

        }
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
