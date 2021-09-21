using System;

namespace kamafi.liability.data
{
    public class LiabilityVehicle : Liability
    {
        public decimal? DownPayment { get; set; }
    }

    public class LiabilityVehicleDto : LiabilityDto
    {
        public decimal? DownPayment { get; set; }
    }
}