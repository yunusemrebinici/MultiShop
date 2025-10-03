using Dapper;
using M.Shop.Discount.Context;
using M.Shop.Discount.Dtos;

namespace M.Shop.Discount.Services
{
	public class DiscountService : IDiscountService
	{
		private readonly DapperContext _dapperContext;

		public DiscountService(DapperContext dapperContext)
		{
			_dapperContext = dapperContext;
		}

		public async Task CreateCouponAsync(CreateCouponDto couponDto)
		{
			var query = "insert into Coupons (Code,Rate,IsActive,ValidDate) values (@code,@rate,@isActive,@validate)";
			var paramaters = new DynamicParameters();
			paramaters.Add("@code", couponDto.Code);
			paramaters.Add("@rate", couponDto.Rate);
			paramaters.Add("@isActive", couponDto.IsActive);
			paramaters.Add("@validate", couponDto.ValidDate);
			using (var connection = _dapperContext.CreateConnection())
			{
				await connection.ExecuteAsync(query, paramaters);
			
			};
			
		}

		public async Task DeleteCouponAsync(int id)
		{
			var query = "delete from Coupons where CouponId=@id";
			var paramaters = new DynamicParameters();
			paramaters.Add("@id", id);
			using (var connection = _dapperContext.CreateConnection())
			{
				await connection.ExecuteAsync(query, paramaters);
			};
		}

		public async Task<int> GetCouponRate(string couponCode)
		{
			var query = "Select Rate from Coupons where Code=@p1";
			var paramaters = new DynamicParameters();
			paramaters.Add("@p1", couponCode);
			using (var connection = _dapperContext.CreateConnection())
			{
				int rate= await connection.QueryFirstOrDefaultAsync<int>(query, paramaters);
				return rate;
			}
		}

		public async Task<List<ResultCouponDto>> GettAllCouponAsync()
		{
			var query = "Select * From Coupons";
			using (var connection = _dapperContext.CreateConnection())
			{
				var values = await connection.QueryAsync<ResultCouponDto>(query);
				return values.ToList();
			}
			
		}

		public async Task<ResultCouponDto> GettCouponByIdAsync(int id)
		{
			var query = "Select * From Coupons where CouponId=@id";
			var paramaters = new DynamicParameters();
			paramaters.Add("@id", id);
			using (var connection = _dapperContext.CreateConnection())
			{
				var values = await connection.QueryAsync<ResultCouponDto>(query,paramaters);
				return values.FirstOrDefault();
			}
		}

		public async Task UpdateCouponAsync(UpdateCouponDto couponDto)
		{ 
			var query = "UPDATE Coupons SET Code = @couponCode, Rate = @discountRate, IsActive = @isActive WHERE CouponId = @couponId";

			var parameters = new DynamicParameters();
			parameters.Add("@couponId", couponDto.CouponId);
			parameters.Add("@couponCode", couponDto.Code);
			parameters.Add("@discountRate", couponDto.Rate);
			parameters.Add("@isActive", couponDto.IsActive);
			

			using (var connection = _dapperContext.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}

		}
	}
}
