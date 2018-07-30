using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace video_games.Models
{
    public partial class Requirements
    {
        [Key]
        [XmlIgnore]
        public int RequirementsId { get; set; }

        [XmlAttribute]
        public int GameId { get; set; }

        [Display(Name = "Операционна система")]
        public string OperatingSystem { get; set; }

        [Display(Name = "Процесор")]
        public string Cpu { get; set; }

        [Display(Name = "Рам памет")]
        public string Ram { get; set; }

        [Display(Name = "Видео карта")]
        public string Graphics { get; set; }

        [Display(Name = "Свободно място")]
        public string Storage { get; set; }

        [Display(Name = "Версия на DirectX")]
        public int? DirectX { get; set; }

        [Display(Name = "Интернет връзка")]
        public bool? InternetNeed { get; set; }

        [Display(Name = "Тип (минимални или препоръчителни)")]
        public string RequirementsType { get; set; }

    }
}
