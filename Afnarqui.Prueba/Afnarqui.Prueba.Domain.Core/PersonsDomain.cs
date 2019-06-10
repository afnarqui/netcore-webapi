using System;
using System.Collections.Generic;
using System.Text;
using Afnarqui.Prueba.Domain.Entity;
using Afnarqui.Prueba.Infraestructura.Interface;
using System.Threading.Tasks;
using Afnarqui.Prueba.Infraestructura.Repository;
using Afnarqui.Prueba.Domain.Interface;

namespace Afnarqui.Pruebas.Domain.Core
{
    class PersonsDomain : IPersonsDomain
    {
        private readonly PersonsRepository ipersonsRepository;

        public PersonsDomain(PersonsRepository personsRepository)
        {
            ipersonsRepository = personsRepository;
        }

        #region Métodos Asíncronos

        public async Task<bool> InsertAsync(Persons person)
        {
           return await ipersonsRepository.InsertAsync(person);
        }

        public async Task<bool> UpdateAsync(Persons person)
        {
            return await ipersonsRepository.UpdateAsync(person);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            return await ipersonsRepository.DeleteAsync(id);
        }

        public async Task<Persons> GetAsync(string id)
        {
            return await ipersonsRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Persons>> GetAllAsync()
        {
            return await ipersonsRepository.GetAllAsync();
        }

        #endregion

        #region Métodos Síncronos

        public bool Insert(Persons person)
        {
            return ipersonsRepository.Insert(person);
        }

        public bool Update(Persons person)
        {
            return ipersonsRepository.Update(person);
        }

        public bool Delete(string id)
        {
            return ipersonsRepository.Delete(id);
        }

        public Persons Get(string id)
        {
            return ipersonsRepository.Get(id);
        }

        public IEnumerable<Persons> GetAll()
        {
            return ipersonsRepository.GetAll();
        }

        #endregion
    }
}
