using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace video_games.Models
{
    public partial class ContentRating
    {
        [Key]
        [XmlIgnore]
        public int RatingId { get; set; }

        [XmlAttribute]
        public int GameId { get; set; }

        [Display(Name = "Рейтинг")]
        public int? AgeLevel { get; set; }

        [Display(Name = "Система")]
        public string System { get; set; }
    }
}
