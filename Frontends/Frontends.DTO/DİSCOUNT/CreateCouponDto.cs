using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontends.DTO.DİSCOUNT
{
	public class CreateCouponDto
	{
		

		public string Code { get; set; }

		public bool IsActive { get; set; }

		public int Rate { get; set; }

		public DateTime ValidDate { get; set; }
	}
}
