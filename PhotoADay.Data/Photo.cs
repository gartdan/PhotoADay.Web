using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace PhotoADay.Data
{
    public class Photo
    {
        public int ID { get; set; }
        public string Href { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string User { get; set; }
        [UIHint("ShortDateTime")]
        [DisplayName("Date Added")]
        public DateTime DateAdded { get; set; }
        public string Tags { get; set; }
        public long ContentLength { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
    }
}
