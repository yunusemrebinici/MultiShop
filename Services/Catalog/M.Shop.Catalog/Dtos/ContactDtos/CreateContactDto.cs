﻿namespace M.Shop.Catalog.Dtos.ContactDtos
{
	public class CreateContactDto
	{
		
		public string Name { get; set; }

		public string Mail { get; set; }

		public string Subject { get; set; }

		public string Message { get; set; }

		public DateTime MessageTime { get; set; }
	}
}
