using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Afnarqui.Prueba.Aplication.DTO;
using Afnarqui.Prueba.Aplication.Interface;

namespace Afnarqui.Prueba.Services.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonsAplication ipersonsAplication;

        public PersonsController(IPersonsAplication personsAplication)
        {
            ipersonsAplication = personsAplication;
        }

        #region Métodos Síncronos

        [HttpPost]
        public IActionResult Insert([FromBody]PersonsDto personsDto)
        {
            if (personsDto == null)
            {
                return BadRequest();
            }
            var response = ipersonsAplication.Insert(personsDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPut]
        public IActionResult Update([FromBody]PersonsDto personsDto)
        {
            if (personsDto == null)
            {
                return BadRequest();
            }
            var response = ipersonsAplication.Update(personsDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }
            var response = ipersonsAplication.Delete(id);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }
            var response = ipersonsAplication.Get(id);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var response = ipersonsAplication.GetAll();
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        #endregion

        #region Métodos Asíncronos

        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody]PersonsDto personsDto)
        {
            if (personsDto == null)
            {
                return BadRequest();
            }
            var response = await ipersonsAplication.InsertAsync(personsDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody]PersonsDto personsDto)
        {
            if (personsDto == null)
            {
                return BadRequest();
            }
            var response = await ipersonsAplication.UpdateAsync(personsDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }
            var response = await ipersonsAplication.DeleteAsync(id);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }
            var response = await ipersonsAplication.GetAsync(id);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await ipersonsAplication.GetAllAsync();
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        #endregion
    }
}