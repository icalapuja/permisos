using System;
using System.Collections.Generic;
using NUnit.Framework;
using empresax.permiso.api.domain.model;
using empresax.permiso.api.domain.DTO;
using empresax.permiso.api.domain.aggregate;
using empresax.permiso.api.application.transform;
using empresax.permiso.api.infraestructure.transform.mapper;
using empresax.permiso.api.infraestructure.transform;
using AutoMapper;


namespace empresax.permiso.api.test.infraestructure.transform
{

    public class PermissionTransformTest
    {
        private IPermissionTransform transform;
        private PermissionDTO dto;
        private Permission model;

        public PermissionTransformTest(){
            Mapper.Reset();
            Mapper.Initialize(m => m.AddProfile<PermissionProfile>());
            this.transform = new PermissionTransform(Mapper.Instance);
            
            this.dto = new PermissionDTO(){
                id = 1,
                name = "Ivan",
                lastName = "Calapuja",
                type = new PermissionTypeDTO(){
                    id = 1,
                    description = "Otro"
                },
                date = "2021-06-02 10:25:30"
            };

            this.model = new Permission(){
                Id = 1,
                Name = "Ivan",
                LastName = "Calapuja",
                PermissionTypeId = 1,
                PermissionType = new PermissionType(){
                    Id = 1,
                    Description = "Otro"
                },
                Date = new DateTime()
            };
        }

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void getDTO()
        {
            Assert.IsNotNull(this.transform.getDTO(new PermissionAggregate(new Permission())));
            Assert.IsNotNull(this.transform.getDTO(new PermissionAggregate(this.model)));
            Assert.IsNull(this.transform.getDTO(new PermissionAggregate(null)));
            Assert.IsNull(this.transform.getDTO(null));

            var dto = this.transform.getDTO(new PermissionAggregate(this.model));
            Assert.AreEqual(this.model.Id, dto.id);
            Assert.AreEqual(this.model.Name, dto.name);
            Assert.AreEqual(this.model.LastName, dto.lastName);
            Assert.AreEqual(this.model.Date.ToString("yyyy-MM-dd hh:mm:ss"), dto.date);
            Assert.AreEqual(this.model.PermissionTypeId, dto.type.id);
            Assert.AreEqual(this.model.PermissionType.Id, dto.type.id);
        }

        [Test]
        public void getAggregate()
        {
            Assert.IsNotNull(this.transform.getAggregate(new PermissionDTO()));
            Assert.IsNotNull(this.transform.getAggregate(this.dto));
            Assert.IsNull(this.transform.getAggregate(null));

            var model = this.transform.getAggregate(this.dto).root;
            Assert.AreEqual(this.dto.id, model.Id);
            Assert.AreEqual(this.dto.name, model.Name);
            Assert.AreEqual(this.dto.lastName, model.LastName);
            Assert.AreEqual(this.dto.date, model.Date.ToString("yyyy-MM-dd hh:mm:ss"));
            Assert.AreEqual(this.dto.type.id, model.PermissionTypeId);
            Assert.AreEqual(this.dto.type.id, model.PermissionType.Id);
        }

        [Test]
        public void getDTOs()
        {
            Assert.IsNotNull(this.transform.getDTOs(null));
            Assert.IsNotNull(this.transform.getDTOs(new List<PermissionAggregate>()));
        }

        [Test]
        public void getAggregates()
        {
            Assert.IsNotNull(this.transform.getAggregates(null));
            Assert.IsNotNull(this.transform.getAggregates(new List<PermissionDTO>()));
        }

    }
}