using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace ForEachTimings
{
    public class LinqBenchmarks
    {
        const int ListLength = 100 * 1000 * 1000;
        readonly List<int> m_List;


        public LinqBenchmarks()
        {
            m_List = new List<int>(ListLength);

            for (var i = 0; i < ListLength; i++)
                m_List.Add(i);
        }

        [Benchmark]
        public int IList_Linq() => IList_Linq(m_List);
        private static int IList_Linq(IList<int> list)
        {
            var count = 0;
            foreach (var item in list.Where(x => x % 2 == 0))
                count += item;
            return count;
        }

        [Benchmark]
        public int IList_If() => IList_If(m_List);
        private static int IList_If(IList<int> list)
        {
            var count = 0;
            foreach (var item in list)
                if (item % 2 == 0)
                    count += item;
            return count;
        }


        [Benchmark]
        public int List_Linq() => List_Linq(m_List);
        private static int List_Linq(List<int> list)
        {
            var count = 0;
            foreach (var item in list.Where(x => x % 2 == 0))
                count += item;
            return count;
        }

        [Benchmark]
        public int List_If() => List_If(m_List);
        private static int List_If(List<int> list)
        {
            var count = 0;
            foreach (var item in list)
                if (item % 2 == 0)
                    count += item;
            return count;
        }

    }
}
