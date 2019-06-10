using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Afnarqui.Prueba.Aplication.DTO;
using Afnarqui.Prueba.Aplication.Interface;
using Afnarqui.Prueba.Aplication.Logic;
using Microsoft.AspNetCore.Cors;

namespace Afnarqui.Prueba.Services.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        //[EnableCors("policy")]
        [HttpGet("{valor}")]
        public string Get(string valor)
        {
            var response = new Travel();
            return response.search(valor).ToString();
        }



        //private readonly IPersonsAplication ipersonsAplication;

        //public PersonsController(IPersonsAplication personsAplication)
        //{
        //    ipersonsAplication = personsAplication;
        //}

        //#region Métodos Síncronos

        //[HttpPost]
        //public IActionResult Insert([FromBody]PersonsDto personsDto)
        //{
        //    if (personsDto == null)
        //    {
        //        return BadRequest();
        //    }
        //    var response = ipersonsAplication.Insert(personsDto);
        //    if (response.IsSuccess)
        //    {
        //        return Ok(response);
        //    }
        //    return BadRequest(response.Message);
        //}

        //[HttpPut]
        //public IActionResult Update([FromBody]PersonsDto personsDto)
        //{
        //    if (personsDto == null)
        //    {
        //        return BadRequest();
        //    }
        //    var response = ipersonsAplication.Update(personsDto);
        //    if (response.IsSuccess)
        //    {
        //        return Ok(response);
        //    }
        //    return BadRequest(response.Message);
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Delete(string id)
        //{
        //    if (string.IsNullOrEmpty(id))
        //    {
        //        return BadRequest();
        //    }
        //    var response = ipersonsAplication.Delete(id);
        //    if (response.IsSuccess)
        //    {
        //        return Ok(response);
        //    }
        //    return BadRequest(response.Message);
        //}

        //[HttpGet]
        //public string Get()
        //{
        //    var response = new Travel();
        //    return response.search();
        //}

        //[HttpGet("{id}")]
        //public IActionResult Get(string id)
        //{
        //    if (string.IsNullOrEmpty(id))
        //    {
        //        return BadRequest();
        //    }
        //    var response = ipersonsAplication.Get(id);
        //    if (response.IsSuccess)
        //    {
        //        return Ok(response);
        //    }
        //    return BadRequest(response.Message);
        //}


        //[HttpGet]
        //public ActionResult GetAll()
        //{
        //    var response = ipersonsAplication.GetAll();
        //    if (response.IsSuccess)
        //    {
        //        return Ok(response);
        //    }
        //    return BadRequest(response.Message);
        //}

        //#endregion

        //#region Métodos Asíncronos

        //[HttpPost]
        //public async Task<IActionResult> InsertAsync([FromBody]PersonsDto personsDto)
        //{
        //    if (personsDto == null)
        //    {
        //        return BadRequest();
        //    }
        //    var response = await ipersonsAplication.InsertAsync(personsDto);
        //    if (response.IsSuccess)
        //    {
        //        return Ok(response);
        //    }
        //    return BadRequest(response.Message);
        //}

        //[HttpPut]
        //public async Task<IActionResult> UpdateAsync([FromBody]PersonsDto personsDto)
        //{
        //    if (personsDto == null)
        //    {
        //        return BadRequest();
        //    }
        //    var response = await ipersonsAplication.UpdateAsync(personsDto);
        //    if (response.IsSuccess)
        //    {
        //        return Ok(response);
        //    }
        //    return BadRequest(response.Message);
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteAsync(string id)
        //{
        //    if (string.IsNullOrEmpty(id))
        //    {
        //        return BadRequest();
        //    }
        //    var response = await ipersonsAplication.DeleteAsync(id);
        //    if (response.IsSuccess)
        //    {
        //        return Ok(response);
        //    }
        //    return BadRequest(response.Message);
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetAsync(string id)
        //{
        //    if (string.IsNullOrEmpty(id))
        //    {
        //        return BadRequest();
        //    }
        //    var response = await ipersonsAplication.GetAsync(id);
        //    if (response.IsSuccess)
        //    {
        //        return Ok(response);
        //    }
        //    return BadRequest(response.Message);
        //}


        //[HttpGet]
        //public async Task<IActionResult> GetAllAsync()
        //{
        //    var response = await ipersonsAplication.GetAllAsync();
        //    if (response.IsSuccess)
        //    {
        //        return Ok(response);
        //    }
        //    return BadRequest(response.Message);
        //}

        //#endregion
    }
}