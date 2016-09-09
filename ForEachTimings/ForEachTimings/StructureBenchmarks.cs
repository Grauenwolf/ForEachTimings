using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;

namespace ForEachTimings
{
    public class StructureBenchmarks
    {
        const int ListLength =  1000;
        readonly List<int> m_List;
        readonly Collection<int> m_Collection;
        readonly ReadOnlyCollection<int> m_ReadOnlyCollection;
        readonly ImmutableList<int> m_ImmutableList;
        readonly ImmutableArray<int> m_ImmutableArray;
        readonly int[] m_Array;

        public StructureBenchmarks()
        {
            m_Array = new int[ListLength];
            for (var i = 0; i < ListLength; i++)
                m_Array[i] = i;


            m_List = new List<int>(m_Array);
            m_Collection = new Collection<int>(m_List);
            m_ReadOnlyCollection = new ReadOnlyCollection<int>(m_List);
            m_ImmutableList = ImmutableList.CreateRange(m_List);
            m_ImmutableArray = ImmutableArray.CreateRange(m_List);
        }

        [Benchmark]
        public int List_For()
        {
            var count = 0;
            for (int i = 0; i < m_List.Count; i++)
                count += m_List[i];
            return count;
        }
        [Benchmark]
        public int List_ForEach()
        {
            var count = 0;
            foreach (var item in m_List)
                count += item;
            return count;
        }

        [Benchmark]
        public int Collection_For()
        {
            var count = 0;
            for (int i = 0; i < m_Collection.Count; i++)
                count += m_Collection[i];
            return count;
        }
        [Benchmark]
        public int Collection_ForEach()
        {
            var count = 0;
            foreach (var item in m_Collection)
                count += item;
            return count;
        }

        [Benchmark]
        public int ReadOnlyCollection_For()
        {
            var count = 0;
            for (int i = 0; i < m_ReadOnlyCollection.Count; i++)
                count += m_ReadOnlyCollection[i];
            return count;
        }
        [Benchmark]
        public int ReadOnlyCollection_ForEach()
        {
            var count = 0;
            foreach (var item in m_ReadOnlyCollection)
                count += item;
            return count;
        }

        [Benchmark]
        public int ImmutableList_For()
        {
            var count = 0;
            for (int i = 0; i < m_ImmutableList.Count; i++)
                count += m_ImmutableList[i];
            return count;
        }
        [Benchmark]
        public int ImmutableList_ForEach()
        {
            var count = 0;
            foreach (var item in m_ImmutableList)
                count += item;
            return count;
        }

        [Benchmark]
        public int ImmutableArray_For()
        {
            var count = 0;
            for (int i = 0; i < m_ImmutableArray.Length; i++)
                count += m_ImmutableArray[i];
            return count;
        }
        [Benchmark]
        public int ImmutableArray_ForEach()
        {
            var count = 0;
            foreach (var item in m_ImmutableArray)
                count += item;
            return count;
        }

        [Benchmark]
        public int Array_For()
        {
            var count = 0;
            for (int i = 0; i < m_Array.Length; i++)
                count += m_Array[i];
            return count;
        }
        [Benchmark]
        public int Array_ForEach()
        {
            var count = 0;
            foreach (var item in m_Array)
                count += item;
            return count;
        }
    }
}
