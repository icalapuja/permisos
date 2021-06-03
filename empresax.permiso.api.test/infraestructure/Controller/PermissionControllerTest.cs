using NUnit.Framework;
using empresax.permiso.api.infraestructure.Controllers;
using empresax.permiso.api.application.service;
using empresax.permiso.api.infraestructure.repository;
using empresax.permiso.api.infraestructure.transform;


namespace empresax.permiso.api.test.infraestructure.Controller
{
    public class PermissionControllerTest
    {
        private IPermissionsController controller;

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void list()
        {
            Assert.Pass();
        }
        
    }
}