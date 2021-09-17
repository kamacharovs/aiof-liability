using System;

namespace kamafi.liability.data
{
    public interface ITenant
    {
        int UserId { get; set; }
        string Log { get; }
    }
}