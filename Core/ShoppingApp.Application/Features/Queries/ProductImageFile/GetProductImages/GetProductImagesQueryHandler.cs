﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShoppingApp.Application.Repositories.Product;
using P=ShoppingApp.Domain.Entities;
using I=ShoppingApp.Domain.Entities.File;

namespace ShoppingApp.Application.Features.Queries.ProductImageFile.GetProductImages;

public class GetProductImagesQueryHandler:IRequestHandler<GetProductImagesQueryRequest,List<GetProductImagesQueryResponse>>
{
    readonly IProductReadRepository _productReadRepository;
    readonly IConfiguration _configuration;

    public GetProductImagesQueryHandler(IProductReadRepository productReadRepository, IConfiguration configuration)
    {
        _productReadRepository = productReadRepository;
        _configuration = configuration;
    }

    public async Task<List<GetProductImagesQueryResponse>> Handle(GetProductImagesQueryRequest request, CancellationToken cancellationToken)
    {
        P.Product? product = await _productReadRepository.Table.Include(p => p.ProductImageFiles)
            .FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id!), cancellationToken: cancellationToken);

             

        return product?.ProductImageFiles!.Select(p => new GetProductImagesQueryResponse
        {
            Path = $"{_configuration["Storage:Azure:BaseUrl"]}/{p.Path}",
            FileName = p.FileName,
            Id = p.Id
        }).ToList() ?? throw new InvalidOperationException();
    }
}