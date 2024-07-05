using System;
using System.ComponentModel.DataAnnotations;

namespace task1_read_from_txt
{
    public class FileComponent
    {
        [Key]
        public int FileComponentId { get; set; }

        public int Category { get; set; }
        public int LengthOfData { get; set; }

        [Required]
        public string Data { get; set; }

        public int FileDataId { get; set; }
        public FileData FileData { get; set; }
    }
}
