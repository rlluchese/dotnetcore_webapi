using Newtonsoft.Json;

namespace Ralelu.WebAPI.Arguments.In.Post
{
    public class PostCreate
    {
        [JsonProperty("title")]
        public string Title { get; private set; }

        [JsonProperty("text")]
        public string Text { get; private set; }

        [JsonProperty("userId")]
        public int UserId { get; private set; }

        public PostCreate(string title, string text, int userId)
        {
            Title = title;
            Text = text;
            UserId = userId;
        }
    }
}
