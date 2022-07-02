﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ShoppingApp.Application.RequestParameters;

namespace ShoppingApp.Application.Features.Queries.Product.GetAllProduct
{
    public class GetAllProductQueryRequest :IRequest<GetAllProductQueryResponse>
    {
        //public Pagination pagination { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
