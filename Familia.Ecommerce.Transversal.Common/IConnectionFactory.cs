using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Familia.Ecommerce.Transversal.Common
{
    public  interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }
}
