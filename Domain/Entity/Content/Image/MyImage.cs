using Domain.Entity.Base;

namespace Domain.Entity.Content.Image
{
    public class MyImage : BaseEntity
    {
        public string? ImagePath { get; set; }
        public MyImage(string imagePath)
        {
            ImagePath = imagePath;
        }
    }
}
