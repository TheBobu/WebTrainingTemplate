using System;
using System.Collections.Generic;
using System.Text;
using WebTrainingTemplate.Data.Entities;
using WebTrainingTemplate.Dto.Dtos;

namespace WebTrainingTemplate.DataProviders.Managers.Interfaces
{
    public interface IEntityManager
    {
        IEnumerable<EntityListDto> GetRange(int nrOfItems, int pageNr = 1, string info = "");
        EntityDto GetById(int id);
        int Create(EntityCreateDto newEntityDto);
        int Update(EntityDto upadtedEntityDto);
        int GetNumberOfEntities(string info = "");
        Entity Delete(int id);
    }
}
