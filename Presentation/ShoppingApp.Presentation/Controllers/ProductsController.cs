﻿using Microsoft.AspNetCore.Mvc;
using System.Net;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using ShoppingApp.Application.Abstractions.Services;
using ShoppingApp.Application.Features.Commands.Product.CreateProduct;
using ShoppingApp.Application.Features.Commands.Product.RemoveProduct;
using ShoppingApp.Application.Features.Commands.Product.UpdateProduct;
using ShoppingApp.Application.Features.Commands.ProductImageFile.ChangeShowcaseImage;
using ShoppingApp.Application.Features.Commands.ProductImageFile.RemoveProductImage;
using ShoppingApp.Application.Features.Commands.ProductImageFile.UploadProductImage;
using ShoppingApp.Application.Features.Queries.Product.GetAllProduct;
using ShoppingApp.Application.Features.Queries.Product.GetByIdProduct;
using ShoppingApp.Application.Features.Queries.ProductImageFile.GetProductImages;
using ShoppingApp.Application.Consts;
using ShoppingApp.Application.CustomAttributes;
using ShoppingApp.Application.Enums;

namespace ShoppingApp.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
        
    readonly IMediator _mediator;
    private readonly IProductService _productService;

    public ProductsController(
        IMediator mediator, IProductService productService)
    {
        _mediator = mediator;
        _productService = productService;
    }

    [HttpGet]
    [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Reading, Definition = "Get All Product")]
    public async Task<IActionResult> Get([FromQuery] GetAllProductQueryRequest getAllProductQueryRequest)
    {
        GetAllProductQueryResponse response = await _mediator.Send(getAllProductQueryRequest);
        return Ok(response);
    }

    [HttpGet("qr-code/{productId}")]
    [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Reading, Definition = "Get QR Code To Product")]
    public async Task<IActionResult> GetQrCodeToProduct([FromRoute] string productId)
    {
       var qrCode= await _productService.QrCodeToProductAsync(productId);
        return File(qrCode,"image/png");
    }

    [HttpGet("{Id}")]
    [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Reading, Definition = "Get By Id Product")]
    public async Task<IActionResult> Get([FromRoute] GetByIdProductQueryRequest getByIdProductQueryRequest)
    {
        GetByIdProductQueryResponse response = await _mediator.Send(getByIdProductQueryRequest);
        return Ok(response);
    }


    [HttpPost]
    [Authorize(AuthenticationSchemes = "Admin")]
    [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Writing, Definition = "Create Product")]
    public async Task<IActionResult> Post(CreateProductCommandRequest createProductCommandRequest)
    {
        CreateProductCommandResponse response = await _mediator.Send(createProductCommandRequest);

        return StatusCode((int)HttpStatusCode.Created);
    }


    [HttpPut]
    [Authorize(AuthenticationSchemes = "Admin")]
    [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Updating, Definition = "Update Product")]
    public async Task<IActionResult> Put([FromBody] UpdateProductCommandRequest updateProductCommandRequest)
    {

        UpdateProductCommandResponse response = await _mediator.Send(updateProductCommandRequest);

        return Ok();
    }


    [HttpDelete("{Id}")]
    [Authorize(AuthenticationSchemes = "Admin")]
    [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Deleting, Definition = "Delete Product")]
    public async Task<IActionResult> Delete([FromRoute] RemoveProductCommandRequest removeProductCommandRequest)
    {
        RemoveProductCommandResponse response = await _mediator.Send(removeProductCommandRequest);
        return Ok();
    }



    [HttpPost("[action]")]
    [Authorize(AuthenticationSchemes = "Admin")]
    [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Writing, Definition = "Upload Product File")]
    public async Task<IActionResult> Upload([FromQuery] UploadProductImageCommandRequest uploadProductImageCommandRequest)
    {
        uploadProductImageCommandRequest.Files = Request.Form.Files;

        UploadProductImageCommandResponse response = await _mediator.Send(uploadProductImageCommandRequest);

        return Ok();
    }



    [HttpGet("[action]/{id}")]
    [Authorize(AuthenticationSchemes = "Admin")]
    [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Reading, Definition = "Get Product Images")]
    public async Task<IActionResult> GetProductImages([FromRoute] GetProductImagesQueryRequest getProductImagesQueryRequest)
    {
        List<GetProductImagesQueryResponse> response = await _mediator.Send(getProductImagesQueryRequest);
        return Ok(response);

    }

    [HttpDelete("[action]/{Id}")]
    [Authorize(AuthenticationSchemes = "Admin")]
    [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Deleting, Definition = "Delete Product Image")]
    public async Task<IActionResult> DeleteProductImage([FromRoute] RemoveProductImageCommandRequest removeProductImageCommandRequest, [FromQuery] string imageId)
    {
        removeProductImageCommandRequest.ImageId = imageId;

        RemoveProductImageCommandResponse response = await _mediator.Send(removeProductImageCommandRequest);

        return Ok();
    }

    [HttpPut("[action]")]
    [Authorize(AuthenticationSchemes = "Admin")]
    [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Updating, Definition = "Change Showcase Image")]
    public async Task<IActionResult> ChangeShowcaseImage([FromQuery] ChangeShowcaseImageCommandRequest changeShowcaseImageCommandRequest)
    {
        ChangeShowcaseImageCommandResponse response = await _mediator.Send(changeShowcaseImageCommandRequest);
        return Ok(response);
    }

}