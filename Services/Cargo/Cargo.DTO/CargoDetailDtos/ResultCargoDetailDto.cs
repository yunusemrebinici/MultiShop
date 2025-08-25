﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo.DTO.CargoDetailDtos
{
	public class ResultCargoDetailDto
	{
		public int CargoDetailId { get; set; }

		public string SenderCustomer { get; set; }

		public string ReceiverCustomer { get; set; }

		public int Barcode { get; set; }

		public int CargoCompanyId { get; set; }
	}
}
