using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace video_games.Models
{
    public class GreaterOrEqualToZero : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var x = (decimal)value;
            return x > 0;
        }
    }

    public partial class Games
    {
        [Key]
        [XmlIgnore]
        public int GameId { get; set; }

        [XmlAttribute]
        [Display(Name = "Рейтинг")]
        [Required(ErrorMessage = "Рейтингът е задължително поле")]
        [Range(1, 5, ErrorMessage = "Рейтингът трябва да е между 1 и 5")]
        public double CatalogRating { get; set; }

        [Display(Name = "Налична")]
        [XmlAttribute]
        public bool IsAvailable { get; set; }

        [Display(Name = "Име")]
        [Required(ErrorMessage = "Името е задължително поле")]
        public string Name { get; set; }

        [Display(Name = "Страна на произвеждане")]
        public string Country { get; set; }

        [Display(Name = "Производител")]
        [Required(ErrorMessage = "Производителят е задължително поле")]
        public string Publisher { get; set; }

        [Display(Name = "Официален сайт")]
        [Required(ErrorMessage = "Уебсайтът е задължително поле")]
        public string Website { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Лиценз")]
        public string License { get; set; }

        [Display(Name = "Налични езици")]
        public string Languages { get; set; }

        [Display(Name = "Дата на излизане")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Датата на излизане е задължително поле")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Цена")]
        [Required(ErrorMessage = "Цената е задължително поле")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Цената трябва да е неотрицателно число")]
        public decimal Price { get; set; }

        [Display(Name = "Носител на информация")]
        public string Media { get; set; }

        [Display(Name = "Размер на играта")]
        [Required(ErrorMessage = "Размерът на играта е задължително поле")]
        public string GameSize { get; set; }

        [Display(Name = "Платформа")]
        [Required(ErrorMessage = "Платформата е задължително поле")]
        public string Platform { get; set; }

        [Display(Name = "Жанр")]
        public string Genre { get; set; }

        [XmlIgnore]
        [Display(Name = "Брой играчи")]
        public int? Players { get; set; }

        [Display(Name = "Тип (онлайн, сингълплеър, мултиплеър)")]
        public string Type { get; set; }

        public ContentRating ContentRating { get; set; }

        [XmlArray("RequirementsList")]
        [XmlArrayItem("Requirements")]
        public List<Requirements> Requirements { get; set; }
    }
}
