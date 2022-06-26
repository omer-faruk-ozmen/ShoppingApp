using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Application.Abstractions;
using ShoppingApp.Application.Repositories.Product;
using ShoppingApp.Application.ViewModels.Products;
using ShoppingApp.Domain.Entities;
using System.Net;
using ShoppingApp.Application.Repositories.File;
using ShoppingApp.Application.Repositories.File.ProductImageFile;
using ShoppingApp.Application.Repositories.FileRepositories.InvoiceFile;
using ShoppingApp.Application.RequestParameters;
using ShoppingApp.Application.Services;
using ShoppingApp.Domain.Entities.File;
using File = ShoppingApp.Domain.Entities.File.File;

namespace ShoppingApp.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;
        private readonly IFileService _fileService;
        private readonly IFileReadRepository _fileReadRepository;
        private readonly IFileWriteRepository _fileWriteRepository;
        private readonly IProductImageFileReadRepository _productImageFileReadRepository;
        private readonly IProductImageFileWriteRepository _productImageFileWriteRepository;
        private readonly IInvoiceFileReadRepository _invoiceFileReadRepository;
        private readonly IInvoiceFileWriteRepository _invoiceFileWriteRepository;

        public ProductsController(
            IProductWriteRepository productWriteRepository,
            IProductReadRepository productReadRepository,
            IFileService fileService,
            IFileReadRepository fileReadRepository,
            IFileWriteRepository fileWriteRepository,
            IProductImageFileReadRepository productImageFileReadRepository,
            IProductImageFileWriteRepository productImageFileWriteRepository,
            IInvoiceFileReadRepository invoiceFileReadRepository,
            IInvoiceFileWriteRepository invoiceFileWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _fileService = fileService;
            _fileReadRepository = fileReadRepository;
            _fileWriteRepository = fileWriteRepository;
            _productImageFileReadRepository = productImageFileReadRepository;
            _productImageFileWriteRepository = productImageFileWriteRepository;
            _invoiceFileReadRepository = invoiceFileReadRepository;
            _invoiceFileWriteRepository = invoiceFileWriteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Pagination pagination)
        {
            var totalCount = _productReadRepository.GetAll(false).Count();
            var products = _productReadRepository
                .GetAll(false)
                .Skip(pagination.Page * pagination.Size)
                .Take(pagination.Size)
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Stock,
                    p.Price,
                    p.CreatedDate,
                    p.UpdatedDate
                }).ToList();
            return Ok(new
            {
                totalCount,
                products
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(_productReadRepository.GetByIdAsync(id, false));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProductViewModel model)
        {

            await _productWriteRepository.AddAsync(new Product()
            {
                Name = model.Name,
                Stock = model.Stock,
                Price = model.Price
            });
            await _productWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateProductViewModel model)
        {


            Product product = await _productReadRepository.GetByIdAsync(model.Id);

            product.Stock = model.Stock;
            product.Price = model.Price;
            product.Name = model.Name;

            await _productWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productWriteRepository.RemoveAsync(id);
            await _productWriteRepository.SaveAsync();
            return Ok();
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Upload()
        {

            var datas = await _fileService.UploadAsync("resource/files", Request.Form.Files);
            //var datas1 = await _fileService.UploadAsync("resource/invoices", Request.Form.Files);

            await _fileWriteRepository.AddRangeAsync(datas.Select(
                d => new File()
                {
                    FileName = d.fileName,
                    Path = d.path,

                }).ToList());

            await _fileWriteRepository.SaveAsync();

            //await _productImageFileWriteRepository.AddRangeAsync(datas.Select(
            //    d => new ProductImageFile()
            //    {
            //        FileName = d.fileName,
            //        Path = d.path
            //    }).ToList());
            //await _productImageFileWriteRepository.SaveAsync();


            //await _invoiceFileWriteRepository.AddRangeAsync(datas1.Select(
            //    d => new InvoiceFile()
            //    {
            //        FileName = d.fileName,
            //        Path = d.path,
            //        Price = new Random().Next(100)

            //    }).ToList());
            //await _invoiceFileWriteRepository.SaveAsync();



            var db1 = _fileReadRepository.GetAll();
            var db2 = _invoiceFileReadRepository.GetAll();
            var db3 = _productImageFileReadRepository.GetAll();

            return Ok();
        }

    }
}
