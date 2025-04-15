using Domain.Entity.Base;
using Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Domain.Entity.Content.Lessons
{
    public class Theory : BaseEntity
    {
        public string? Title { get; set; }
        public TheoryType Type { get; set; }
        public string? TextContent { get; set; }
        private string? _serializedListContent;
        [NotMapped]
        public List<string> ListContent
        {
            get => _serializedListContent == null
                ? new List<string>()
                : JsonSerializer.Deserialize<List<string>>(_serializedListContent) ?? new List<string>();
            set => _serializedListContent = JsonSerializer.Serialize(value);
        }
        public string? ImagePath { get; set; }

        public int LessonId { get; set; }
        [JsonIgnore]
        public Lesson? Lesson { get; set; }
    }
}
