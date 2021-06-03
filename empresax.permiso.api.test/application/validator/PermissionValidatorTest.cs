using System;
using System.Collections.Generic;
using NUnit.Framework;
using empresax.permiso.api.domain.DTO;
using empresax.permiso.api.application.validator;

namespace empresax.permiso.api.test.application.validator
{
    public class PermissionValidatorTest
    {
        private IPermissionValidator validator;
        private PermissionDTO dto;

        public PermissionValidatorTest()
        {
            this.validator = new PermissionValidator();
            
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
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ValidateCreation()
        {
            Assert.IsNotNull(this.validator.ValidateCreation(this.dto));
            Assert.IsNotNull(this.validator.ValidateCreation(null));
            Assert.AreNotEqual(0, this.validator.ValidateCreation(new PermissionDTO()).Count);

            var dto = new PermissionDTO(){
                id = 1,
                name = "Ivan",
                lastName = "Calapuja"
            };
            Assert.AreNotEqual(0, this.validator.ValidateCreation(dto).Count);

            dto.type = new PermissionTypeDTO();
            Assert.AreNotEqual(0, this.validator.ValidateCreation(dto).Count);

            dto.type.description = "Otro";
            Assert.AreNotEqual(0, this.validator.ValidateCreation(dto).Count);

            dto.type.id = 1;
            Assert.AreEqual(0,this.validator.ValidateCreation(dto).Count);
        }
    }
}
