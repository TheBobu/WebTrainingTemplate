﻿using System;
using System.Collections.Generic;
using System.Text;
using WebTrainingTemplate.Data.Entities;

namespace WebTrainingTemplate.DataProviders.Services
{
    public interface IEntityProvider
    {
        Entity Delete(int id);
        Entity GetById(int id);
        int GetNumberOfEmployees(string info = "");
        IEnumerable<Entity> GetRange(int nrOfItems, int pageNumber, string info = "");
        int Insert(Entity newEntity);
        int Update(Entity updatedEntity);
    }
}
