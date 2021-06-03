using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using empresax.permiso.api.domain.DTO;
using empresax.permiso.api.application.service;

namespace empresax.permiso.api.infraestructure.Controllers
{

    public abstract class GeneralController<D, ID> : ControllerBase, IGeneralController<D, ID>
    {
        protected IGeneralService<D, ID> service;

        [HttpPost]
        public async Task<IActionResult> create(D dto)
        {
            try 
            {
                var res = await this.service.create(dto);

                if(res.Errors.Count == 0)
                {
                    return Ok(res.Data);
                }else{
                    return BadRequest(new ResponseErrorDTO(res.Errors));
                }
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> update(ID id, D dto)
        {
            try 
            {
                var res = await this.service.update(id,dto);

                if(res.Errors.Count == 0)
                {
                    return Ok(res.Data);
                }else{
                    return BadRequest(new ResponseErrorDTO(res.Errors));
                }
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult delete(ID id)
        {
            try 
            {
                this.service.delete(id);
                return NoContent();
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> get(ID id)
        {
            try 
            {
                return Ok((await this.service.get(id)).Data);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        [HttpGet]
        public async Task<IActionResult> list()
        {
            try 
            {
                return Ok((await this.service.list()).Data);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        
    }
}