using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Weblog.Model;

namespace Weblog.Pages
{
    public class CreateBlogModel : PageModel
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
        public CreateBlogModel(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }


        public BlogCreateModel command { get; set; }


        public void OnGet()
        {

        }

        public IActionResult OnPost(BlogCreateModel command)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var blog = new Blog(command.Title, command.Picture, command.PictureAlt, command.PictureTitle, command.Description, command.Content);
                    _blogContext.Add(blog);
                    _blogContext.SaveChanges();
                    SuccessMessage = "Your data has been saved.";
                    ModelState.Clear();
                    return RedirectToPage("./Index");
                }
                else
                {
                    ErrorMessage = "Enter All Required items";
                    return Page();
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message.ToString();
                return Page();
            }
        }
    }
}
