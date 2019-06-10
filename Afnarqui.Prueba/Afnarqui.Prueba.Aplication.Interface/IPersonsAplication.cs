using System;
using System.Collections.Generic;
using System.Text;
using Afnarqui.Prueba.Aplication.DTO;
using Afnarqui.Prueba.Transversal.Common;
using System.Threading.Tasks;

namespace Afnarqui.Prueba.Aplication.Interface
{
    public interface IPersonsAplication
    {
        #region Métodos Síncronos

        Response<bool> Insert(PersonsDto personDto);
        Response<bool> Update(PersonsDto personDto);
        Response<bool> Delete(string Id);
        Response<PersonsDto> Get(string Id);
        Response<IEnumerable<PersonsDto>> GetAll();

        #endregion

        #region Métodos Asíncronos

        Task<Response<bool>> InsertAsync(PersonsDto personDto);
        Task<Response<bool>> UpdateAsync(PersonsDto personDto);
        Task<Response<bool>> DeleteAsync(string Id);
        Task<Response<PersonsDto>> GetAsync(string Id);
        Task<Response<IEnumerable<PersonsDto>>> GetAllAsync();

        #endregion
    }
}
