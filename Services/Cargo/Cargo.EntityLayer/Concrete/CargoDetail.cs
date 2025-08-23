﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo.EntityLayer.Concrete
{
	public class CargoDetail
	{
		public int CargoDetailId { get; set; }

		public string SenderCustomer { get; set; }

		public string ReceiverCustomer {  get; set; }
        
		public int Barcode { get; set; }

		public CargoCompany CargoCompany { get; set; }

		public int CargoCompanyId { get; set; }


	}
}
