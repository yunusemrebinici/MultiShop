﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo.DTO.CargoOperation
{
	public class CreateCargoOperationDto
	{
		

		public string Barcode { get; set; }

		public string Description { get; set; }

		public DateTime OperationDate { get; set; }
	}
}
