using System.Collections.Generic;

namespace kamafi.liability.data
{
    public interface ILiabilityProblemDetail
    {
        int? Code { get; set; }
        string Message { get; set; }
        string TraceId { get; set; }
        IEnumerable<string> Errors { get; set; }
    }

    public interface ILiabilityProblemDetailBase
    {
        int? Code { get; set; }
        string Message { get; set; }
    }
}