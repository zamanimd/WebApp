using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Weblog.Model
{
    public class BlogCreateModel
    {
        [DisplayName("Blog Title")]
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [DisplayName("Picture URL")]
        public string Picture { get; set; }

        [DisplayName("Picture Alt")]
        [Required(ErrorMessage = "Picture Alt is required.")]
        public string PictureAlt { get; set; }

        [DisplayName("Picture Title")]
        public string PictureTitle { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        [DisplayName("Content")]
        public string Content { get; set; }
    }
}
