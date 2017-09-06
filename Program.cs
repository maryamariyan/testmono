
using System;
using System.IO;
using System.Diagnostics;
using System.Text;
namespace ProjInMac
{
	public class Program
	{
		public static void Main()
		{
                        // no xdg: 	System.ComponentModel.Win32Exception (0x80004005): Access denied at System.Diagnostics.Process.StartWithShellExecuteEx
			// with xdg: 	System.NullReferenceException: Object reference not set to an instance of an object
                        string fileToOpen = "README.md";

                        // no xdg:	System.ComponentModel.Win32Exception (0x80004005): Cannot find the specified file
			// with xdg:	System.NullReferenceException: Object reference not set to an instance of an object
                        string urlToOpen = "http://www.google.com";

			// no xdg:	System.InvalidOperationException: Process must exit before requested information can be determined.
			// with xdg:	Works fine
			string appToOpen = "nano";

			var startInfo = new ProcessStartInfo { UseShellExecute = true, FileName = urlToOpen };
			using (var px = Process.Start(startInfo))
			{
				var sb = new StringBuilder();
				sb.Append("px has exited? "+ px.HasExited + " ");
				px.WaitForExit();
				sb.Append("px exit code? "+ px.ExitCode + " ");
				Console.WriteLine(sb.ToString());
			}
			Console.ReadLine();
		}
	}
}
