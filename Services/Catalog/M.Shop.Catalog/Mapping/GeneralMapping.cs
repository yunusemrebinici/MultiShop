using AutoMapper;
using M.Shop.Catalog.Dtos.CategoryDtos;
using M.Shop.Catalog.Dtos.FeatureDtos;
using M.Shop.Catalog.Dtos.FeatureProductDtos;
using M.Shop.Catalog.Dtos.FeatureSliderDtos;
using M.Shop.Catalog.Dtos.OfferDiscountDtos;
using M.Shop.Catalog.Dtos.ProductDetailDtos;
using M.Shop.Catalog.Dtos.ProductDtos;
using M.Shop.Catalog.Dtos.ProductImageDtos;
using M.Shop.Catalog.Dtos.SpecialOfferDtos;
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
			CreateMap<Product,ResultProductWithCategoryNameDto>().ReverseMap();


			CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
			CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();
			CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();

			CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
			CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();
			CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();

			CreateMap<FeatureSlider, CreateFeatureSliderDto>().ReverseMap();
			CreateMap<FeatureSlider, UpdateFeatureSliderDto>().ReverseMap();
			CreateMap<FeatureSlider, ResultFeatureSliderDto>().ReverseMap();

			CreateMap<SpecialOffer, CreateSpecialOfferDto>().ReverseMap();
			CreateMap<SpecialOffer, UpdateSpecialOfferDto>().ReverseMap();
			CreateMap<SpecialOffer, ResultSpecialOfferDto>().ReverseMap();

			CreateMap<Feature, CreateFeatureDto>().ReverseMap();
			CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
			CreateMap<Feature, ResultFeatureDto>().ReverseMap();

			CreateMap<FeatureProduct, CreateFeatureProductDto>().ReverseMap();
			CreateMap<FeatureProduct, UpdateFeatureProductDto>().ReverseMap();
			CreateMap<FeatureProduct, ResultFeatureProductDto>().ReverseMap();

			CreateMap<OfferDiscount, CreateOfferDiscountDto>().ReverseMap();
			CreateMap<OfferDiscount, UpdateOfferDiscountDto>().ReverseMap();
			CreateMap<OfferDiscount, ResultOfferDiscountDto>().ReverseMap();

		}
	}
}
