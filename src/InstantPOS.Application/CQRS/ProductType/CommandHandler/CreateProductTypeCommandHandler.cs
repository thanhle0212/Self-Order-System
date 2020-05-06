using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using InstantPOS.Application.CQRS.ProductType.Command;
using InstantPOS.Application.DatabaseServices.Interfaces;
using MediatR;

namespace InstantPOS.Application.CQRS.ProductType.CommandHandler
{
    public class CreateProductTypeCommandHandler : BaseProductTypeHandler, IRequestHandler<CreateProductTypeCommand, bool>
    {
        private readonly IMapper _mapper;
        public CreateProductTypeCommandHandler(IProductTypeDataService productTypeDataService, IMapper mapper) : base(productTypeDataService)
        {
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateProductTypeCommand createProductTypeCommandRequest, CancellationToken cancellationToken)
        {
            var request = _mapper.Map<CreateProductTypeCommand, InstantPOS.Domain.Entities.ProductType>
                (createProductTypeCommandRequest);
            var result = await base._productTypeDataService.CreateProductType(request);
            return result;
        }
    }
}
