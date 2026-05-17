using _14_Action_Filters.Models;
using System.Text.Json;

namespace _14_Action_Filters.Services
{
    public class BlogService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<BlogService> _logger;


        public BlogService(IWebHostEnvironment environment,ILogger<BlogService> logger)
        {
            _environment = environment;
            _logger = logger;
        }

        public List<BlogPost> GetAllPosts()
        {
            var data = LoadDataFromJson();
            return data.BlogPosts;
        }

        public BlogPost? GetPostById(int id)
        {
            var posts = GetAllPosts();
            return posts.FirstOrDefault(i => i.Id == id);
        }

        public List<User> GetAllUsers()
        {
            var data = LoadDataFromJson();
            return data.Users;
        }

        public User GetUserByUserName(string username)
        {
            var users = GetAllUsers();
            return users.FirstOrDefault(i => i.UserName == username);
        }

        public bool HasPermission(string username, string permission)
        {
            var user = GetUserByUserName(username);
            return user?.Permissions.Contains(permission) ?? false;
        }


        private BlogData LoadDataFromJson()
        {
            var jsonPath = Path.Combine(_environment.ContentRootPath, "Data", "blog-content.json");

            if (!File.Exists(jsonPath))
            {
                _logger.LogWarning($"Json dosyası bulunamadı:{jsonPath}");
                return new BlogData();
            }

            try 
            {
                var jsonContent = File.ReadAllText(jsonPath);
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var data = JsonSerializer.Deserialize<BlogData>(jsonContent, options);

                return data ?? new BlogData();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Json dosyası okunamadı");
                return new BlogData();
            }

        }

    }
}
