using InstantPOS.Application.Models.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace InstantPOS.Application.CQRS.Product.Query
{
    class GetProductQuery : IRequest<ProductResponseModel>
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }
    }
}
