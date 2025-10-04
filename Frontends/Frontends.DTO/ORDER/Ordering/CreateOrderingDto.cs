﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontends.DTO.ORDER.Ordering
{
	public class CreateOrderingDto
	{
		
		public string UserId { get; set; }

		public decimal TotalPrice { get; set; }

		public DateTime OrderDate { get; set; }
	}
}
