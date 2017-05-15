using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace ProtectedNotepad
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem mfile;
		private System.Windows.Forms.MenuItem mnew;
		private System.Windows.Forms.MenuItem mopen;
		private System.Windows.Forms.MenuItem msave;
		private System.Windows.Forms.MenuItem msaveas;
		private System.Windows.Forms.MenuItem mpagesetup;
		private System.Windows.Forms.MenuItem mprint;
		private System.Windows.Forms.MenuItem mexit;
		private System.Windows.Forms.MenuItem medit;
		private System.Windows.Forms.MenuItem mcut;
		private System.Windows.Forms.MenuItem mcopy;
		private System.Windows.Forms.MenuItem mpaste;
		private System.Windows.Forms.MenuItem mformat;
		private System.Windows.Forms.MenuItem mhelp;
		private System.Windows.Forms.MenuItem mreg;
		private System.Windows.Forms.MenuItem mabout;
		private System.Windows.Forms.MenuItem mfont;
		private System.Windows.Forms.TextBox txt;
		private System.Windows.Forms.OpenFileDialog ofd;
		private System.Windows.Forms.PrintDialog pd;
		private System.Windows.Forms.SaveFileDialog sfd;
		private System.Windows.Forms.FontDialog fd;
		private System.Windows.Forms.PageSetupDialog psd;
		private System.Windows.Forms.MenuItem ww;
        private MenuItem policyToolStripMenuItem;
        private MenuStrip menuStrip1;
        private IContainer components;

        public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.mfile = new System.Windows.Forms.MenuItem();
            this.mnew = new System.Windows.Forms.MenuItem();
            this.mopen = new System.Windows.Forms.MenuItem();
            this.msave = new System.Windows.Forms.MenuItem();
            this.msaveas = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.mpagesetup = new System.Windows.Forms.MenuItem();
            this.mprint = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.mexit = new System.Windows.Forms.MenuItem();
            this.medit = new System.Windows.Forms.MenuItem();
            this.mcut = new System.Windows.Forms.MenuItem();
            this.mcopy = new System.Windows.Forms.MenuItem();
            this.mpaste = new System.Windows.Forms.MenuItem();
            this.mformat = new System.Windows.Forms.MenuItem();
            this.ww = new System.Windows.Forms.MenuItem();
            this.mfont = new System.Windows.Forms.MenuItem();
            this.mhelp = new System.Windows.Forms.MenuItem();
            this.mreg = new System.Windows.Forms.MenuItem();
            this.mabout = new System.Windows.Forms.MenuItem();
            this.txt = new System.Windows.Forms.TextBox();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.pd = new System.Windows.Forms.PrintDialog();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.fd = new System.Windows.Forms.FontDialog();
            this.psd = new System.Windows.Forms.PageSetupDialog();
            this.policyToolStripMenuItem = new System.Windows.Forms.MenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mfile,
            this.medit,
            this.mformat,
            this.policyToolStripMenuItem,
            this.mhelp});
            // 
            // mfile
            // 
            this.mfile.Index = 0;
            this.mfile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnew,
            this.mopen,
            this.msave,
            this.msaveas,
            this.menuItem6,
            this.mpagesetup,
            this.mprint,
            this.menuItem9,
            this.mexit});
            this.mfile.Text = "File";
            // 
            // mnew
            // 
            this.mnew.Index = 0;
            this.mnew.Text = "&New";
            this.mnew.Click += new System.EventHandler(this.mnew_Click);
            // 
            // mopen
            // 
            this.mopen.Index = 1;
            this.mopen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.mopen.Text = "&Open...";
            this.mopen.Click += new System.EventHandler(this.mopen_Click);
            // 
            // msave
            // 
            this.msave.Index = 2;
            this.msave.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this.msave.Text = "&Save";
            this.msave.Click += new System.EventHandler(this.msave_Click);
            // 
            // msaveas
            // 
            this.msaveas.Index = 3;
            this.msaveas.Shortcut = System.Windows.Forms.Shortcut.CtrlA;
            this.msaveas.Text = "Save&As...";
            this.msaveas.Click += new System.EventHandler(this.msaveas_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 4;
            this.menuItem6.Text = "-";
            // 
            // mpagesetup
            // 
            this.mpagesetup.Index = 5;
            this.mpagesetup.Text = "Page Set&up...";
            this.mpagesetup.Click += new System.EventHandler(this.mpagesetup_Click);
            // 
            // mprint
            // 
            this.mprint.Index = 6;
            this.mprint.Shortcut = System.Windows.Forms.Shortcut.CtrlP;
            this.mprint.Text = "&Print";
            this.mprint.Click += new System.EventHandler(this.mprint_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 7;
            this.menuItem9.Text = "-";
            // 
            // mexit
            // 
            this.mexit.Index = 8;
            this.mexit.Shortcut = System.Windows.Forms.Shortcut.F10;
            this.mexit.Text = "E&xit";
            this.mexit.Click += new System.EventHandler(this.mexit_Click);
            // 
            // medit
            // 
            this.medit.Index = 1;
            this.medit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mcut,
            this.mcopy,
            this.mpaste});
            this.medit.Text = "Edit";
            // 
            // mcut
            // 
            this.mcut.Index = 0;
            this.mcut.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
            this.mcut.Text = "Cut";
            this.mcut.Click += new System.EventHandler(this.mcut_Click);
            // 
            // mcopy
            // 
            this.mcopy.Index = 1;
            this.mcopy.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
            this.mcopy.Text = "Copy";
            this.mcopy.Click += new System.EventHandler(this.mcopy_Click);
            // 
            // mpaste
            // 
            this.mpaste.Index = 2;
            this.mpaste.Shortcut = System.Windows.Forms.Shortcut.CtrlV;
            this.mpaste.Text = "Paste";
            this.mpaste.Click += new System.EventHandler(this.mpaste_Click);
            // 
            // mformat
            // 
            this.mformat.Index = 2;
            this.mformat.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.ww,
            this.mfont});
            this.mformat.Text = "Format";
            this.mformat.Click += new System.EventHandler(this.mformat_Click);
            // 
            // ww
            // 
            this.ww.Index = 0;
            this.ww.RadioCheck = true;
            this.ww.Text = "Word Wrap";
            this.ww.Click += new System.EventHandler(this.menuItem16_Click);
            // 
            // mfont
            // 
            this.mfont.Index = 1;
            this.mfont.Text = "Font...";
            this.mfont.Click += new System.EventHandler(this.mfont_Click);
            // 
            // mhelp
            // 
            this.mhelp.Index = 4;
            this.mhelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mreg,
            this.mabout});
            this.mhelp.Text = "Help";
            // 
            // mreg
            // 
            this.mreg.Index = 0;
            this.mreg.Text = "Register";
            this.mreg.Click += new System.EventHandler(this.mreg_Click);
            // 
            // mabout
            // 
            this.mabout.Index = 1;
            this.mabout.Text = "";
            // 
            // txt
            // 
            this.txt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt.Location = new System.Drawing.Point(0, 24);
            this.txt.Multiline = true;
            this.txt.Name = "txt";
            this.txt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt.Size = new System.Drawing.Size(1004, 510);
            this.txt.TabIndex = 1;
            this.txt.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // sfd
            // 
            this.sfd.FileName = "doc1";
            // 
            // policyToolStripMenuItem
            // 
            this.policyToolStripMenuItem.Index = 3;
            this.policyToolStripMenuItem.Text = "Protection";
            this.policyToolStripMenuItem.Click += new System.EventHandler(this.policyToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1004, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(9, 22);
            this.ClientSize = new System.Drawing.Size(1004, 534);
            this.Controls.Add(this.txt);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Protected Notes";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


		bool dirty = false;
		string fname = "";
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			menuItem16_Click(sender,e);
		}

		private void mnew_Click(object sender, System.EventArgs e)
		{
			checkdirty();
		}

		private void mformat_Click(object sender, System.EventArgs e)
		{
		
		}

		private void mopen_Click(object sender, System.EventArgs e)
		{
			ofd.Multiselect = false;
			ofd.Filter = "Text Files|*.txt";
			ofd.ShowDialog();
			if (File.Exists(ofd.FileName))
			{
				fname = ofd.FileName;
				StreamReader sr = new StreamReader(fname);
				txt.Text=sr.ReadToEnd();
				dirty = false;
				sr.Close();
			}	
		}

		private void txt_TextChanged(object sender, System.EventArgs e)
		{
			dirty = true;
		}

		private void msave_Click(object sender, System.EventArgs e)
		{
			savedata();
		}

		private void savedata()
		{
			if (fname == "")
			{	
				sfd.Filter = "Text Files|*.txt";
				DialogResult res = sfd.ShowDialog();
				if (res == DialogResult.Cancel)
				{
					return;					
				}
				fname = sfd.FileName;
				MessageBox.Show(fname);
			}
			StreamWriter sw = new StreamWriter(fname);
			sw.WriteLine(txt.Text);
			sw.Flush();
			sw.Close();
			dirty = false;
		}

		private void checkdirty()
		{
			if (dirty)
			{
				DialogResult click = MessageBox.Show(this,"Do You wish to save this Document?","Save",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1);
				if (click == DialogResult.Yes)
				{
					savedata();
					txt.Text="";
					fname = "";
					dirty = false;
				}
				if (click == DialogResult.No)
				{
					txt.Text="";
					fname = "";
					dirty = false;
				}
			}
			else
			{
				txt.Text = "";
				fname = "";
			}
		}
		
		private void msaveas_Click(object sender, System.EventArgs e)
		{
			sfd.Filter = "Text Files|*.txt";
			sfd.ShowDialog();
			fname = sfd.FileName;
			savedata();
		}

		private void mexit_Click(object sender, System.EventArgs e)
		{
			checkdirty();
            this.Dispose();		
		}

		private void mpagesetup_Click(object sender, System.EventArgs e)
		{
			PrintDocument pd1 = new PrintDocument();
			pd1.DocumentName = fname;
			psd.Document = pd1;
            psd.ShowDialog();
		}

		private void mprint_Click(object sender, System.EventArgs e)
		{
			PrintDocument pd1 = new PrintDocument();
			pd1.DocumentName = fname;
			pd.Document = pd1;
			pd.AllowSomePages = true;
			pd.AllowPrintToFile = true;
			pd.ShowDialog();
		}

		private void menuItem16_Click(object sender, System.EventArgs e)
		{
			ww.Checked = !(ww.Checked);
			txt.WordWrap = ww.Checked;
		}

		private void mfont_Click(object sender, System.EventArgs e)
		{
			fd.ShowColor = true;
			fd.ShowDialog();
			txt.Font = fd.Font;
			txt.ForeColor=fd.Color;
		}

		//private void mabout_Click(object sender, System.EventArgs e)
		//{
		//	NewForm nf = new NewForm();
		//	nf.ShowDialog();
		//}

		private void mcut_Click(object sender, System.EventArgs e)
		{
			txt.Cut();
			dirty = true;
		}

		private void mcopy_Click(object sender, System.EventArgs e)
		{
			Clipboard.SetDataObject(txt.SelectedText, true);
		}

		private void mpaste_Click(object sender, System.EventArgs e)
		{
			IDataObject iData = Clipboard.GetDataObject();
            if (iData.GetDataPresent(DataFormats.Text))
			{
				txt.SelectedText = iData.GetData(DataFormats.Text).ToString();

			}
		}

		private void mreg_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show("This is a freeware use and Bless.");
		}

        private void policyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
