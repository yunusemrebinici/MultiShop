﻿using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Commands.OrderingCommands
{
	public class RemoveOrderingCommand:IRequest
	{
		public int OrderingId { get; set; }

		public RemoveOrderingCommand(int orderingId)
		{
			OrderingId = orderingId;
		}
	}
}
