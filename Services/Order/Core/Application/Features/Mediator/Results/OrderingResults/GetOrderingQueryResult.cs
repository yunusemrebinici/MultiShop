﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Results.OrderingResults
{
	public class GetOrderingQueryResult
	{
		public int OrderingId { get; set; }

		public string UserId { get; set; }

		public decimal TotalPrice { get; set; }

		public DateTime OrderDate { get; set; }

	}
}
