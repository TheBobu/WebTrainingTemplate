using System;
using System.Collections.Generic;
using System.Text;
using WebTrainingTemplate.Data.Entities;

namespace WebTrainingTemplate.DataProviders.Services
{
    public class EntityProvider : IEntityProvider
    {
        /// <summary>
        /// Template provider class used for implementing specific queries here
        /// Use the DatabaseProvider class to execute queries
        /// </summary>

        public Entity Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Entity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int GetNumberOfEmployees(string info = "")
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Entity> GetRange(int nrOfItems, int pageNumber, string info = "")
        {
            throw new NotImplementedException();
        }

        public int Insert(Entity newEntity)
        {
            throw new NotImplementedException();
        }

        public int Update(Entity updatedEntity)
        {
            throw new NotImplementedException();
        }
    }
}
