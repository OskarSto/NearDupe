using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashBymemory
{
    class Shingles
    {
        public List<string> ListOfShingles = new List<string>();

        public Shingles(string content, int shingleSize = 3)
        {
            string[] parts = content.Split(
            new char[] { ' ', '\r', '\n' },       // delimiters
            StringSplitOptions.RemoveEmptyEntries // skip empty entries
            );  
            int shinglesize = 3;

            for (int i = 0; i < parts.Length - shinglesize; i++)
            {
                string shingle = string.Join(" ", parts[i..(i + shinglesize)]);
                ListOfShingles.Add(shingle);
            }

        }

    }
}
