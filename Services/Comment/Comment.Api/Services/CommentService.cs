using Comment.Api.CommentDTOS;
using Comment.Api.Concrete;
using Comment.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Comment.Api.Services
{
	public class CommentService : ICommentService
	{
		private readonly CommentContext _context;

		public CommentService(CommentContext context)
		{
			_context = context;
		}

		public async Task ActiveCommentAsync(int id)
		{
			var active= await _context.Set<Review>().Where(x=>x.ReviewID==id).FirstOrDefaultAsync();
			active.Status=true;
			await _context.SaveChangesAsync();
		}

		public async Task CreateCommentAsync(CreateCommentDto createCommentDto)
		{
			await _context.Set<Review>().AddAsync(new Review
			{
				Comments = createCommentDto.Comments,
				Date=DateTime.Now,
				ImageUrl=createCommentDto.ImageUrl,
				Name=createCommentDto.Name,	
				Point=createCommentDto.Point,
				ProductId=createCommentDto.ProductId,
				Status=false
			});

			await _context.SaveChangesAsync();
		}

		public async Task DeleteCommentAsync(int id)
		{
			var remove = await _context.Set<Review>().Where(x => x.ReviewID == id).FirstOrDefaultAsync();
			 _context.Remove(remove);
			await _context.SaveChangesAsync();
		}

		public async Task<List<ResultCommentDto>> GetAllCommentAsync()
		{
			
			var values= await _context.Set<Review>().ToListAsync();
			var result = values.Select(x=> new ResultCommentDto
			{
				Comments=x.Comments,
				Status=x.Status,
				ReviewID=x.ReviewID,
				ProductId=x.ProductId,
				date=x.Date,
				ImageUrl = x.ImageUrl,
				Name = x.Name,
				Point=x.Point,
				
			}).ToList();

			return result;
			
			
		}

		public async Task<ResultCommentDto> GetCommentAsync(string id)
		{
			var value = await _context.Set<Review>().Where(x => x.ProductId == id).FirstOrDefaultAsync();
			return new ResultCommentDto
			{
				Comments = value.Comments,
				Status = value.Status,
				ReviewID = value.ReviewID,
				ProductId = value.ProductId,
				date = value.Date,
				ImageUrl = value.ImageUrl,
				Name = value.Name,
				Point=value.Point

			};
		}

		public async Task<List<ResultCommentDto>> GetCommentsByProductIdAsync(string id)
		{
			var values = await _context.Set<Review>().Where(x => x.ProductId == id).ToListAsync();
			var result = values.Select(x => new ResultCommentDto
			{
				Comments = x.Comments,
				Status = x.Status,
				ReviewID = x.ReviewID,
				ProductId = x.ProductId,
				date = x.Date,
				ImageUrl = x.ImageUrl,
				Name = x.Name,
				Point = x.Point,

			}).ToList();

			return result;
		}

		public async Task PassiveCommentAsync(int id)
		{
			var active = await _context.Set<Review>().Where(x => x.ReviewID == id).FirstOrDefaultAsync();
			active.Status = false;
			await _context.SaveChangesAsync();
		}

		public async Task UpdateCommentAsync(UpdateCommentDto updateCommentDto)
		{
			var update = await _context.Set<Review>().Where(x => x.ReviewID == updateCommentDto.ReviewID).FirstOrDefaultAsync();
			update.ImageUrl = updateCommentDto.ImageUrl;
			update.Name = updateCommentDto.Name;
			update.Status = updateCommentDto.Status;
			update.ProductId = updateCommentDto.ProductId;
			update.Date = updateCommentDto.Date;
			update.ImageUrl = updateCommentDto.ImageUrl;
			update.Name = updateCommentDto.Name;
			update.Point = updateCommentDto.Point;
			await _context.SaveChangesAsync();
			
		}
	}
}
