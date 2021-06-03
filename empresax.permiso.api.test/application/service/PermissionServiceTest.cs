using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using AutoMapper;
using empresax.permiso.api.domain.DTO;
using empresax.permiso.api.domain.model;
using empresax.permiso.api.domain.aggregate;
using empresax.permiso.api.domain.repository;
using empresax.permiso.api.application.validator;
using empresax.permiso.api.application.service;
using empresax.permiso.api.infraestructure.transform;
using empresax.permiso.api.infraestructure.transform.mapper;

namespace empresax.permiso.api.test.application.service
{
    public class PermissionServiceTest
    {
        private Mock<IPermissionRepository> mock;
        private IPermissionService service;
        private PermissionAggregate aggregate = new PermissionAggregate(new Permission());


        public PermissionServiceTest()
        {
            Mapper.Reset();
            Mapper.Initialize(m => m.AddProfile<PermissionProfile>());

            this.mock = new Mock<IPermissionRepository>();
            this.mock.Setup(m => m.list()).Returns(Task.FromResult(new List<PermissionAggregate>()));
            this.mock.Setup(m => m.get(1)).Returns(Task.FromResult(new PermissionAggregate(new Permission())));
            this.mock.Setup(m => m.create(this.aggregate)).Returns(Task.FromResult(new PermissionAggregate(new Permission())));
            this.mock.Setup(m => m.update(this.aggregate)).Returns(Task.FromResult(this.aggregate));

            this.service = new PermissionService(this.mock.Object, new PermissionTransform(Mapper.Instance), new PermissionValidator());
        }

        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void list()
        {
            Assert.IsNotNull(this.service.list().Result);
        }

        [Test]
        public void get()
        {
            Assert.IsNotNull(this.service.get(1).Result);
            Assert.IsNull(this.service.get(0).Result.Data);
        }

        [Test]
        public void create()
        {
            Assert.IsNotNull(this.service.create(new PermissionDTO()).Result.Errors);
            Assert.AreNotEqual(0,this.service.create(new PermissionDTO()).Result.Errors.Count);
            
            var dto = new PermissionDTO(){
                type =  new PermissionTypeDTO() 
            };
            Assert.AreNotEqual(0,this.service.create(dto).Result.Errors.Count);
        }

        [Test]
        public void update()
        {
            Assert.IsNotNull(this.service.update(1,new PermissionDTO()).Result.Errors);
            Assert.AreNotEqual(0,this.service.update(1,new PermissionDTO()).Result.Errors.Count);

            var dto = new PermissionDTO(){
                type =  new PermissionTypeDTO() 
            };
            Assert.AreNotEqual(0,this.service.update(1,dto).Result.Errors.Count);

            dto.id = 2;
            Assert.AreNotEqual(0,this.service.update(1,dto).Result.Errors.Count);
        }
        
    }
}