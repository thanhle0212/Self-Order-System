using System;
using AutoMapper;
using InstantPOS.Application.Mappings;
using MediatR;

namespace InstantPOS.Application.CQRS.ProductType.Command
{
    public class CreateProductTypeCommand : IRequest<bool>, IMapFrom<InstantPOS.Domain.Entities.ProductType>
    {
        public string ProductTypeKey { get; set; }
        public string ProductTypeName { get; set; }
        public int RecordStatus { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProductTypeCommand, InstantPOS.Domain.Entities.ProductType>()
                .ForMember(d => d.RecordStatus, opt => opt.MapFrom(s => (int)s.RecordStatus));

        }
    }
}
