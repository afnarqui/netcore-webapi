using System;
using System.Collections.Generic;
using System.Text;
using Afnarqui.Prueba.Aplication.DTO;
using Afnarqui.Prueba.Aplication.Interface;
using Afnarqui.Prueba.Domain.Entity;
using Afnarqui.Prueba.Domain.Interface;
using Afnarqui.Prueba.Transversal.Common;
using System.Threading.Tasks;
using AutoMapper;

namespace Afnarqui.Prueba.Aplication.Main
{
    public class PersonsAplication : IPersonsAplication
    {
        private readonly IPersonsDomain ipersonsDomain;
        private readonly IMapper _mapper;

        public PersonsAplication(IPersonsDomain personsDomain,IMapper mapper)
        {
            ipersonsDomain = personsDomain;
            _mapper = mapper;
        }

        #region Métodos Síncronos

        public Response<bool> Insert(PersonsDto personDto)
        {
            var response = new Response<bool>();
            try
            {
                var person = _mapper.Map<Persons>(personDto);
                response.Data = ipersonsDomain.Insert(person);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro exitoso";
                } 
            }
            catch (Exception e)
            {

                response.Message = e.Message; 
            }
            return response;
        }
        public Response<bool> Update(PersonsDto personDto)
        {
            var response = new Response<bool>();
            try
            {
                var person = _mapper.Map<Persons>(personDto);
                response.Data = ipersonsDomain.Update(person);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización exitoso";
                }
            }
            catch (Exception e)
            {

                response.Message = e.Message;
            }
            return response;
        }
        public Response<bool> Delete(string Id)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = ipersonsDomain.Delete(Id);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminado exitoso";
                }
            }
            catch (Exception e)
            {

                response.Message = e.Message;
            }
            return response;
        }
        public Response<PersonsDto> Get(string Id)
        {
            var response = new Response<PersonsDto>();
            try
            {
                var perso = ipersonsDomain.Get(Id);
                response.Data = _mapper.Map<PersonsDto>(perso);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa";
                }
            }
            catch (Exception e)
            {

                response.Message = e.Message;
            }
            return response;
        }
        public Response<IEnumerable<PersonsDto>> GetAll()
        {
            var response = new Response<IEnumerable<PersonsDto>>();
            try
            {
                var persons = ipersonsDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<PersonsDto>>(persons);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa";
                }
            }
            catch (Exception e)
            {

                response.Message = e.Message;
            }
            return response;
        }

        #endregion

        #region Métodos Asíncronos

        public async Task<Response<bool>> InsertAsync(PersonsDto personDto)
        {
            var response = new Response<bool>();
            try
            {
                var person = _mapper.Map<Persons>(personDto);
                response.Data = await ipersonsDomain.InsertAsync(person);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro exitoso";
                }
            }
            catch (Exception e)
            {

                response.Message = e.Message;
            }
            return response;
        }
        public async Task<Response<bool>> UpdateAsync(PersonsDto personDto)
        {
            var response = new Response<bool>();
            try
            {
                var person = _mapper.Map<Persons>(personDto);
                response.Data = await ipersonsDomain.UpdateAsync(person);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización exitoso";
                }
            }
            catch (Exception e)
            {

                response.Message = e.Message;
            }
            return response;
        }
        public async Task<Response<bool>> DeleteAsync(string Id)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await ipersonsDomain.DeleteAsync(Id);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminado exitoso";
                }
            }
            catch (Exception e)
            {

                response.Message = e.Message;
            }
            return response;
        }
        public async Task<Response<PersonsDto>> GetAsync(string Id)
        {
            var response = new Response<PersonsDto>();
            try
            {
                var perso = await ipersonsDomain.GetAsync(Id);
                response.Data = _mapper.Map<PersonsDto>(perso);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa";
                }
            }
            catch (Exception e)
            {

                response.Message = e.Message;
            }
            return response;
        }
        public async Task<Response<IEnumerable<PersonsDto>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<PersonsDto>>();
            try
            {
                var persons = await ipersonsDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<PersonsDto>>(persons);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa";
                }
            }
            catch (Exception e)
            {

                response.Message = e.Message;
            }
            return response;
        }

        #endregion
    }
}
