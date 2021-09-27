using System;

namespace kamafi.liability.data
{
    public class Loan : Liability
    {
        public string LoanType { get; set; }
        public decimal? Interest { get; set; }
    }

    public class LoanDto : LiabilityDto
    {
        public string LoanType { get; set; }
        public decimal? Interest { get; set; }
    }
}