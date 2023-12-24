using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminateApps
{
    class Program
    {
        static string GetProcessName(Process p)
        {
            try
            {
                return System.IO.Path.GetFileName(p.MainModule.FileName).ToLower();
            }
            catch (Exception x) { return p.ProcessName.ToLower(); }
        }
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllText(@"C:\Users\Liaquat\Desktop\New folder (4)\Apps.txt").ToLower().Split("\n\r".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var _attemp_max = 10;
            foreach (var l in lines)
            {
                var without_exe = System.IO.Path.GetFileNameWithoutExtension(l);
                if (l.StartsWith("--") ||string.IsNullOrEmpty(l)) continue;
                var _attempt = 0;
                Console.Write("{0}....{1:dd-MM-yyyy HH:mm:ss}...", l + string.Empty.PadLeft(30 - l.Length, '.'), DateTime.Now);
                var _had_error = true;
                while (_attempt <= _attemp_max && _had_error)
                {
                    var _prs = Process.GetProcesses();
                    _had_error = false;
                    foreach (var p in _prs)
                    {
                        try
                        {
                            var fName = GetProcessName(p);
                            if (l == fName || without_exe == fName)
                            {
                                _attempt++;
                                p.Kill();

                                _attempt = _attemp_max + 1;
                            }
                        }
                        catch (Exception x) { _had_error = true; }
                    }
                }
                Console.WriteLine("Done");
            }
        }
    }
}
