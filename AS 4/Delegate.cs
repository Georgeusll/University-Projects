using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace COMPE361
{
    class Set<T> :IEnumerable
    {

        public delegate bool D<T>(T item);  //declare the delegate 
        protected IEnumerable<T> set { get; set; }

       
         public IEnumerable<T> myList { get; set; }
        private IEnumerable<T> presence { get; set; }



        public Set()
        {
        }
        public Set(IEnumerable<T> e)
        {

            set = e.ToList();   //create a set(array) of any data type that the user provided
          
            D<T> FilterFunc = new D<T>(Filter);  //using the depegate we direct the program to the filter function 


            this.set = Filter(FilterFunc).set;      //after the filtration is complete we set the contents of our set to the resulting set.



        }




        public bool Filter(T e) 
        {
            bool Value = true;

            if (presence == null)   // we check if the array exists. If it is empty then we can go ahead and add the item we need               
       
                presence = ( new[ ] { e }); //adding the item

            else                                                
            {
                //we check each element if our list. If we have the matching item, we don't add it
                if (presence.Contains(e))

                    Value = false;

                else
                    //but if it does not, we add it at the end of the list
                presence = presence.Concat(new[] { e });
            }
            return Value;                                      
        }



        public static Set<T> operator +(Set<T> lhs, Set<T> rhs)
        {
            Set<T> mix;                                 //take first list and put the other one at the end of it

            IEnumerable<T> join = lhs.set.Concat(rhs.set);     //pretty gay way of adding 2 lists but it is what it is.

            mix = new Set<T>(join);   //put the resulting list into new list,
            return (mix);              //and then return it

        }
        public virtual bool Add(T item)
        {
            bool difference = true;

            foreach (var i in set)                        
            {

                //go through every item and compare it to the other one

                if (i.Equals(item)) //if it finds the object, then difference will be set to false
                {
                    difference = false;

                    break;
                }
            }
            if (difference == true) //resulting in the similar item not getting added
            {
                set = set.Concat(new[] { item });  //otherwise, it gets added
                return true;
            }

            else return false;

        }

        public virtual bool Remove(T item)
        {
            bool difference = false;
            foreach (var i in set)                                            
            {
                if (i.Equals(item)) //The logic here is exactly same as in Add function
                {
                    difference = true;

                    break;
                }
            }
            if (difference)
            {
                set = set.Where(i => !i.Equals(item)).ToList(); //although we create yet another list but with that exact item NOT included

                return true;
            }
            else return false;
        }
        public bool Contains(T item)
        {
            if(set.Contains(item) == true)  //self explanatory: if the list contains any item it return true
            {
                return true;
            }
            else
            return false ;          
        }

        public int Count
        {
            get
            {
                int Counter = 0;

                using (IEnumerator<T> e = set.GetEnumerator()) //start counting objects untill we reach NULL
                {
                    while (e.MoveNext() == true) //until the next object exists...

                        Counter++;
                }
                return Counter;

            }
        }


        public Set<T> Filter(D<T> filterFunction) //oh boy
        {
            
            int first = 0;


            foreach (var i in set)                                  
            {
                    //we put the filter function on each element
                if (filterFunction(i))
                {

                    //we let the first value in because it is the first and we cannot use filter on null. I tried, did not work
                    if (first == 0)
                    {
                        myList = new[] { i };           
                        
                     
                        first++;
                    }


                    else
                    {
                        //after first element is in there we can start adding other filtered items as well
                        myList = myList.Concat(new[] { i });                                                      
                    }
                }

            }
            //finally after our list is complete
            //we put it into our original list -- set

            set = myList;                                                    

            return this;

        }


        public bool IsEmpty                                       //check if the set is empty
        {
            get
            {
                return set == null;
            }
        }



        public override string ToString()                                 //override ToString method to print the set
        {
            if (set != null)
                return String.Join(", ", set);
            else throw new NullReferenceException();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
