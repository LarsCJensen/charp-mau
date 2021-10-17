/*
 * Lars Jensen
 * 2021-10-15
 * I chose to use yearly fees which is taken from the balance. It seems to be a often used model
 * */
namespace Assignment3
{
    /// <summary>
    /// Class <c>SavingsCalculator</c> calculates savings based on user input.
    /// </summary>
    class SavingsCalculator
    {
        /**
         * Class for SavingsCalculator
         * */
        private double monthlyDeposit = 0;
        public double MonthlyDeposit
        {
            get { return monthlyDeposit; }
            set { monthlyDeposit = value; }
        }
        private int period = 0;
        public int Period
        {
            get { return period; }
            set { period = value; }
        }

        private int initialDeposit = 0;
        public int InitialDeposit
        {
            get { return initialDeposit; }
            set { initialDeposit = value; }
        }

        // Default of 10%
        private double growth = 0.10;
        public double Growth
        {
            get { return growth; }
            set { growth = value / 100; } // Since it says "in percent" I want the user to add percent, which I then divide by 100 
        }

        private double fees = 0;
        public double Fees
        {
            get { return fees; }
            set { fees = value / 100; } // dividing whole percent to decimal  
        }
        private double totalFees = 0;
        public double TotalFees
        {
            get { return totalFees;  }
            set { totalFees = value; }
        }
        
        /// <summary>
        /// method <c>CalculateFinalBalance</c> calculates final balance based on user input
        /// </summary>
        /// <returns></returns>
        public double calculateFinalBalance()        {
            
            int months = period * 12;
            double balance = initialDeposit;
            double interestEarned = 0;
            double expence = 0;
            // I chose to go with yearly fee of balance which is divided by 12 to get monthly
            double monthlyFee = fees / 12;

            // I like naming the variables more explicitly
            // Start with month 1, but also want to get interest from the last month, hence +1
            for(int month = 1; month < months + 1 ; month++)
            {
                expence = balance * monthlyFee;
                balance -= expence;
                totalFees += expence;

                interestEarned = balance * (growth / 12);
                balance += interestEarned + monthlyDeposit;
            }
            
            return balance;
        }
        /// <summary>
        /// method <c>calculateAmountPaid</c> calculates the sum of all deposites.
        /// </summary>
        /// <returns></returns>
        public double calculateAmountPaid()
        {
            return initialDeposit + (monthlyDeposit * (period * 12));
        }

        /// <summary>
        /// method <c>calculateAmountEarned</c> the amount earned based on amount paid and final balance
        /// (Perhaps overkill to have a helper method for this, but MainForm should not have logic to calculate)
        /// </summary>
        /// <param name="amountPaid">Amount paid</param>
        /// <param name="finalBalance">Final balance</param>
        /// <returns></returns>
        public double calculateAmountEarned(double amountPaid, double finalBalance)
        {   
            // Calculcate amount earned
            return finalBalance - amountPaid;
        }

    }
}
