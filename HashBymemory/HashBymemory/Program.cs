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
            //setting up the data
            FetchFile Fetch = new FetchFile();
            Shingles sh = new Shingles(Fetch.contents);
            List<string> names = sh.ListOfShingles;
            Shingles sh1 = new Shingles(Fetch.contents2);
            List<string> names1 = sh1.ListOfShingles;

            // comment out to test OogaBooga method
            // Wallgen method runtime
            DateTime startimeWallgen = DateTime.Now;

            HashSet<string> shingles1 = new HashSet<string>(names);
            HashSet<string> shingles2 = new HashSet<string>(names1);

            // Gathering intersection and union using Wallgen method
            int WallgenIntersectionCount = WallgenIntersection(names, shingles2);
            int WallgenUnionCount = WallgenUnion(shingles1, shingles2, WallgenIntersectionCount);

            // Calculating Jaccard similarity using Wallgen method
            double jaccardSimilarityWallgen = JaccardSimilarity(WallgenUnionCount, WallgenIntersectionCount);
            Report(startimeWallgen, jaccardSimilarityWallgen);


            //uncomment to test OogaBooga method
            ////OogaBooga method runtime
            //DateTime startimeOoga = DateTime.Now;

            ////Gathering union and intersection using OogaBooga method
            //int OogaUnion = OogaBoogaUnion(names, names1);
            //int OogaIntersection = OogaBoogaIntersection(names, names1);

            //// Calculating Jaccard similarity using OogaBooga method
            //double jaccardSimilarityOoga = JaccardSimilarity(OogaUnion, OogaIntersection);
            //Report(startimeOoga, jaccardSimilarityOoga);
        }

        static int OogaBoogaUnion(List<string> list1, List<string> list2)
        {
            var firstNotSecond = list1.Except(list2).ToList();
            var secondNotFirst = list2.Except(list1).ToList();

            return firstNotSecond.Concat(secondNotFirst).Count();
        }

        static int OogaBoogaIntersection(List<string> list1, List<string> list2)
        {
            IEnumerable<string> matches = list1.Intersect(list2);
            return matches.Count();
        }

        static int WallgenUnion(HashSet<string> shingles1, HashSet<string> shingles2, int intersectionCount)
        {
            return shingles1.Count + shingles2.Count - intersectionCount;
        }

        static int WallgenIntersection(List<string> names, HashSet<string> shingles2)
        {
            var dict = new LinkedListHashTable<string, int>(names.Count);
            for (int i = 0; i < names.Count; i++)
                dict.Add(names[i], 0);

            return shingles2.Count(s => dict.ContainsKey(s));
        }

        static double JaccardSimilarity(int unionCount, int intersectionCount)
        {
            return unionCount == 0 ? 0 : (double)intersectionCount / unionCount;
        }

        static void Report(DateTime startTime, double jaccardSimilarity)
        {
            TimeSpan tidbrugt = DateTime.Now - startTime;
            Console.WriteLine(tidbrugt.TotalMilliseconds);
            Console.WriteLine($"Jaccard similarity: {jaccardSimilarity:F3}");
        }
    }
}

