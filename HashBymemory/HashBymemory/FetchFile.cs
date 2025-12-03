using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashBymemory
{

    class FetchFile
    {
        static string path = "ASVBible.txt";
        static string path2 = "BigJames.txt";
        
        public string contents = File.ReadAllText(path);
        public string contents2 = File.ReadAllText(path2);
    }

}
