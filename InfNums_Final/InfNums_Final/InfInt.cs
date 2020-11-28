using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Dynamic;
using System.Globalization;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
//Giorgi Bokhochadze 823359037
namespace InfNums_Final
{
    class InfInt: IComparable<InfInt>
    {//creating a first list to store the numbers
        public List<int> number = new List<int>();

        public bool positive = true;

        //creating a second list to store second number
        public List<int> number2 { get { return number; } set { number = value; } }    //storing the number inside the list
        public InfInt() { }
        public int CompareTo(InfInt other)
        {
           if(this.number.Count == other.number2.Count)     //if the numbers have same digits
            {
                for(int i = this.number.Count -1; i>0; i--) // and for each digit
                {
                    if (this.number[i] != other.number2[i]) //they are not the same

                    { 
                        
                        
                        if(this.number[i]>other.number2[i]) //and the number from first list is bigger 
                                {
                    return 1;     //return 1
                }
                        else {
                    return -1; //else return -1
                }
                            
                                }

                }return 0;
                
            }
           else if(this.number.Count >other.number2.Count)
            {
                return 1;
            }
            else 
                return - 1;
    
        }






        public InfInt(string String)   //creating a cunstructor, taking a value
        {
            char[] cArray = String.ToCharArray(); //creating an array

            for (int i = String.Length-1; i>= 0; i--)  //starting the count of each block
            {
                if (i == 0) //checking the last(first) digit
                {
                    if (cArray[i] == '-') //if it has a sign 
                    {
                        this.positive = false; //denote it as negative
                        //and then add it to the list
                    }
                    else 
                    {
                        number.Add(int.Parse(cArray[i].ToString())); //otherwive add it into list
                    }
                    

                }
                else
                    number.Add(int.Parse(cArray[i].ToString()));
            }
            
                       
        }
        public override string ToString() //the way of output(print) in order to output the content of the list in string
        {
            number.Reverse(); //reversing the array and populating it
            string FinalString;
            if (positive == true)
            {
                FinalString = string.Join("", number.ToArray()); //outputting positive numbers


            }
            else
            {
                FinalString = "-" + string.Join("", number.ToArray()); //outputting negative numbers
            }
            number.Reverse(); //reversing it back
            return FinalString;
        }
        
        // As I totally failed in my previous attempt for subtraction and multiplication I decided to do each operation in 2 separate ways: 
        // 1st will be the logic and the 2nd will the the process of applying it to the list.
        public List<int> LogicSum(InfInt other)
        {
            List<int> result = new List<int>();

            int num, carry=0; //creating a number that will be added and a carry, what will be added as well to the number

            int comparison = this.CompareTo(other); //identification of the bigger number

            if(comparison >= 0)   //as long as they are not the same
            {
                for(int i = 0; i<this.number.Count; i++)
                {
                    if(i< other.number2.Count) //when the sum do not exceed 10
                    {  //we take the number from first list (number) and add the number from the second list(number2) and the carry, which is 0 by the way
                        num = (this.number[i] + other.number2[i] + carry) % 10; 
                        carry = (this.number[i] + other.number2[i] + carry) / 10;

                        result.Add(num); //finally we add it in the list
                    }
                    else
                    {
                        num = (this.number[i] + carry) % 10;
                        carry = (this.number[i] + carry) / 10;
                        result.Add(num);
                    }
                }

            }
            else
            {
                for(int i = 0; i<other.number2.Count; i++) //now when the number in the second(number2) list is bigger
                {
                    if(i< this.number.Count)
                    {
                        num = (this.number[i] + other.number2[i] + carry) % 10;

                        carry = (this.number[i] + other.number2[i] + carry) / 10;

                        result.Add(num);
                    }
                    else
                    {
                        num = (this.number[i] + carry) % 10;

                        carry = (this.number[i] + carry) / 10;

                        result.Add(num);
                    }
                }
            }
            if (carry != 0)// I swear this one thing was the thing I had missing
                result.Add(carry); //if the carry is not zero, you should add it anyways. Until I added this, it  was a huge mess

            return result;
        }

