using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace ForEachTimings
{
    public class ConstructBenchmarks
    {
        const int ListLength = 100 * 1000 * 1000;
        readonly List<int> m_List;


        public ConstructBenchmarks()
        {
            m_List = new List<int>(ListLength);

            for (var i = 0; i < ListLength; i++)
                m_List.Add(i);
        }

        [Benchmark]
        public int Test1() => Test1(m_List);
        private static int Test1(IEnumerable<int> list)
        {
            var count = 0;
            foreach (var item in list)
                count += item;
            return count;
        }


        [Benchmark]
        public int Test2() => Test2(m_List);
        private static int Test2(IList<int> list)
        {
            var count = 0;
            foreach (var item in list)
                count += item;
            return count;
        }

        [Benchmark]
        public int Test3() => Test3(m_List);
        private static int Test3(List<int> list)
        {
            var count = 0;
            foreach (var item in list)
                count += item;
            return count;
        }

        [Benchmark]
        public int Test4() => Test4(m_List);
        private static int Test4(IList<int> list)
        {
            var count = 0;
            for (int i = 0; i < list.Count; i++)
                count += list[i];
            return count;
        }

        [Benchmark]
        public int Test5() => Test5(m_List);
        private static int Test5(List<int> list)
        {
            var count = 0;
            for (int i = 0; i < list.Count; i++)
                count += list[i];
            return count;
        }



    }
}
