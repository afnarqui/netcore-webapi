using System.Data;

namespace Afnarqui.Prueba.Transversal.Common
{
    public interface IConnectionFactory
    {
           IDbConnection GetConnection { get;  }
    }
}
