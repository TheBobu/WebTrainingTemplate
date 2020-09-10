using System;
using System.Collections.Generic;
using System.Text;
using WebTrainingTemplate.Data.Entities;

namespace WebTrainingTemplate.DataProviders.Services.Interfaces
{
    public interface IEntityProvider
    {
        Entity Delete(int id);
        Entity GetById(int id);
        int GetNumberOfEntities(string info = "");
        IEnumerable<Entity> GetRange(int nrOfItems, int pageNumber, string SearchTerm = "");
        int Create(Entity newEntity);
        int Update(Entity updatedEntity);
    }
}
