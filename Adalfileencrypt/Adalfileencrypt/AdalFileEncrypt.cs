using Microsoft.InformationProtectionAndControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adalfileencrypt
{
    public partial class AdalFileEncrypt : Form
    {
        /* please change these values to run with your 
         * application ID after registering the app in AAD <which is Client ID> and the redirectURI
         * for your application */
        public static string adalAppID = "7a0987a4-c6fc-4fa5-bedd-571286439708";
        public static string adalRedirectURI = "https://gyrops.onmicrosoft.com/.auth/login/done";

        IpcAadApplicationId currAppId = new IpcAadApplicationId(adalAppID, adalRedirectURI);
        public AdalFileEncrypt()
        {
            InitializeComponent();
            SafeNativeMethods.IpcInitialize();
            try
            {
                SafeNativeMethods.IpcSetApplicationId(currAppId);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show("Error: " + ex);
                if (result == DialogResult.OK)
                {
                    Application.Exit();
                }

            }
        }

        private void getTeamplatesBtn_Click(object sender, EventArgs e)
        {
            
            
            
            

        }
    }
    
}
