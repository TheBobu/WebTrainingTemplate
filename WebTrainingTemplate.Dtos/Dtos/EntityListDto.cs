using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebTrainingTemplate.Dto.Dtos
{
    public class EntityListDto
    {
        private const int NameLength = 50;

        public int EntityId { get; set; }

        [Required, StringLength(NameLength)]
        public string Name { get; set; }
    }
}
