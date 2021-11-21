using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOS_CaseStudy
{
    public delegate void AlertDelegate(string msg);
    
    public abstract partial class Account
    {
        public event AlertDelegate AlertNotify = new AlertDelegate(Alert.Mail);
        public string accNo { get; private set; } = AccountNumberGenerate.AccountNo().ToString();
        public string Name { get; set; }
        public string pin { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateActive { get; set; }
        public DateTime DateClosed { get; set; }
        public double Balance { get; protected set; }

        public Privelage privelage { get; set; }

        abstract public bool Open();

        public bool Close()
        {
            if (!IsActive)
                throw new AccountAlreadyClosedException($"This account {accNo} is already closed");
            IsActive = false;
            DateClosed = DateTime.Now.Date;
            return true;
        }

        public bool Deposit(double amt)
        {
            if (!IsActive)
                throw new AccountAlreadyClosedException($"This account {accNo} is closed.Cannot complete transaction!!!");
            if (amt <= 0)
                throw new InvalidAmountException("Amount cannot be zero or less than zero");
            Balance += amt;
            //Console.WriteLine("Amount added successfully");
            //Console.WriteLine($"Available balance is: {Balance}");
            AlertNotify($"{amt} has been deopsited to {accNo}");

            return true;
        }
        
        public bool Withdraw(double amt,string PinNumber)
        {
            if (!IsActive)
                throw new AccountAlreadyClosedException($"This account {accNo} is closed.Cannot complete transaction!!!");
            if (amt > Balance)
                throw new NotEnoughBalanceException("Not enough balance.Cannot complete transaction");
            if(pin!=PinNumber)
                throw new PinNotMatchedExceptin("Pin didn't matched");
            Balance -= amt;
            //Console.WriteLine("Transaction complete");
            //Console.WriteLine($"Available Balance: {Balance}");
            AlertNotify($"{amt} has been reduced from {accNo}");

            return true;
        }
    }
}
