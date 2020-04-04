using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace syskey
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			//Application.EnableVisualStyles(); // Deaktiviert. So hat es ähnlichkeiten mit syskey! :)
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new EntryForm());
		}
	}
}
