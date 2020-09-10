using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebTrainingTemplate.Dto.Dtos
{
    public class EntityDto
    {
        /// <summary>
        /// Template for $ext_safeitemname$ Dto
        /// This is used to transfer Data from provider to view
        /// </summary>
        /// 

        private const int NameLength = 50;

        public int EntityId { get; set; }

        [Required, StringLength(NameLength)]
        public string Name { get; set; }
    }
}
