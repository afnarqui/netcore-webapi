using System;
using System.Collections.Generic;
using System.Text;
using Afnarqui.Prueba.Domain.Entity;
using System.Threading.Tasks;

namespace Afnarqui.Prueba.Infraestructura.Interface
{
    public interface IPersonsRepository
    {
        #region Métodos Síncronos

        bool Insert(Persons person);
        bool Update(Persons person);
        bool Delete(string Id);
        Persons Get(string Id);
        IEnumerable<Persons> GetAll();

        #endregion

        #region Métodos Asíncronos

        Task<bool> InsertAsync(Persons person);
        Task<bool> UpdateAsync(Persons person);
        Task<bool> DeleteAsync(string Id);
        Task<Persons> GetAsync(string Id);
        Task<IEnumerable<Persons>> GetAllAsync();

        #endregion

    }
}
