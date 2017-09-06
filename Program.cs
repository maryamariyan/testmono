
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
			// with xdg: 	px is null
                        string fileToOpen = "README.txt";

                        // no xdg:	System.ComponentModel.Win32Exception (0x80004005): Cannot find the specified file
			// with xdg:	px is null
                        string urlToOpen = "http://www.google.com";

			// no xdg:	Works fine.
			// with xdg:	Works fine
			string appToOpen = "nano";

			// when UseShellExecute is false, FileName will be applicationname and Arguments will be args for the applicationname
			// when true, use shell exec process to open that program instead of running a process, and the FileName will be file/url/program
			var startInfo = new ProcessStartInfo { UseShellExecute = true, FileName = urlToOpen };
			using (var px = Process.Start(startInfo))
			{
				if (px != null) 
				{
					var sb = new StringBuilder();
                                	sb.Append("px has exited? "+ px.HasExited + " ");

					px.WaitForExit();

  	                              	sb.Append("px exit code? "+ px.ExitCode + " ");
        	                        Console.WriteLine(sb.ToString());

				}
				else
					Console.WriteLine("px is null");
			}
		}
	}
}
