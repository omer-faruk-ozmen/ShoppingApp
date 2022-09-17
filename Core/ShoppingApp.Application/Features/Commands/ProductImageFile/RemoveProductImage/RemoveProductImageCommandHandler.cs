﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using ShoppingApp.Application.Repositories.Product;
using P = ShoppingApp.Domain.Entities;
using I = ShoppingApp.Domain.Entities.File;

namespace ShoppingApp.Application.Features.Commands.ProductImageFile.RemoveProductImage
{
    public class RemoveProductImageCommandHandler : IRequestHandler<RemoveProductImageCommandRequest, RemoveProductImageCommandResponse>
    {
        readonly IProductReadRepository _productReadRepository;
        readonly IProductWriteRepository _productWriteRepository;

        public RemoveProductImageCommandHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        public async Task<RemoveProductImageCommandResponse> Handle(RemoveProductImageCommandRequest request, CancellationToken cancellationToken)
        {
            P.Product? product = await _productReadRepository.Table.Include(p => p.ProductImageFiles)
                .FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id!), cancellationToken: cancellationToken);
            
            
            I.ProductImageFile? productImageFile = product?.ProductImageFiles!.FirstOrDefault(p => p.Id == Guid.Parse(request.ImageId!));
            
            if(productImageFile != null)
                product!.ProductImageFiles!.Remove(productImageFile);


            await _productWriteRepository.SaveAsync();

            return new();
        }
    }
}
