using System;
using System.Collections.Generic;
using System.Text;

namespace Banking
{
    public class SavingsAccount
    {
        protected double interestRate;
        protected string owner;
        protected decimal balance;

        public SavingsAccount(string o, decimal b, double ir)  //constructor with initial balance. But I disregarded its existance 
        {
            this.interestRate = ir;
            this.owner = o;
            this.balance = b;
        }

        public SavingsAccount(string o, double ir) :  //the constructor I usually use
          this(o, 0.0M, ir)
        {
        }

        public virtual decimal Balance  //Ah yes, the Balance is made out of balance
        {
            get { return balance; }
        }

        public virtual void Withdraw(decimal amount) //self explanatory
        {
            balance -= amount;
        }

        public virtual void Deposit(decimal amount)//this one as well
        {
            balance += amount;
        }

        public virtual void AddInterests() //yes
        {
            
            balance += balance * (Decimal)interestRate;
        }

        public override string ToString()//indeed
        {
            return owner + "'s account holds " 
                  + balance + " Dollares";
        }
        

    }
    public class CDAccount : SavingsAccount
    {

        public CDAccount(string o, double ir) :
          base(o, 0.0M, ir)
        {
        }

        public CDAccount(string o, decimal b, double ir) :
          base(o, b, ir)
        {
        }

        public override void Withdraw(decimal amount)  //functions overriden
        {
            if (amount < balance) // just in case
                balance -= amount;
            else
                throw new Exception("Cannot withdraw");
        }

        public override void AddInterests()
        {
            balance = balance + balance * (decimal)interestRate //because that is how percents work
                              / 100.0M;
        }

        public override string ToString()
        {
            return owner + "'s savings account holds " +
                  +balance + " Dollares";
        }
        
    }
    
}
