using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
   
    
        internal class Cage : IEquatable<Cage>, IComparable<Cage>
        {

            public Cage(int h, int l, int w, string t)
            {
                this.Height = h;
                this.Length = l;
                this.Width = w;
                this.Type = t;
            }
            public int Height { get; set; }
            public int Length { get; set; }
            public int Width { get; set; }
            public string Type { get; set; }
            public bool Equals(Cage other)
            {
                return false;
            }

            public override bool Equals(object obj)
            {
                return base.Equals(obj);
            }

            // Перевод в int.

            public int CompareTo(Cage compareCage)
            {
                if (compareCage == null)
                    return 1;

                else
                    return this.Type.CompareTo(compareCage.Type);
            }
            public int CompareToInt(Cage compareCage)
            {
                if (compareCage == null)
                    return 1;

                else
                    return this.Height.CompareTo(compareCage.Height);
            }
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
        }
        internal class CageCollection : ICollection<Cage>
        {
            public IEnumerator<Cage> GetEnumerator()
            {
                return new CageEnumerator(this);
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return new CageEnumerator(this);
            }
            private List<Cage> innerCol;

            public CageCollection()
            {
                innerCol = new List<Cage>();
            }

            public Cage this[int index]
            {
                get { return (Cage)innerCol[index]; }
                set { innerCol[index] = value; }
            }
            public bool Contains(Cage item)
            {
                bool found = false;

                foreach (Cage cg in innerCol)
                {
                    if (cg.Equals(item))
                    {
                        found = true;
                    }
                }

                return found;
            }
            public bool Contains(Cage item, EqualityComparer<Cage> comp)
            {
                bool found = false;

                foreach (Cage cg in innerCol)
                {
                    if (comp.Equals(cg, item))
                    {
                        found = true;
                    }
                }

                return found;
            }
            public void Add(Cage item)
            {

                if (!Contains(item))
                {
                    innerCol.Add(item);
                }
                else
                {
                    Console.WriteLine("Клетка с размерами {0}x{1}x{2} уже добавлена в коллекцию.",
                        item.Height.ToString(), item.Length.ToString(), item.Width.ToString());
                }
            }

            public void Clear()
            {
                innerCol.Clear();
            }

            public void CopyTo(Cage[] array, int arrayIndex)
            {
                if (array == null)
                    throw new ArgumentNullException("Массив не может быть пустым");
                if (arrayIndex < 0)
                    throw new ArgumentOutOfRangeException("Начало массива не может быть отрицательным.");
                if (Count > array.Length - arrayIndex)
                    throw new ArgumentException("Массив содержит меньше элементов, чем коллекция");

                for (int i = 0; i < innerCol.Count; i++)
                {
                    array[i + arrayIndex] = innerCol[i];
                }
            }

            public int Count
            {
                get
                {
                    return innerCol.Count;
                }
            }

            public bool IsReadOnly
            {
                get { return false; }
            }

        public bool Remove(Cage item)
            {
                bool result = false;
                for (int i = 0; i < innerCol.Count; i++)
                {

                    Cage curBox = (Cage)innerCol[i];
                }
                return result;
            }

            // Использование класса Func();

            public int Size(Cage item)
            {
                Func<int, int, int, int> result = (a, b, c) => a * b * c;
                return result(item.Height, item.Length, item.Width);
            }

            // Сортировка

            public bool Sort()
            {
                bool result = false;
                innerCol.Sort();
                return result;
            }
        }
        internal class MyCageCollection : CageCollection
        {
            public MyCageCollection()
            {
            }
        }
        public class CageEnumerator : IEnumerator<Cage>
        {
            private CageCollection _collection;
            private int curIndex;
            private Cage curCage;

            internal CageEnumerator(CageCollection collection)
            {
                _collection = collection;
                curIndex = -1;
                curCage = default(Cage);
            }

            public bool MoveNext()
            {
                if (++curIndex >= _collection.Count)
                {
                    return false;
                }
                else
                {
                    curCage = _collection[curIndex];
                }
                return true;
            }

            public void Reset() { curIndex = -1; }

            void IDisposable.Dispose() { }

            internal Cage Current
            {
                get { return curCage; }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

        Cage IEnumerator<Cage>.Current => throw new NotImplementedException();
    }
    
}
