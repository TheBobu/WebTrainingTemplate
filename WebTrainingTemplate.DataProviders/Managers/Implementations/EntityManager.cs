using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WebTrainingTemplate.Data.Entities;
using WebTrainingTemplate.DataProviders.Managers.Interfaces;
using WebTrainingTemplate.DataProviders.Services;
using WebTrainingTemplate.DataProviders.Services.Interfaces;
using WebTrainingTemplate.Dto.Dtos;

namespace WebTrainingTemplate.DataProviders.Managers.Implementations
{
    public class EntityManager : IEntityManager
    {
        private readonly IMapper mapper;
        private readonly IEntityProvider EntityProvider;

        public EntityManager(IMapper mapper, IEntityProvider EntityProvider)
        {
            this.mapper = mapper;
            this.EntityProvider = EntityProvider;
        }

        public Entity Delete(int id)
        {
            return EntityProvider.Delete(id);
        }

        public EntityDto GetById(int id)
        {
            var Entity = EntityProvider.GetById(id);
            var EntityDto = mapper.Map<EntityDto>(Entity);
            return EntityDto;
        }

        public int GetNumberOfEntities(string info = "")
        {
            return EntityProvider.GetNumberOfEntities(info);
        }

        public IEnumerable<EntityListDto> GetRange(int nrOfItems, int pageNumber = 1, string info = "")
        {
            var Entitys = EntityProvider.GetRange(nrOfItems, pageNumber, info);
            var EntitysDto = mapper.Map<IEnumerable<EntityListDto>>(Entitys);
            return EntitysDto;
        }

        public int Create(EntityCreateDto newEntityDto)
        {
            var newEntity = mapper.Map<Entity>(newEntityDto);
            return EntityProvider.Create(newEntity);
        }

        public int Update(EntityDto updatedEntityDto)
        {
            var updatedEntity = mapper.Map<Entity>(updatedEntityDto);
            return EntityProvider.Update(updatedEntity);
        }
    }
}
