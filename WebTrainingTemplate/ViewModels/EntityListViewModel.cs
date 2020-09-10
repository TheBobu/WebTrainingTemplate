using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTrainingTemplate.Dto.Dtos;

namespace WebTrainingTemplate.Web.ViewModels
{
    public class EntityListViewModel
    {
        public int CurrentPage { get; set; }
        public int NrOfPages { get; set; }
        public IEnumerable<EntityListDto> Entities { get; set; }
    }
}