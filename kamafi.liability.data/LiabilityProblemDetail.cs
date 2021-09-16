using System.Collections.Generic;

namespace kamafi.liability.data
{
    public class LiabilityProblemDetail : ILiabilityProblemDetail
    {
        public int? Code { get; set; }
        public string Message { get; set; }
        public string TraceId { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }

    public class LiabilityProblemDetailBase : ILiabilityProblemDetailBase
    {
        public int? Code { get; set; }
        public string Message { get; set; }
    }
}