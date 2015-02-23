using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Updater {
	class Program {
		static void Main(string[] args) {
			Console.WriteLine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
			Console.WriteLine(System.AppDomain.CurrentDomain.FriendlyName);

			// Check arguments
			Console.WriteLine("# Arguments #");

			if (args.Length < 3) {
				Process pro = Process.GetProcessById(12460);
				Console.WriteLine(pro.CloseMainWindow());
				//pro.Close();
				pro.WaitForExit();

				Console.WriteLine("Argument error");
				return;
			}

			// Project name
			// File path
			// Process id

			foreach (string str in args) {
				Console.WriteLine(str);
			}

			// Close process
			Console.WriteLine("# Close process #");

			try {
				int id = Convert.ToInt32(args[2]);
				Console.WriteLine(id.ToString());

				Process pro = Process.GetProcessById(id);
				pro.CloseMainWindow();
				pro.WaitForExit(10000);

				if (pro.HasExited == false) {
					pro.Kill();
				}

				Console.WriteLine("Process closed");
			} catch (Exception ex) {
				Console.WriteLine(ex.Message);
			}

			// File movement
			Console.WriteLine("# File movement #");

			string o = string.Format("{0}\\{1}.exe", args[1], args[0]);
			string n = string.Format("{0}\\{1}_update.exe", args[1], args[0]);

			try {
				File.Delete(o);
				File.Move(n, o);
			} catch (Exception ex) {
				Console.WriteLine(ex);
			}

			// Run program

			Process pro2 = new Process();
			try {
				pro2.StartInfo.FileName = o;
				pro2.Start();
			} catch (Exception ex) {
				Console.WriteLine(ex);
			}

			if (args.Length == 4) {
				Console.ReadKey();
			}
		}
	}
}
