

//FetchFile Fetch = new FetchFile();
//Shingles sh = new Shingles(Fetch.contents);
//List<string> names = sh.ListOfShingles;
//Dictionary<int, string> HashTable = new Dictionary<int, string>();

//for (int i = 0; i < names.Count; i++)
//{
//    HashFunction h = new HashFunction();
//    h.Name = names[i];
//    int key = Math.Abs(h.GetHashCode() % names.Count);

//    for (int x = 0; x < names.Count; x++)
//    {
//        int probeKey = (key + x) % names.Count;
//        if (!HashTable.ContainsKey(probeKey))
//        {
//            HashTable[probeKey] = h.Name;
//            break;
//        }
//    }
//}

//Shingles sh1 = new Shingles(Fetch.contents2);
//List<string> names1 = sh1.ListOfShingles;
//int matches = 0;

//for (int i = 0; i < names1.Count; i++)
//{
//    HashFunction h = new HashFunction();
//    h.Name = names1[i];
//    int key = Math.Abs(h.GetHashCode() % names.Count);

//    // Linear probing to find if the shingle exists
//    for (int x = 0; x < names.Count; x++)
//    {
//        int probeKey = (key + x) % names.Count; // wrap around

//        if (HashTable.ContainsKey(probeKey))
//        {
//            if (HashTable[probeKey] == h.Name)
//            {
//                matches++;
//                break; // found, stop probing
//            }
//        }
//        else
//        {
//            // Reached an empty spot => shingle does not exist
//            break;
//        }
//    }
//}

//double similarity = 100.0 * matches / names1.Count;
//Console.WriteLine($"Similarity: {similarity:F2}%");


//        }

//    } 