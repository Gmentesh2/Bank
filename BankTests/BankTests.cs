using BankAccountNS;
namespace BankTests
{
    [TestClass]
    public sealed class BankTests
    {
        [TestMethod]
        public void Debit_WithValidAmoout_UpdatesBalance()
        {
            // Arrange
            double initialBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", initialBalance);

            // Act
            account.Debit(debitAmount);

            // Assert
            double actualBalance = account.Balance;
            Assert.AreEqual(expected, actualBalance, 0.001, "Debit method does not update balance correctly.");
        }
        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRangeException()
        {
            // Arrange
            double initialBalance = 11.99;
            double debitAmount = -1.0;
            BankAccount account = new BankAccount("Mr. Bryan Walton", initialBalance);

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }

        [TestMethod]
        public void Debit_WhenAmountExceedsBalance_ShouldThrowArgumentOutOfRangeException()
        {
            // Arrange
            double initialBalance = 11.99;
            double debitAmount = 12.0;
            BankAccount account = new BankAccount("Mr. Bryan Walton", initialBalance);
            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }
    }
}
