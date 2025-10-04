using Application.Features.CQRS.Results.OrderDetailResults;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.OrderDetailHandlers
{
	public class GetOrderDetailByOrderingIdQueryHandler
	{
		private readonly IOrderDetailService _orderDetail;

		public GetOrderDetailByOrderingIdQueryHandler(IOrderDetailService orderDetail)
		{
			_orderDetail = orderDetail;
		}

		public async Task<List<GetOrderDetailByOrderingIdQueryResult>> Handle(int id)
		{
			var result = await _orderDetail.GetOrderDetailListByOrderingId(id);
			return result;
		}
	}
}
