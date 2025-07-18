﻿using AutoMapper;
using M.Shop.Catalog.Dtos.CategoryDtos;
using M.Shop.Catalog.Dtos.ProductDetailDtos;
using M.Shop.Catalog.Dtos.ProductDtos;
using M.Shop.Catalog.Dtos.ProductImageDtos;
using M.Shop.Catalog.Entities;

namespace M.Shop.Catalog.Mapping
{
	public class GeneralMapping : Profile
	{
		public GeneralMapping()
		{

			CreateMap<Category, CreateCategoryDto>().ReverseMap();
			CreateMap<Category, UpdateCategoryDto>().ReverseMap();
			CreateMap<Category, ResultCategoryDto>().ReverseMap();

			CreateMap<Product, CreateProductDto>().ReverseMap();
			CreateMap<Product, UpdateProductDto>().ReverseMap();
			CreateMap<Product, ResultProductDto>().ReverseMap();


			CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
			CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();
			CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();

			CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
			CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();
			CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();

		}
	}
}
