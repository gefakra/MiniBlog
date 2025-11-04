using MiniBlog.Data;
using MiniBlog.Interface;
using MiniBlog.Models;
using Microsoft.EntityFrameworkCore;

namespace MiniBlog.Service
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _context;

        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Post post)
        {
            _context.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post != null)
            {
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Post>> GetAllAsync()
        {
            return await _context.Posts
            .Include(p => p.Comments)
            .Include(p => p.PostTags).ThenInclude(pt => pt.Tag)
            .OrderByDescending(p => p.CreatedAt)
            .ToListAsync();
        }

        public async Task<Post?> GetByIdAsync(int id)
        {
            return await _context.Posts
            .Include(p => p.Comments)
            .Include(p => p.PostTags).ThenInclude(pt => pt.Tag)
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateAsync(Post post)
        {
            _context.Update(post);
            await _context.SaveChangesAsync();
        }
    }
}
