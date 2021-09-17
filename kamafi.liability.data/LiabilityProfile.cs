using System;

using AutoMapper;

namespace kamafi.liability.data
{
    public class LiabilityProfile : Profile
    {
        public LiabilityProfile()
        {
            /*
             * Liability
             */
            CreateMap<LiabilityDto, Liability>()
                .ForMember(x => x.Name, o => o.Condition(s => s.Name != null))
                .ForMember(x => x.TypeName, o => o.Condition(s => s.TypeName != null))
                .ForMember(x => x.Value, o => o.Condition(s => s.Value.HasValue))
                .ForMember(x => x.MonthlyPayment, o => o.Condition(s => s.MonthlyPayment.HasValue))
                .ForMember(x => x.Years, o => o.Condition(s => s.Years.HasValue));
        }
    }
}