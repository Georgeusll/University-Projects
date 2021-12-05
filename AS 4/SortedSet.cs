using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMPE361
{
    class SortedSet<T> : Set<T>, IComparable
    {
        private new IEnumerable<T> set { get; set; }
        public SortedSet() : base() { }
        public SortedSet(IEnumerable<T> e)
        {


            set = (from i in e    

                   let value = i.ToString() //enter the numbers in the list
                   //by using linQ we sort the list
  //TAKING INTO CONSIDERATION THAT THE OBJECTS HERE ARE COMPARABLE, IT WORKS
                   orderby value ascending 


                   select i).Distinct();

                    }

        public new int Count                                         //count numberv of items in the set
        {
            get
            {
                int value = 0;
                using (IEnumerator<T> e = set.GetEnumerator())
                {
                    while (e.MoveNext())
                        value++;
                }
                return value;
            }
        }
        public new bool IsEmpty                                 //check if the set is empty
        {
            get
            {
                return set.Count() == 0;
            }
        }

        public int CompareTo(Object obj)                               //CompareTo method to compare objects
        {
            SortedSet<T> other = obj as SortedSet<T>;
            return this.CompareTo(other);

            throw new NotImplementedException();
        }

        public static SortedSet<T> operator +(SortedSet<T> lhs, SortedSet<T> rhs)               //method to concatinate sets nd sort the
        {
            
            SortedSet<T> mix;

            IEnumerable<T> sum = lhs.set.Concat(rhs.set);
            mix = new SortedSet<T>(sum);
            return (mix);
        }



        public override bool Add(T item)                                     
        {
            base.set = this.set;

            bool b = base.Add(item);

            this.set = base.set; //using the INHERITANCE we add the element in the list 

            set = from i in set //and then sort it
                  orderby i
                  select i;

            return b;
        }
        public override bool Remove(T item)       //doing the same                             
        {
            base.set = this.set;

            bool b = base.Remove(item);

            this.set = base.set;

            set = from i in set
                  orderby i
                  select i;
            return b;
        }
        public override string ToString()              
        {
            if (set != null)
            {
                return String.Join(", ", set);
            }
            else throw new NullReferenceException();
        }

    }
}
