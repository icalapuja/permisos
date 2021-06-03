using System;
using AutoMapper;
using empresax.permiso.api.domain.model;
using empresax.permiso.api.domain.DTO;

namespace empresax.permiso.api.infraestructure.transform.mapper
{
    public class PermissionTypeProfile: Profile
    {
        public PermissionTypeProfile()
        {
            CreateMap<PermissionTypeDTO, PermissionType>();
            CreateMap<PermissionType, PermissionTypeDTO>();
        }
    }
}