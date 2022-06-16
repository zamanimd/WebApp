using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Weblog.Model;

namespace Weblog.Pages
{
    public class IndexModel : PageModel
    {
        //private readonly ILogger<IndexModel> _logger;
        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}


        [TempData]
        public string SuccessMessage { get; set; }
        [TempData]
        public string ErrorMessage { get; set; }


        private readonly BlogContext _blogContext;
        public IndexModel(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }


        public List<BlogViewModel> Blogs { get; set; }



        public void OnGet()
        {
            try
            {
                Blogs = _blogContext.Blogs
                    .Where(x => x.IsDeleted == false)
                    .Select(x => new BlogViewModel
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Picture = x.Picture,
                        PictureAlt = x.PictureAlt,
                        PictureTitle = x.PictureTitle,
                        Description = x.Description,
                        Content = x.Content,
                        CreateDate = x.CreateDate.ToString()
                    }).OrderByDescending(x => x.Id).ToList();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message.ToString();
            }
        }

        public IActionResult OnGetDelete(int id)
        {
            try
            {
                var blog = _blogContext.Blogs.First(x => x.Id == id);
                if (blog != null)
                {
                    blog.IsDeleted = true;
                    _blogContext.SaveChanges();
                    return RedirectToPage("Index");
                }
                else
                {
                    ErrorMessage = "The deletion operation encountered an error";
                    return RedirectToPage("Index");
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message.ToString();
                return RedirectToPage("Index");
            }
        }

    }
}