using System;

namespace kamafi.liability.data
{
    public class Liability
    {
        public int Id { get; set; }
        public Guid PublicKey { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string TypeName { get; set; }
        public LiabilityType Type { get; set; }
        public decimal Value { get; set; }
        public decimal? MonthlyPayment { get; set; }
        public int? Years { get; set; }
        public int UserId { get; set; }
        public bool IsDeleted { get; set; } = false;
    }

    public class LiabilityDto
    {
        public string Name { get; set; }
        public string TypeName { get; set; }
        public decimal? Value { get; set; }
        public decimal? MonthlyPayment { get; set; }
        public int? Years { get; set; }
    }
}