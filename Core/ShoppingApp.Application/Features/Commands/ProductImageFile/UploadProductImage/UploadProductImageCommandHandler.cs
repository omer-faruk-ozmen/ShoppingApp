using MediatR;
using ShoppingApp.Application.Abstractions.Storage;
using ShoppingApp.Application.Repositories.File.ProductImageFile;
using ShoppingApp.Application.Repositories.Product;
using P= ShoppingApp.Domain.Entities;

namespace ShoppingApp.Application.Features.Commands.ProductImageFile.UploadProductImage;

public class UploadProductImageCommandHandler:IRequestHandler<UploadProductImageCommandRequest,UploadProductImageCommandResponse>
{
    readonly IProductImageFileWriteRepository _productImageFileWriteRepository;
    readonly IProductReadRepository _productReadRepository;
    private readonly IStorageService _storageService;

    public UploadProductImageCommandHandler(IProductImageFileWriteRepository productImageFileWriteRepository, IStorageService storageService, IProductReadRepository productReadRepository)
    {
        _productImageFileWriteRepository = productImageFileWriteRepository;
        _storageService = storageService;
        _productReadRepository = productReadRepository;
    }

    public async Task<UploadProductImageCommandResponse> Handle(UploadProductImageCommandRequest request, CancellationToken cancellationToken)
    {
        List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("photo-images", request.Files!);

        P.Product? product = await _productReadRepository.GetByIdAsync(request.Id!);


        //second way
        //foreach (var r in result)
        //{
        //    product.ProductImageFiles.Add(new()
        //    {
        //        FileName = r.fileName,
        //        Path = r.pathOrContainerName,
        //        Storage = _storageService.StorageName,
        //        Products = new List<Product>() { product }
        //    });
        //}

        await _productImageFileWriteRepository.AddRangeAsync(result.Select(r => new Domain.Entities.File.ProductImageFile
        {
            FileName = r.fileName,
            Path = r.pathOrContainerName,
            Storage = _storageService.StorageName,
            Products = new List<P.Product>() { product! }
        }).ToList());

        await _productImageFileWriteRepository.SaveAsync();

        return new();
    }
}