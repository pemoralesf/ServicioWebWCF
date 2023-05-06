using Familia.Ecommerce.Domain.Entity;
using Familia.Ecommerce.Infraestructure.Interface;
using Familia.Ecommerce.Transversal.Common;
using Dapper;
using System.Data;
using System.Threading.Tasks;


namespace Familia.Ecommerce.Infraestructure.Repository
{

    public class CustomersRepository : ICustomersRepository
    {
        public readonly IConnectionFactory _connectionFactory;

        #region
        public CustomersRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        #endregion  Metodos Sincronicos

        #region
        public bool Insert(Customers customers)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersInsert";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerId", customers.CustomerId);
                parameters.Add("CompanyName", customers.CompanyName);
                parameters.Add("ContactName", customers.ContactName);
                parameters.Add("ContactTitle", customers.ContactTitle);
                parameters.Add("Address", customers.Address);
                parameters.Add("City", customers.City);
                parameters.Add("Region", customers.Region);
                parameters.Add("PostalCode", customers.PostalCode);
                parameters.Add("Country", customers.Country);
                parameters.Add("Phone", customers.Phone);
                parameters.Add("Fax", customers.Fax);

                var result  = connection.Execute(query, param:parameters, commandType: CommandType.StoredProcedure);
                return  result > 0;
            }
        }


    }
}