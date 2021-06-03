using System;
using System.Collections.Generic;
using empresax.permiso.api.domain.aggregate;
using empresax.permiso.api.domain.DTO;
using empresax.permiso.api.domain.model;
using empresax.permiso.api.application.transform;
using AutoMapper;

namespace empresax.permiso.api.infraestructure.transform
{
    public class PermissionTypeTransform : IPermissionTypeTransform
    {
        private readonly IMapper mapper;

        public PermissionTypeTransform(IMapper mapper)
        {
            this.mapper = mapper;
        }
         

        public PermissionTypeDTO getDTO(PermissionTypeAggregate aggregate)
        {
            if(aggregate == null || aggregate.root == null){
                return null;
            }

            return mapper.Map<PermissionTypeDTO>(aggregate.root);
        }

        public PermissionTypeAggregate getAggregate(PermissionTypeDTO dto)
        {
            if(dto == null)
            {
                return null;
            }

            return new PermissionTypeAggregate(mapper.Map<PermissionType>(dto));
        }

        public List<PermissionTypeAggregate> getAggregates(List<PermissionTypeDTO> DTOs)
        {
            List<PermissionTypeAggregate> aggregates = new List<PermissionTypeAggregate>();
            
            if(DTOs != null){
                DTOs.ForEach(item=>aggregates.Add(this.getAggregate(item)));
            }

            return aggregates;
        }

        

        public List<PermissionTypeDTO> getDTOs(List<PermissionTypeAggregate> aggregates)
        {
            List<PermissionTypeDTO> dtos = new List<PermissionTypeDTO>();

            if(aggregates != null){
                aggregates.ForEach(item=>dtos.Add(this.getDTO(item)));
            }

            return dtos;
        }
    }
}