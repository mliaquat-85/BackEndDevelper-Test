using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoGame
{
    public class MyStack<T>
    {
        private T[] _list;
        private int _index = -1;
        public MyStack(int _size)
        {
            this._list = new T[_size];
        }
        public MyStack() : this(1000) { }

        public void Push(T t) { this._list[++this._index] = t; }
        public T Pop()
        {
            if (this._index < 0) throw new Exception("Item Not Pushed");
            return this._list[this._index--];
        }
        public bool Exists(T t)
        {
            for (var i = 0; i <= this._index; i++)
            {
                if (this._list[i].Equals(t)) return true;
            }
            return false;
        }
        public int Size { get { return this._index + 1; } }
    }

    class Program
    {
        private static bool FindValue<T>(T[] array, T value, int size)
        {
            for (var i = 0; i <= size; i++)
            {
                if (array[i].Equals(value)) return true;
            }
            return false;
        }
        static void MainLottry(string[] args)
        {
            int _max = 0, _unique = 1;

            while (_max < _unique)
            {
                Console.Write("Enter Unique Numbers?"); _unique = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter End Range     ?"); _max = Convert.ToInt32(Console.ReadLine());
            }
            MyStack<int> _stack = new MyStack<int>(_unique);
            Random r = new Random();
            while (_stack.Size < _unique)
            {
                var v = r.Next(1, _max);
                if (!_stack.Exists(v)) _stack.Push(v);
            }
            Console.Write("Unique Numbers      :");
            while (_stack.Size > 0) Console.Write("{0} ", _stack.Pop());
            Console.WriteLine(); Console.WriteLine(); Console.Write("PRESS ANY KEY...."); Console.ReadKey();
        }

        static void Main(string[] args)
        {
            var dreader = new ReadDelimatedFile();
            dreader.FilePath = @"C:\Users\Liaquat\Downloads\weather.txt";
            dreader.Headers.Add(new DelimitedField(2, "Blank"));
            dreader.Headers.Add(new DelimitedField(3, "Day"));
            dreader.Headers.Add(new DelimitedField(6, "Max Temp"));
            dreader.Headers.Add(new DelimitedField(6, "Min Temp"));
            dreader.Headers.Add(new DelimitedField(6, "Avg Temp"));

            var count = dreader.LoadData();
            var _data = dreader.Data;

            foreach (var _d in _data)
            {
                Console.WriteLine("{0} {1} {2}", _d[1], _d[2], _d[3]);
            }
            Console.ReadKey();
        }
    }
    public class DelimitedField
    {
        public int Length { get; set; }
        public string Header { get; set; }

        public DelimitedField(int length, string header)
        {
            this.Length = length;
            this.Header = header;
        }
    }
    public class ReadDelimatedFile
    {
        public bool FirstRowHeader { get; set; }
        public bool TrimValue { get; set; }
        public string FilePath { get; set; }
        public List<DelimitedField> Headers { get; set; }

        public List<string[]> Data { get; set; }

        public int ContentLength{get;set;}
        public ReadDelimatedFile()
        {
            this.FirstRowHeader = true;
            this.Headers = new List<DelimitedField>();
            this.Data = new List<string[]>();
        }

        public int LoadData()
        {
            int _line_number = 0;
            using (var sr = new System.IO.StreamReader(this.FilePath))
            {
                if (this.FirstRowHeader) sr.ReadLine();

                this.ContentLength=0;
                foreach(var h in this.Headers)this.ContentLength=this.ContentLength+h.Length;

                this.Data.Clear();

                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    if (line.Length >= this.ContentLength)
                    {
                        var _row=new string[this.Headers.Count];
                        _line_number++;
                        var _start_index = 0;
                        for (var i = 0; i < this.Headers.Count; i++)
                        {
                            var h = this.Headers[i];
                            _row[i] = line.Substring(_start_index, h.Length);
                            if (this.TrimValue) _row[i] = _row[i].Trim();

                            _start_index += h.Length;
                        }
                        this.Data.Add(_row);
                    }
                }
                sr.Close();
            }
            return _line_number;
        }
    }
}
