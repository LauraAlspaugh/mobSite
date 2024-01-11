


namespace mobSite.Services;
public class PostsService
{
    private readonly PostsRepository _postsRepository;

    public PostsService(PostsRepository postsRepository)
    {
        _postsRepository = postsRepository;
    }

    internal Post CreatePost(Post postData)
    {
        Post post = _postsRepository.CreatePost(postData);
        return post;
    }

    internal string DestroyPost(int postId, string userId)
    {
        Post post = GetPostById(postId);
        if (post.CreatorId != userId)
        {
            throw new Exception("not yours to destroy!");
        }
        _postsRepository.DestroyPost(postId);
        return "It is gone.";
    }

    internal Post GetPostById(int postId)
    {
        Post post = _postsRepository.GetPostById(postId);
        return post;
    }

    internal List<Post> GetPostsByProjectId(int projectId)
    {
        List<Post> posts = _postsRepository.GetPostsByProjectId(projectId);
        return posts;
    }
}