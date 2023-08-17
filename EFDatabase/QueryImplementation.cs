using DBModules.SQL.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDatabase
{
    public class QueryImplementation
    {
        private readonly IStudentQueries _studentQueries;//anything injected should be readonly so that you can only get but not set

        public QueryImplementation(IStudentQueries studentQueries) 
        { 
            _studentQueries = studentQueries;
        }

        public async Task userInteraction()
        {

        }
    }
}
