using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace AddressBook.Data
{
    public class ContactDetailsContext
    {

        private readonly IConfiguration _configuration;
        private readonly string _connectionstring;
        private readonly IDbConnection _connection;
        public ContactDetailsContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionstring = _configuration.GetConnectionString("Default");
            _connection = new SqlConnection(_connectionstring);
        }
        public IDbConnection connection { get { return _connection; } }
    }
}
