using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerApp.Core.DTOs;
using NLayerApp.Core.Model;
using NLayerApp.Core.Services;

namespace NLayerApp.API.Controllers
{
    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;

        private readonly IService<Product> _service;
        private readonly IProductService _productService;
        public ProductsController(IMapper mapper, IService<Product> service, IProductService productService)
        {
            _mapper = mapper;
            _service = service;
            _productService = productService;
        }

        // GET : api/products
        [HttpGet]
        public async Task<IActionResult> All() {
            var products = await _service.GetAllAsync();
            var productsDto = _mapper.Map<List<ProductDto>>(products.ToList());

            //return Ok(CustomResponseDto<List<ProductDto>>.Success(200, productsDtos));
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productsDto));
        }

        // GET : api/products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) {

            var product = await _service.GetByIdAsync(id);

            // Bu kontrolü ileride daha genel bir yerde yapacağız.
            if (product == null)
            {
                CreateActionResult(CustomResponseDto<NoContentDto>.Fail(404, "Bu id'ye sahip ürün bulunamadı"));
            }

            var productDto = _mapper.Map<ProductDto>(product);

            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var product = await _service.AddAsync(_mapper.Map<Product>(productDto));
            var productsDto = _mapper.Map<ProductDto>(product);

            return CreateActionResult(CustomResponseDto<ProductDto>.Success(201, productsDto));
            // 201 : Oluşturuldu anlamında kullanılır. İşlem başarılı ise 201 döndürülebilir.
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto)
        {
            await _service.UpdateAsync(_mapper.Map<Product>(productUpdateDto));
            
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        // DELETE : api/products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _service.GetByIdAsync(id);
            
            // Bu kontrolü ileride daha genel bir yerde yapacağız.
            if (product == null)
            {
                CreateActionResult(CustomResponseDto<NoContentDto>.Fail(404, "Bu id'ye sahip ürün bulunamadı"));
            }

            await _service.RemoveAsync(product);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        // GET : api/products/GetProductsWithCategory
        //[HttpGet("GetProductsWithCategory")]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductsWithCategory() {
            return CreateActionResult(await _productService.GetProductWithCategory());
        }


    }
}
