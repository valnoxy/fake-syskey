using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace syskey
{
	public partial class EntryForm : Form
	{
		public EntryForm()
		{
			InitializeComponent();
		}

		private void bOk_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void bCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void bUpdate_Click(object sender, EventArgs e)
		{
			new PasswordForm().ShowDialog();
		}
	}
}
