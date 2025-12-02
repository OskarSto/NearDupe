
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks.Dataflow;
using System.Xml.Linq;
namespace HashBymemory
{
    
    class Program
    {
        
        static void Main()
        {
            
            DateTime startime = DateTime.Now;
            FetchFile Fetch = new FetchFile();
            Shingles sh = new Shingles(Fetch.contents);
            List<string> names = sh.ListOfShingles;
            Shingles sh1 = new Shingles(Fetch.contents2);
            List<string> names1 = sh1.ListOfShingles;

            var dict = new LinkedListHashTable<string, int>(names.Count);
            for (int i = 0; i < names.Count; i++)
                dict.Add(names[i], 0);

            HashSet<string> shingles1 = new HashSet<string>(names);   
            HashSet<string> shingles2 = new HashSet<string>(names1); 

            int intersectionCount = shingles2.Count(s => dict.ContainsKey(s));
            int unionCount = shingles1.Count + shingles2.Count - intersectionCount;
            double jaccardSimilarity = unionCount == 0 ? 0 : (double)intersectionCount / unionCount;

            TimeSpan tidbrugt = DateTime.Now - startime;
            Console.WriteLine(tidbrugt.TotalMilliseconds);
            Console.WriteLine($"Jaccard similarity: {jaccardSimilarity:F3}");


        }
    }
}

