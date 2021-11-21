using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BOS_CaseStudy;

namespace BOS_UnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DepositTest_WithActiveAccount_BalanceShouldChange()
        {
            SavingsAccount target = new SavingsAccount();
            target.IsActive = true;
            target.Deposit(1000);
            Assert.AreEqual(1000, target.Balance);
        }

        [TestMethod]
        [ExpectedException(typeof(AccountAlreadyClosedException))]
        public void DepositTest_WithInActiveAccount_ShouldThrowException()
        {
            SavingsAccount target = new SavingsAccount();
            target.IsActive = false;
            target.Deposit(1000);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAmountException))]
        public void DepositTest_WithActiveAccount_InvalidAmountException()
        {
            SavingsAccount target = new SavingsAccount();
            target.IsActive = true;
            target.Deposit(0);
            
        }

        [TestMethod]
        public void WithdrawTest_WithActiveAccount_BalanceShouldChange()
        {
            SavingsAccount target = new SavingsAccount();
            target.IsActive = true;
            target.Deposit(1000);
            target.pin = "1234";
            target.Withdraw(500,"1234");
            Assert.AreEqual(500, target.Balance);
        }

        [TestMethod]
        [ExpectedException(typeof(AccountAlreadyClosedException))]
        public void WithdrawTest_WithInActiveAccount_ShouldThrowException()
        {
            SavingsAccount target = new SavingsAccount();
            target.IsActive = false;
            target.Deposit(1000);
        }

        [TestMethod]
        [ExpectedException(typeof(NotEnoughBalanceException))]
        public void WithdrawTest_WithActiveAccount_BalanceException()
        {
            SavingsAccount target = new SavingsAccount();
            target.IsActive = true;
            //target.Deposit(1000);
            target.pin = "1234";
            target.Withdraw(500, "1234");
            //Assert.AreEqual(500, target.Balance);
        }

        [TestMethod]
        [ExpectedException(typeof(PinNotMatchedExceptin))]
        public void WithdrawTest_WithActiveAccount_PinException()
        {
            SavingsAccount target = new SavingsAccount();
            target.IsActive = true;
            target.Deposit(1000);
            target.pin = "12345";
            target.Withdraw(500, "1234");
            //Assert.AreEqual(500, target.Balance);
        }

        [TestMethod]
        public void OpenSavingsAccountTest_WithAgeAbove18_IsActiveShouldTrue()
        {
            SavingsAccount target = new SavingsAccount();
            target.dateOfBirth = DateTime.Parse("19 / 11 / 2003");
            target.Open();
            Assert.AreEqual(true, target.IsActive);
        }

        [TestMethod]
        [ExpectedException(typeof(CannotOpenAccountException))]
        public void OpenSavingsAccountTest_WithAgeBelow18_ShouldThrowException()
        {
            SavingsAccount target = new SavingsAccount();
            target.dateOfBirth = DateTime.Parse("20 / 11 / 2005");
            target.Open();
        }

        [TestMethod]
        [ExpectedException(typeof(CannotOpenAccountException))]
        public void OpenSavingsAccountTest_WithAgeBelowByOneMonth_ShouldThrowException()
        {
            SavingsAccount target = new SavingsAccount();
            target.dateOfBirth = DateTime.Parse("20 / 12 / 2003");
            target.Open();
        }

        [TestMethod]
        [ExpectedException(typeof(CannotOpenAccountException))]
        public void OpenSavingsAccountTest_WithAgeBelowByDay_ShouldThrowException()
        {
            SavingsAccount target = new SavingsAccount();
            target.dateOfBirth = DateTime.Parse("22 / 11 / 2003");
            target.Open();
        }

        [TestMethod]
        public void OpenCurrentAccount_WithRegistrationNumber_IsActiveTrue()
        {
            CurrentAccount c1 = new CurrentAccount();
            c1.registrationNo = "1234";
            c1.Open();
            Assert.AreEqual(true, c1.IsActive);
        }

        [TestMethod]
        [ExpectedException(typeof(CannotOpenAccountException))]
        public void OpenCurrentAccount_WithoutRegistrationNumber_ThrowException()
        {
            CurrentAccount c1 = new CurrentAccount();
            //c1.registrationNo = "1234";
            c1.Open();
        }

        [TestMethod]
        [ExpectedException(typeof(AccountAlreadyClosedException))]
        public void TransferTesting_SenderAccountInactive_ThrowException()
        {
            SavingsAccount s1 = new SavingsAccount();
            SavingsAccount s2 = new SavingsAccount();
            s2.Open();
            Transfer t1 = new Transfer { Amount = 20000, FromAccount = s1, ToAccount = s2, userGivenPin = "1234" };
            t1.MakeTransaction();
        }

        [TestMethod]
        [ExpectedException(typeof(AccountAlreadyClosedException))]
        public void TransferTesting_ReceiverAccountInactive_ThrowException()
        {
            SavingsAccount s1 = new SavingsAccount();
            SavingsAccount s2 = new SavingsAccount();
            s2.Open();
            Transfer t1 = new Transfer { Amount = 20000, FromAccount = s1, ToAccount = s2, userGivenPin = "1234" };
            t1.MakeTransaction();
        }

        [TestMethod]
        [ExpectedException(typeof(TransactionCannotBeCompletedException))]
        public void TransferTesting_MoreThan100000_ThrowException()
        {
            SavingsAccount s1 = new SavingsAccount();
            SavingsAccount s2 = new SavingsAccount();
            s2.Open();
            s1.Open();
            s1.pin = "1234";
            s1.Deposit(200000);
            Transfer t1 = new Transfer { Amount = 200000, FromAccount = s1, ToAccount = s2, userGivenPin = "1234" };
            t1.MakeTransaction();
        }

        [TestMethod]
        [ExpectedException(typeof(TransactionCannotBeCompletedException))]
        public void TransferTesting_MoreThan50000_ThrowException()
        {
            SavingsAccount s1 = new SavingsAccount();
            SavingsAccount s2 = new SavingsAccount();
            s2.Open();
            s1.Open();
            s1.pin = "1234";
            s1.privelage = Account.Privelage.GOLD;
            s1.Deposit(200000);
            Transfer t1 = new Transfer { Amount = 70000, FromAccount = s1, ToAccount = s2, userGivenPin = "1234" };
            t1.MakeTransaction();
        }

        [TestMethod]
        public void TransferTesting_MoreThan50000_TransactionComplete()
        {
            SavingsAccount s1 = new SavingsAccount();
            SavingsAccount s2 = new SavingsAccount();
            s2.Open();
            s1.Open();
            s1.pin = "1234";
            s1.privelage = Account.Privelage.PREMIUM;
            s1.Deposit(200000);
            Transfer t1 = new Transfer { Amount = 70000, FromAccount = s1, ToAccount = s2, userGivenPin = "1234" };
            t1.MakeTransaction();
            Assert.AreEqual(70000, s2.Balance);
        }

    }
}
