using MiniBlog.Interface;
using MiniBlog.Models;

namespace MiniBlog.Service
{
    public class PostService
    {
        private readonly IPostRepository _repository;

        public PostService(IPostRepository repository)
        {
            _repository = repository;
        }
        public Task<List<Post>> GetAllPostsAsync() => _repository.GetAllAsync();
        public Task<Post?> GetPostByIdAsync(int id) => _repository.GetByIdAsync(id);
        public Task AddPostAsync(Post post) => _repository.AddAsync(post);
        public Task UpdatePostAsync(Post post) => _repository.UpdateAsync(post);
        public Task DeletePostAsync(int id) => _repository.DeleteAsync(id);
    }
}
