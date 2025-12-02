using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashBymemory
{
    
        class FetchFile
        {
            static string path = "C:\\Users\\ohs\\Desktop\\Shingle testing\\Alice In Wonderland.txt";
            static string path2 = "C:\\Users\\ohs\\Desktop\\Shingle testing\\Alice In Wonderland - Kopi.txt";

            public string contents = File.ReadAllText(path);
            public string contents2 = File.ReadAllText(path2);
    }
    
}
