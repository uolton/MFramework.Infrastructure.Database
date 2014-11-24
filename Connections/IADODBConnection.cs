using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFramework.Common.Validation;

namespace MFramework.Infrastructure.Database.Connections
{
    
    public interface IADODBConnection:IValidatable
    {

        
        string ConnectionString();
    }
}
