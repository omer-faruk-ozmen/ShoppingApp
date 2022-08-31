using MediatR;
using Microsoft.EntityFrameworkCore;
using ShoppingApp.Application.Repositories.File.ProductImageFile;

namespace ShoppingApp.Application.Features.Commands.ProductImageFile.ChangeShowcaseImage;

public class ChangeShowcaseImageCommandHandler : IRequestHandler<ChangeShowcaseImageCommandRequest, ChangeShowcaseImageCommandResponse>
{
    private readonly IProductImageFileWriteRepository _imageFileWriteRepository;


    public ChangeShowcaseImageCommandHandler(IProductImageFileWriteRepository imageFileWriteRepository)
    {
        _imageFileWriteRepository = imageFileWriteRepository;
    }

    public async Task<ChangeShowcaseImageCommandResponse> Handle(ChangeShowcaseImageCommandRequest request, CancellationToken cancellationToken)
    {
        var query = _imageFileWriteRepository
            .Table
            .Include(p => p.Products)
            .SelectMany(p => p.Products, (pif, p) => new
            {
                pif,
                p
            });

        var data = await query
            .FirstOrDefaultAsync(p => p.p.Id == Guid.Parse(request.ProductId) && p.pif.Showcase);

        if(data!=null)
            data.pif.Showcase = false;


        var image = await query.FirstOrDefaultAsync(p => p.pif.Id == Guid.Parse(request.ImageId));

        if(image!=null)
            image.pif.Showcase = true;


        await _imageFileWriteRepository.SaveAsync();


        return new();

    }
}