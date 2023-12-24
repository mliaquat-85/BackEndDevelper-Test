using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        public int V;
        public DateTime Now;
        internal async Task CheckNetworkStatusAsync()
        {
            Task t = NetworkCheckInternalAsync();
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine("Top level method working...");
                await Task.Delay(500);
            }
            await t;
        }
        private async Task NetworkCheckInternalAsync()
        {
            for (int i = 0; i < 10; i++)
            {
                bool isNetworkUp = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
                Console.WriteLine("Is network available? Answer: {0}", isNetworkUp);
                await Task.Delay(100);
            }
        }
        static void Main(string[] args)
        {
            ConcurrentBag<int> aax = new ConcurrentBag<int>();
            var _p = new Program();
            var v=_p.CheckNetworkStatusAsync();
            Parallel.For(1, 2000, aa =>
                {
                    //a.Add(new Program { V = a.Count + 1, Now = DateTime.Now });
                    aax.Add(aax.Count + 1);
                    //System.Threading.Thread.Sleep(100);
                });

            string name = "Muhammad Liaquat";

            List<string> tokens = new List<string>();

            var searchstr = ' ';
            var content = string.Empty;
            for (var i = 0; i < name.Length; i++)
            {
                if (name[i] == searchstr)
                {
                    tokens.Add(content);
                    content = string.Empty;
                }
                else
                {
                    content += name[i];
                }
            }
            if (!string.IsNullOrEmpty(content)) tokens.Add(content);

            foreach (var t in tokens) Console.WriteLine(t);


            var tt = Task();

            Console.Write("PRESS ANY KEY....");
            Console.ReadKey();
            var emps = new List<Employee>();
            var dpts = new List<Department>();

            var list = (from e in emps
                        join d in dpts on e.DeptId equals d.DeptId
                        select e).ToList();

        }
        private static async Task<int> Task()
        {
            var r1 = await Task1(10);
            var r2 = await Task2(r1);

            return 0;
        }
        private static async Task<int> Task1(int num)
        {
            System.Threading.Thread.Sleep(2000);
            return num + 3;
        }
        private static async Task<int> Task2(int num)
        {
            return num + 9;
        }
    }
    public class Employee
    {
        public int EmpId { get; set; }
        public int DeptId { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Currency { get; set; }

        public Department GetDepartment()
        {
            return new Department { DeptId = this.DeptId };
        }
    }
    public class Department
    {
        public int DeptId { get; set; }
        public string Name { get; set; }
    }
}
