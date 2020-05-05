using System;
using AutoMapper;
using InstantPOS.Application.Common.ExtensionMethods;
using InstantPOS.Application.Mappings;
using InstantPOS.Domain.Entities;
using InstantPOS.Domain.Enums;

namespace InstantPOS.Application.DTOs
{
    public class ProductTypeDto : IMapFrom<ProductType>
    {
        public Guid ProductTypeId { get; set; }
        public string ProductTypeKey { get; set; }
        public string ProductTypeName { get; set; }
        public RecordStatusPropertyDto RecordStatusDto { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProductType, ProductTypeDto>()
                .ForPath(d => d.RecordStatusDto.Status, opt => opt.MapFrom(s => (int)s.RecordStatus))
                 //.ForPath(d => d.RecordStatusDto.StatusName, opt => opt.MapFrom(s => Enum.GetName(typeof(RecordStatus), (int)s.RecordStatus)));
                .ForPath(d => d.RecordStatusDto.StatusName, opt => opt.MapFrom(s => s.RecordStatus.GetDescription<RecordStatus>()));
        }
    }
}
