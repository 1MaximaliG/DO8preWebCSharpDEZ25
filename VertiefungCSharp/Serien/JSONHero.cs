using System.Text.Json.Serialization;

namespace Serien
{
    public class JSONHero
    {
        public string HeroName { get; set; }
        [JsonIgnore] public string FirsName { get; set; }
        [JsonIgnore] public string LastName { get; set; }
        public string Gang { get; set; }
        public JSONHero Partner { get; set; }
        public List<string> Gedgets { get; set; }
    }
}
