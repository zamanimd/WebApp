namespace Weblog.Model
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }    

        public Blog(string title, string picture, string pictureAlt, string pictureTitle, string description, string content)
        {
            Title = title;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Description = description;
            Content = content;
            CreateDate=DateTime.Now;
            IsDeleted = false;
        }
    }
}
