using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace ASLab1
{
    class State
    {
        public string Name { get; set; }
        public string Capital { get; set; }
        public string Lang { get; set; }
        public string Num { get; set; }
        private int error;
        public int S
        {
            get
            {
                return error;
            }
            set
            {
                if (value < 1)
                    error = 1;
                else if (value > 100000000)
                    error = 17098246;
                else error = value;
            }
        }

        public string Valute { get; set; }
        public decimal Ruble { get; set; }
        public bool Activity { get; set; }

        public void Piece(string line)
        {
            string[] parts = line.Split('%');
            Name = parts[0];
            Capital = parts[1];
            Lang = parts[2];
            Num = parts[3];
            S = Int32.Parse(parts[4]);
            Valute = parts[5];
            Ruble = Decimal.Parse(parts[6]);
            Activity = bool.Parse(parts[7]);
        }
        public static List <State> ReadFile(string statefile)
        {
            List<State> res = new List<State>();
            using (StreamReader sr = new StreamReader(statefile))
            {
                string line;
                while((line = sr.ReadLine())!= null)
                {
                    State p = new State();
                    p.Piece(line);
                    res.Add(p);
                }
            }
            return res;
        }


    }
    
}
