using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace empresax.permiso.api.infraestructure.Controllers
{
    public interface IGeneralController <T, ID>
    {
        public Task<IActionResult> create(T dto);
        public Task<IActionResult> update(ID id, T dto);

        public IActionResult delete(ID id);

        public Task<IActionResult> get(ID id);
        public Task<IActionResult> list();
    }
}