using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOS_CaseStudy
{
    public partial class Transfer
    {
        public Account FromAccount { get; set; }
        public Account ToAccount { get; set; }
        public string userGivenPin { get; set; }
        public double Amount { get; set; }
        public TransferMode transferMode { get; set; }

        public bool MakeTransaction()
        {
            if (!FromAccount.IsActive)
                throw new AccountAlreadyClosedException($"Account number {FromAccount.accNo} is closed");
            if(!ToAccount.IsActive)
                throw new AccountAlreadyClosedException($"Account number {ToAccount.accNo} is closed");

            if (Amount >= 100000)
            {
                throw new TransactionCannotBeCompletedException("Amount about allowed limit");
            }
            else if (Amount > 50000)
            {
                if (FromAccount.privelage != Account.Privelage.PREMIUM)
                    throw new TransactionCannotBeCompletedException("Amount above allowed limit");
            }
            else if (Amount > 25000)
            {
                if (FromAccount.privelage != Account.Privelage.GOLD)
                    throw new TransactionCannotBeCompletedException("Amount above allowed limit");
            }
            else if(Amount<=0)
            {
                //if (FromAccount.privelage != Account.Privelage.SILVER)
                throw new InvalidAmountException("Amount cannot be zero or less");
            }

            FromAccount.Withdraw(Amount,userGivenPin);
            ToAccount.Deposit(Amount);
            Console.WriteLine("Transaction is complete");
            Console.WriteLine($"Sender's balance: {FromAccount.Balance}");
            Console.WriteLine($"Receiver's balance: {ToAccount.Balance}");

            return true;

        }

    }
}
