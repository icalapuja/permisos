using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using empresax.permiso.api.domain.repository;
using empresax.permiso.api.domain.aggregate;
using empresax.permiso.api.domain.model;

namespace empresax.permiso.api.test.infraestructure.repository
{
    public class PermissionRepositoryTest
    {
        private Mock<IPermissionRepository> mock;
        private IPermissionRepository repository;
        private PermissionAggregate aggregate = new PermissionAggregate(new Permission());

        public PermissionRepositoryTest()
        {
            this.mock = new Mock<IPermissionRepository>();
            this.mock.Setup(m => m.list()).Returns(Task.FromResult(new List<PermissionAggregate>()));
            this.mock.Setup(m => m.get(1)).Returns(Task.FromResult(new PermissionAggregate(new Permission())));
            this.mock.Setup(m => m.create(this.aggregate)).Returns(Task.FromResult(new PermissionAggregate(new Permission())));
            this.mock.Setup(m => m.update(this.aggregate)).Returns(Task.FromResult(this.aggregate));
        }

        [SetUp]
        public void Setup()
        {
            this.repository = this.mock.Object;
        }

        [Test]
        public void list()
        {
            Assert.IsNotNull(this.repository.list().Result);
        }

        [Test]
        public void get()
        {
            Assert.IsNull(this.repository.get(0).Result);
            Assert.IsNotNull(this.repository.get(1).Result);
        }

        [Test]
        public void create()
        {
            Assert.IsNotNull(this.repository.create(this.aggregate).Result);
            Assert.AreNotEqual(this.aggregate,this.repository.create(this.aggregate).Result);
            Assert.IsNull(this.repository.create(new PermissionAggregate(null)).Result);
            Assert.IsNull(this.repository.create(null).Result);
        }

        [Test]
        public void update()
        {
            Assert.IsNotNull(this.repository.update(this.aggregate).Result);
            Assert.AreEqual(this.aggregate,this.repository.update(this.aggregate).Result);
            Assert.IsNull(this.repository.update(new PermissionAggregate(null)).Result);
            Assert.IsNull(this.repository.update(null).Result);
        }

    }
}