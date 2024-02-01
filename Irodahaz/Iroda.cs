using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Irodahaz
{
    internal class Iroda
    {
        public string kod;
        public string kezdDatum;
        public List<int> letszamok;

        public Iroda(string sor)
        {
            var v = sor.Split(' ').ToList();
            kod = v[0];
            kezdDatum = v[1];
            letszamok = new List<int>();
            for (int i = 2; i < v.Count; i++)
            {
                letszamok.Add(int.Parse(v[i]));
            }

        }
        public override string ToString()
        {
            string text = string.Empty;
            text += kod + "\t";
            if (kod.Length < 8) text += "\t";
            text += kezdDatum + "\t";
            for (int i = 0; i < letszamok.Count; i++)
            {
                text += letszamok[i].ToString() + "\t";
            }
            return text;
        }
    }
}

