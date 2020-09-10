using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebTrainingTemplate.Dto.Dtos
{
    public class EntityCreateDto
    {
        private const int NameLength = 50;

        [Required, StringLength(NameLength)]
        public string Name { get; set; }
    }
}