        public InfInt plus (InfInt other) //we will review each case with sign and put the result in the second(number2) list
        {
            InfInt temp = new InfInt();
            //now review each case:
            //case 1: both numbers are positive
            if(this.positive && other.positive) //we surely know that no matter the number, the outcome is always positive
            {
                temp.number2 = this.LogicSum(other);    //that is why we take and summerise them together
                temp.positive = true;   //and set the sign on positive
            }
            else if(!this.positive && !other.positive)//we surely know that no matter the number, the outcome is always negative
            {
                temp.number2 = this.LogicSum(other); //two negatives are just like positives, yey.
                temp.positive = false; //we se the sign on negative to display it in the result
            }
            else if (!this.positive &&other.positive)
            {
                if (this.CompareTo(other) >= 0) //if first operand is negative and larger in number then the positive one
                {
                    temp.number2 = this.logicMinus(other);  //the number stays negative
                    temp.positive = false;
                }
                else
                {
                    temp.number2 = other.logicMinus(this);
                    temp.positive = true;
                }
            }
            return temp;
        }
       public List<int> logicMinus(InfInt other)   //creating a function for subtraction
        {
            List<int> result = new List<int>();
            if (this.CompareTo(other) == 1) //of the number of the first list is greater
            {
                List<int> firstnum = new List<int>(this.number); // we will take that number and will borrow from him the remaining numbers for carry
                for (int i = 0; i < firstnum.Count; i++)
                {
                    if (i < other.number2.Count) //if i is smaller than the count for the second list
                    {
                        if (firstnum[i] < other.number2[i]) // if the number from first list is smaller than in second and we have to borrow
                        {
                            result.Add(firstnum[i] + 10 - other.number2[i]); //we will increate the number by 10, like as borrowing is done, do the calculations


                            firstnum[i + 1] -= 1; //and decrease the previous(in this case next as we are doing everything reversed) digit by one so the borrowing thing will work
                        }
                        else
                        {
                            result.Add(firstnum[i] - other.number2[i]); //when we dont need to borrow we just subtract everything as normal as it can be
                        }
                    }
                    else
                    {
                        result.Add(firstnum[i]);
                    }
                       
                }

            }
            else if (this.CompareTo(other) == -1) //The opposite situation when the second number is greater (this repetition is tiresome)
            {
                List<int> secondnum = new List<int>(other.number2);
                for (int i = 0; i < secondnum.Count; i++)
                {
                    if (i < this.number.Count)
                    {
                        if (secondnum[i] < this.number[i]) //yet again, everything is the same but this time the number from second list is the center
                        {
                            result.Add(secondnum[i] + 10 - this.number[i]); //and the operations are happening with it and the number from first list
                            secondnum[i + 1] -= 1; //everything is the same but reversed
                        }
                        else
                            result.Add(secondnum[i] - this.number[i]);
                    }
                    else
                        result.Add(secondnum[i]);
                }



            }
            
                else //if there is no extra need we just need to add this, I dont know why it does not work without this but it is essential
                result.Add(0);

            return result;
        }

        public InfInt minus(InfInt other)
        {
            InfInt result = new InfInt(); //yet again I will work on different situations when to subtraction apply it properly
            if (this.positive &&other.positive)
            {
                if(this.CompareTo(other) >= 0)
                {
                    result.number2 = this.logicMinus(other);
                    result.positive = true;
                }
                else
                {
                    result.number2 = other.logicMinus(this);
                    result.positive = false;
                }
            }
            else if(this.positive && !other.positive)
            {
                result.number2 = this.LogicSum(other);
                result.positive = true;
            }
            else if(!this.positive && other.positive)
            {
                if(other.CompareTo(this) >= 0)
                {
                    result.number2 = other.logicMinus(this);
                    result.positive = true;
                }
                else
                {
                    result.number2 = this.logicMinus(other);
                    result.positive = false;

                }
            }
            else if (!this.positive && !other.positive)
            {
                if(other.CompareTo(this) >= 0)
                {
                    result.number2 = other.logicMinus(this);
                    result.positive = true;
                }
                else
                {
                    result.number2 = this.logicMinus(other);
                    result.positive = false;
                }
            }

                return result;
        }
       
        public List<int>MultiplicationLogic (InfInt other)
        {
            List<int> result = new List<int>();
            int carry = 0, tempNum = 0;
            int[,] anotherList = new int[other.number2.Count, this.number.Count + other.number2.Count]; //create a freaking 2 dimentional array and sum it up later on
            for (int i = 0; i< other.number2.Count; i++)
            {
                int a;
                carry = 0;
                for(a=0; a<this.number.Count; a++)
                {
                    tempNum = (this.number[a] * other.number2[a] + carry) % 10;
                    carry = (this.number[a] * other.number2[a] + carry)
/ 10; anotherList[i, i + a] = carry; //summerise it and save it in a freaking 2 dimentional array, do you even know how much time it took to get to this conclusion?!
                }
            }
            carry = 0;
            //try to sum the freaking 2 dimentional array to get the result

            for (int i = 0; i< anotherList.GetLength(1); i++)
            {
                tempNum = 0;
                for(int a=0; a<anotherList.GetLength(0);a++) //at this point I dont wan to continue
                { 
                    
                    
                    
                    
                    tempNum += anotherList[a, i];
                }
                tempNum += carry;
                carry = tempNum / 10;
                result.Add(tempNum % 10); //i just hope this will work
            }
            //if (carry != 0)
            //    result.Add(carry);


            if(result[result.Count-1]==0)//if the last digit is 0 
            {
                result.RemoveAt(result.Count - 1); //we just take and remove if for good
            }
            return result;
        }

        public InfInt mult(InfInt other)
        {
            InfInt num = new InfInt();
            num.number2 = this.MultiplicationLogic(other); //we decide to just.....set.....the final result in the second list
            //we dont need many situatios here. Just 2 of them: Signs equal--> result is positive. Signs not equal --> sign negative
            if (this.positive == other.positive)
                num.positive = true;
            else
                num.positive = false;
            return num;
            //finally now I can sleep 
        }
    }
}
