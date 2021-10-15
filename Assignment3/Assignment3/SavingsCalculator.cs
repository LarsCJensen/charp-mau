using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class SavingsCalculator
    {
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
            set { growth = value; }
        }

        private double fees = 0;
        public double Fees
        {
            get { return fees; }
            set { fees = value; }
        }
        private double totalFees = 0;
        public double TotalFees
        {
            get { return totalFees;  }
            set { totalFees = value; }
        }
        public double calculateFinalBalance()
        {
            int months = period * 12;
            double balance = initialDeposit;
            double interestEarned = 0;
            double expence = 0;
            // Chose to go with yearly fee of balance which is divided by 12 to get monthly
            double monthlyFee = fees / 12;

            // I like naming the variables more explicitly
            for(int month = 1; month < months +1 ; month++)
            {
                expence = balance * monthlyFee;
                balance -= expence;
                totalFees += expence;

                interestEarned = (growth / 12) * balance;
                balance += interestEarned + monthlyDeposit;
            }
            
            return balance;
        }

        public double calculateAmountPaid()
        {
            return initialDeposit + (monthlyDeposit * (period * 12));
        }
        
        public double calculateAmountEarned()
        {
            // Instead of calculating it again, the result of both calculations could be set as class attributes instead.
            return calculateFinalBalance() - calculateAmountPaid();
        }

    }
}
