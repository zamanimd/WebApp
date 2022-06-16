using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Weblog.Model;

namespace Weblog.Pages
{
    public class BlogDetailModel : PageModel
    {
        //private readonly ILogger<CreateBlogModel> _logger;
        //public CreateBlogModel(ILogger<CreateBlogModel> logger)
        //{
        //    _logger = logger;
        //}


        [TempData]
        public string SuccessMessage { get; set; }
        [TempData]
        public string ErrorMessage { get; set; }


        private readonly BlogContext _blogContext;
        public BlogDetailModel(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }


        public BlogViewModel? blog { get; set; }


        public void OnGet(int id)
        {
            try
            {
                blog = _blogContext.Blogs.Select(x => new BlogViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Description = x.Description,
                    Content = x.Content,
                    CreateDate = x.CreateDate.ToString()
                }).SingleOrDefault(x=> x.Id == id);

                if (blog == null)
                {
                    ErrorMessage = "The item was not found";
                    return;
                }       
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message.ToString();
            }
        }
    }
}
