using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFramework.Infrastructure.Database.Connections.ConnectionStrings
{
    public interface IADODBConnectionStringParameter
    {
        void AddOn(ADODBConnectionStringWriter cnnstr);
    }
}
