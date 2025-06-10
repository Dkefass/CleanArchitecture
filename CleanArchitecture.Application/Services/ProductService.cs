using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interface;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infrastructure.Data;

namespace CleanArchitecture.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService( IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            
        }
        public async Task AddAsync(CreateProductDto product)
        {
            await _productRepository.AddAsync(_mapper.Map<Product>(product));
        }

        public async Task DeleteAsync(int id)
        {
            await _productRepository.DeleteAsync(id);    
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            return  _mapper.Map<List<ProductDto>>(await _productRepository.GetAllAsync());
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            return _mapper.Map<ProductDto>(await _productRepository.GetByIdAsync(id));
        }

        public async Task UpdateAsync(UpdateProductDto product)
        {
            await _productRepository.UpdateAsync(_mapper.Map<Product>(product));    
        }
    }
}
