﻿using MediatR;
using ShoppingApp.Application.Repositories.Product;
using Microsoft.EntityFrameworkCore;

namespace ShoppingApp.Application.Features.Queries.Product.GetAllProduct;

public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
{
    readonly IProductReadRepository _productReadRepository;
    public GetAllProductQueryHandler(IProductReadRepository productReadRepository)
    {
        _productReadRepository = productReadRepository;
    }


    public async Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
    {

        var totalProductCount = _productReadRepository.GetAll(false).Count();
        var products = _productReadRepository
            .GetAll(false)
            .Skip(request.Page * request.Size)
            .Take(request.Size)
            .Include(p=>p.ProductImageFiles)
            .Select(p => new
            {
                p.Id,
                p.Name,
                p.Stock,
                p.Price,
                p.CreatedDate,
                p.UpdatedDate,
                p.ProductImageFiles
            }).ToList();

        return new()
        {
            Products = products,
            TotalProductCount = totalProductCount
        };
    }
}