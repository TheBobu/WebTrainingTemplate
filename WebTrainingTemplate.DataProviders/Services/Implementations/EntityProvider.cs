using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using WebTrainingTemplate.Data.Entities;
using WebTrainingTemplate.DataProviders.Services.Interfaces;

namespace WebTrainingTemplate.DataProviders.Services.Implementations
{
    public class EntityProvider : IEntityProvider
    {
        /// <summary>
        /// Template provider class used for implementing specific queries here
        /// Use the DatabaseProvider class to execute queries
        /// It uses by default the table with the same name as the Entity
        /// </summary>

        public Entity Delete(int id)
        {
            /// <summary>
            /// Creates the query for deleting an item by EntityId and executing it with DatabaseProvider
            /// </summary>

            var deletedEntity = GetById(id);

            string query = @"
                            DELETE
                            FROM dbo.Entity
                            WHERE EntityId = @id
                            ";

            /// <summary>
            /// parameters variable initializes all the variables used by the query
            /// </summary>
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@id", id));

            DatabaseProvider.ExecuteQuery(query, parameters);

            return deletedEntity;
        }

        public Entity GetById(int id)
        {
            /// <summary>
            /// Creates the query for selecting an item by EntityId and executing it with DatabaseProvider
            /// </summary>

            string query = @"
                            SELECT *
                            FROM dbo.Entity
                            WHERE EntityId = @id
                            ORDER BY EntityId
                            ";

            /// <summary>
            /// parameters variable initializes all the variables used by the query
            /// </summary>
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@id", id));

            var entity = DatabaseProvider.Select(query, parameters);

            if (entity != null)
            {
                /// <summary>
                /// Creates a new Entity and populates it with the data (every property that exists in Entity class)
                /// </summary>
                var resultEntity = new Entity();

                resultEntity.EntityId = (int)entity.Tables[0].Rows[0]["EntityId"];
                resultEntity.Name = (string)entity.Tables[0].Rows[0]["Name"];

                return resultEntity;
            }

            return null;
        }

        public IEnumerable<Entity> GetRange(int nrOfItems, int pageNumber, string searchTerm = "")
        {
            /// <summary>
            /// Creates the query for paging
            /// It brings the number of items requested, depending on the page number we want
            /// It also brings data if a search is necessary
            /// The data is ordered by Id (bringing data with offset works only in ORDER BY context)
            /// </summary>

            string query = @"
                            SELECT *
                            FROM dbo.Entity
                            WHERE Name LIKE @searchTerm + '%'
							ORDER BY EntityId
							OFFSET @nrOfItems * (@pageNumber - 1) ROWS
                            FETCH NEXT @nrOfItems ROWS ONLY
                            ";

            /// <summary>
            /// parameters variable initializes all the variables used by the query
            /// </summary>
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@nrOfItems", nrOfItems));
            parameters.Add(new SqlParameter("@pageNumber", pageNumber));
            parameters.Add(new SqlParameter("@searchTerm", searchTerm));

            var entityTable = DatabaseProvider.Select(query, parameters);

            /// <summary>
            /// Creates the List Entity and populates it with the data set brought by the query
            /// </summary>
            var resultEntityTable = new List<Entity>();

            foreach (DataRow entity in entityTable.Tables[0].Rows)
            {
                var resultEntity = new Entity();
                resultEntity.EntityId = (int)entity["EntityId"];
                resultEntity.Name = (string)entity["Name"];
                resultEntityTable.Add(resultEntity);
            }

            return resultEntityTable;
        }

        public int GetNumberOfEntities(string searchTerm = "")
        {
            /// <summary>
            /// Returns the total number of entites that responded to a search
            /// This is used for calculating the total number of pages
            /// </summary>

            string query = @"
                            SELECT COUNT(*)
                            FROM dbo.Entity
                            WHERE Name LIKE @searchTerm + '%'
                            ";

            /// <summary>
            /// parameters variable initializes all the variables used by the query
            /// </summary>
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@searchTerm", searchTerm));

            var count = DatabaseProvider.Select(query, parameters);

            return (int)count.Tables[0].Rows[0][0];
        }

        public int Create(Entity newEntity)
        {
            /// <summary>
            /// Query for inserting in database
            /// Returns the id of the new created Entity
            /// </summary>

            string query = @"
                            INSERT INTO dbo.Entity (Name)
                            VALUES (@Name)
                            SELECT SCOPE_IDENTITY()
                            ";

            /// <summary>
            /// parameters variable initializes all the variables used by the query
            /// </summary>
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Name", newEntity.Name));

            var result = DatabaseProvider.Select(query, parameters);

            return Decimal.ToInt32((decimal)result.Tables[0].Rows[0][0]);
        }

        public int Update(Entity updatedEntity)
        {
            /// <summary>
            /// Query for updating an Entity
            /// Returns the id of the Entity
            /// </summary>
            string query = @"
                            UPDATE dbo.Entity
                            SET Name = @Name
                            WHERE EntityId = @Id
                            ";

            /// <summary>
            /// parameters variable initializes all the variables used by the query
            /// </summary>
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Name", updatedEntity.Name));
            parameters.Add(new SqlParameter("@Id", updatedEntity.EntityId));

            var result = DatabaseProvider.ExecuteQuery(query, parameters);

            return updatedEntity.EntityId;
        }
    }
}
