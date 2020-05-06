using System;
using AutoMapper;
using InstantPOS.Application.Mappings;
using MediatR;

namespace InstantPOS.Application.CQRS.ProductType.Command
{
    public class UpdateProductTypeCommand : IRequest<bool>, IMapFrom<Domain.Entities.ProductType>
    {
        public Guid ProductTypeId { get; set; }
        public string ProductTypeKey { get; set; }
        public string ProductTypeName { get; set; }
        public int RecordStatus { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateProductTypeCommand, Domain.Entities.ProductType>()
                .ForMember(d => d.RecordStatus, opt => opt.MapFrom(s => (int)s.RecordStatus));

        }
    }
}
