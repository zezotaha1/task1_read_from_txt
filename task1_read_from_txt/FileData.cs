using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace task1_read_from_txt
{
    public class FileData
    {
        [Key]
        public int FileDataId { get; set; }

        [Required]
        public string Path { get; set; }

        public List<FileComponent> Components { get; set; }
    }
}
