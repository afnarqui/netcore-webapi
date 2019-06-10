using System;
using System.Collections.Generic;
using System.Text;
using Afnarqui.Prueba.Domain.Entity;
using Afnarqui.Prueba.Infraestructura.Interface;
using Afnarqui.Prueba.Transversal.Common;
using Dapper;
using System.Data;
using System.Threading.Tasks;

namespace Afnarqui.Prueba.Infraestructura.Repository
{
    public class PersonsRepository : IPersonsRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public PersonsRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        #region Métodos Síncronos

        public bool Insert(Persons person)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "PersonsInsert";
                var parameters = new DynamicParameters();
                parameters.Add("personsId", person.personsId);
                parameters.Add("identity", person.identity);
                parameters.Add("password", person.password);
               

                var result = connection.Execute(query, parameters, commandType: CommandType.StoredProcedure);

                return result > 0;

            }
        }

        public bool Update(Persons person)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "PersonsUpdate";
                var parameters = new DynamicParameters();
                parameters.Add("personsId", person.personsId);
                parameters.Add("identity", person.identity);
                parameters.Add("password", person.password);

                var result = connection.Execute(query, parameters, commandType: CommandType.StoredProcedure);

                return result > 0;

            }
        }

        public bool Delete(string id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "PersonsDelete";
                var parameters = new DynamicParameters();
                parameters.Add("personsId", id);
               
                var result = connection.Execute(query, parameters, commandType: CommandType.StoredProcedure);

                return result > 0;

            }
        }

        public Persons Get(string id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "PersonsGetByID";
                var parameters = new DynamicParameters();
                parameters.Add("personsId", id);

                var result = connection.QuerySingle<Persons>(query, parameters, commandType: CommandType.StoredProcedure);

                return result;

            }
        }

        public IEnumerable<Persons> GetAll()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "PersonsList";
        
                var results = connection.Query<Persons>(query, commandType: CommandType.StoredProcedure);

                return results;

            }
        }

        #endregion

        #region Métodos Asíncronos

        public async Task<bool> InsertAsync(Persons person)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "PersonsInsert";
                var parameters = new DynamicParameters();
                parameters.Add("personsId", person.personsId);
                parameters.Add("identity", person.identity);
                parameters.Add("password", person.password);

                var result = await connection.ExecuteAsync(query, parameters, commandType: CommandType.StoredProcedure);

                return result > 0;

            }
        }

        public async Task<bool> UpdateAsync(Persons person)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "PersonsUpdate";
                var parameters = new DynamicParameters();
                parameters.Add("personsId", person.personsId);
                parameters.Add("identity", person.identity);
                parameters.Add("password", person.password);

                var result = await connection.ExecuteAsync(query, parameters, commandType: CommandType.StoredProcedure);

                return result > 0;

            }
        }

        public async Task<bool> DeleteAsync(string id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "PersonsDelete";
                var parameters = new DynamicParameters();
                parameters.Add("personsId", id);

                var result = await connection.ExecuteAsync(query, parameters, commandType: CommandType.StoredProcedure);

                return result > 0;

            }
        }

        public async Task<Persons> GetAsync(string id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "PersonsGetByID";
                var parameters = new DynamicParameters();
                parameters.Add("personsId", id);

                var result = await connection.QuerySingleAsync<Persons>(query, parameters, commandType: CommandType.StoredProcedure);

                return result;

            }
        }

        public async Task<IEnumerable<Persons>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "PersonsList";

                var results = await connection.QueryAsync<Persons>(query, commandType: CommandType.StoredProcedure);

                return results;

            }
        }

        #endregion
    }
}
