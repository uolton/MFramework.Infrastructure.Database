using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFramework.Common.Core.Delegator;

namespace MFramework.Infrastructure.Database.Connections.ConnectionStrings
{
    public class ADODBConnectionStringParameter<T> : ArgumentBinder<T>, IADODBConnectionStringParameter
    {
        private string _name;
        public ADODBConnectionStringParameter(string name):base()
        {
            _name = name;
        }
        public ADODBConnectionStringParameter(string name,T  value):base(value)
        {
            _name = name;
        }

        public void AddOn(ADODBConnectionStringWriter cnnstr)
        {
            cnnstr.AddParameter(_name, base.ValueGet<T>().ToString());
        }
    }
}
