using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashBymemory
{

    public class LinkedListHashTable<Hkey, HValue>
    {
        private class Insert
        {
            public Hkey Key;
            public HValue Value;

            public Insert(Hkey key, HValue value)
            {
                Key = key;
                Value = value;
            }
        }

        private readonly LinkedList<Insert>[] buckets;
        private readonly int LinkedListCount;

        public LinkedListHashTable(int size)
        {
            LinkedListCount = size;
            buckets = new LinkedList<Insert>[LinkedListCount];
        }

        private int GetBucketIndex(Hkey key)
        {
            int hash = key.GetHashCode();
            return Math.Abs(hash % LinkedListCount);
        }

        public void Add(Hkey key, HValue value)
        {
            int index = GetBucketIndex(key);

            if (buckets[index] == null)
                buckets[index] = new LinkedList<Insert>();

            // Always add a new entry, even if the key exists
            buckets[index].AddLast(new Insert(key, value));
        }

        public bool TryGetValue(Hkey key, out HValue value)
        {
            int index = GetBucketIndex(key);

            if (buckets[index] != null)
            {
                foreach (var entry in buckets[index])
                {
                    if (entry.Key.Equals(key))
                    {
                        value = entry.Value;
                        return true;
                    }
                }
            }

            value = default!;
            return false;
        }

        public bool ContainsKey(Hkey key)
        {
            return TryGetValue(key, out _);
        }

        public bool Remove(Hkey key)
        {
            int index = GetBucketIndex(key);

            var bucket = buckets[index];
            if (bucket == null)
                return false;

            var node = bucket.First;
            while (node != null)
            {
                if (node.Value.Key.Equals(key))
                {
                    bucket.Remove(node);
                    return true;
                }
                node = node.Next;
            }

            return false;
        }

        public void PrintContents()
        {
            for (int i = 0; i < LinkedListCount; i++)
            {
                Console.Write($"Bucket {i}: ");
                if (buckets[i] != null)
                {
                    foreach (var entry in buckets[i])
                        Console.Write($"[{entry.Key}:{entry.Value}] ");
                }
                Console.WriteLine();
            }
        }
    }


}
