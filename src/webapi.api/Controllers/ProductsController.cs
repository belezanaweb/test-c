using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webapi.application.Models;
using webapi.application.Models.Comum;
using webapi.application.UseCases;

namespace webapi.api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ILogger<ProductsController> logger;

    private readonly IUseCase<CreateProductRequest, CreateProductResponse> createProductUseCase;
    private readonly IUseCase<GetProductRequest, ProductResponse> getProductUseCase;
    private readonly IUseCase<UpdateProductRequest, ProductResponse> updateProductUseCase;
    private readonly IUseCase<DeleteProductRequest, DeleteProductResponse> deleteProductUseCase;

    public ProductsController(IUseCase<CreateProductRequest, CreateProductResponse> createProductUseCase,
                             IUseCase<GetProductRequest, ProductResponse> getProductUseCase,
                             IUseCase<UpdateProductRequest, ProductResponse> updateProductUseCase,
                             IUseCase<DeleteProductRequest, DeleteProductResponse> deleteProductUseCase,
        ILogger<ProductsController> logger,
        IMapper mapper)
    {
        this.deleteProductUseCase = deleteProductUseCase;
        this.getProductUseCase = getProductUseCase;
        this.updateProductUseCase = updateProductUseCase;
        this.createProductUseCase = createProductUseCase;
        this.logger = logger;
    }

    [HttpPost]
    public async Task<ActionResult> Post(CreateProductRequest CreateProductRequest)
    {
        var response = await createProductUseCase.Execute(CreateProductRequest);
        if (response.IsValid)
            return Ok();

        return BadRequest(response.ErrorMessage);
    }

    [HttpPut]
    public async Task<IActionResult> Put(UpdateProductRequest request)
    {
        var response = await updateProductUseCase.Execute(request);
        if (response.IsValid)
            return Ok(response);

        return BadRequest(response.ErrorMessage);
    }

    [HttpDelete("{sku}")]
    public async Task<IActionResult> Delete(int sku)
    {
        var response = await deleteProductUseCase.Execute(new DeleteProductRequest { sku = sku });
        if (response.IsValid)
            return Ok();

        return BadRequest(response.ErrorMessage);
    }


    [HttpGet("{sku}")]
    public async Task<IActionResult> Get(int sku)
    {
        var response = await getProductUseCase.Execute(new GetProductRequest { sku = sku });
        if (response.IsValid)
            return Ok(response);

        return BadRequest(response.ErrorMessage);
    }
}
