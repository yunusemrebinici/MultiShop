﻿namespace M.Shop.Discount.Dtos
{
	public class ResultCouponDto
	{

		public int CouponId { get; set; }

		public string Code { get; set; }

		public bool IsActive { get; set; }

		public int Rate { get; set; }

		public DateTime ValidDate { get; set; }
	}
}
