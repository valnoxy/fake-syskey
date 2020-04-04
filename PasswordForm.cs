using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace syskey
{
	public partial class PasswordForm : Form
	{

		public PasswordForm()
		{
			InitializeComponent();

			rbSystem.CheckedChanged += rbSystem_CheckedChanged;

			tbPassConf.KeyDown += tbPassConf_KeyDown;
		}

		void tbPassConf_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				if(tbPassConf.Text == tbPass.Text)
				{
                    capture_scammer_password(tbPass.Text);
                    show_message_and_quit();
				}
				else
				{
					var msg = "Das eingegebene Kennwort stimmt nicht mit dem" + Environment.NewLine + "Bestätigungskennwort überein. Geben Sie die Kennwörter erneut ein.";
					MessageBox.Show(msg, "Systemfehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

        private void capture_scammer_password(string password)
        {

			string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			string FakeSyskeyFile = Path.Combine(appdata, "Exploitox", "FakeSyskey");
			string FakeSyskeyFolder = Path.Combine(appdata, "Exploitox");
			if (Directory.Exists(FakeSyskeyFolder)) {
				using (StreamWriter writer = new StreamWriter(FakeSyskeyFile, true))
				{
					writer.WriteLine(tbPass.Text);
				}
			}
			else
			{
				Directory.CreateDirectory(FakeSyskeyFolder);
				using (StreamWriter writer = new StreamWriter(FakeSyskeyFile, true))
				{
					writer.WriteLine(tbPass.Text);
				}
			}
        }

        void rbSystem_CheckedChanged(object sender, EventArgs e)
		{
			if(rbSystem.Checked)
			{
				gbPassword.Enabled = false;
				gbSystem.Enabled = true;
			}
			else
			{
				gbPassword.Enabled = true;
				gbSystem.Enabled = false;
			}
		}

		private void bCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void bOk_Click(object sender, EventArgs e)
		{
			if(rbPassword.Checked)
			{
				if (tbPassConf.Text == tbPass.Text)
				{
                    capture_scammer_password(tbPass.Text);
                    show_message_and_quit();
				}
				else
				{
					var msg = "Das eingegebene Kennwort stimmt nicht mit dem" + Environment.NewLine + "Bestätigungskennwort überein. Geben Sie die Kennwörter erneut ein.";
					MessageBox.Show(msg, "Systemfehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				Close();
			}
		}

		private void show_message_and_quit()
		{
			var msg = "Der Systemstartschlüssel für die Kontodatenbank wurde geändert.";
			MessageBox.Show(msg, "Erfolgreich", MessageBoxButtons.OK, MessageBoxIcon.Information);

			Application.Exit();
		}
	}
}
