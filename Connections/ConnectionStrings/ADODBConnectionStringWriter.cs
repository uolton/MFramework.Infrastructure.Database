using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFramework.Infrastructure.Database.Connections.Converter;

namespace MFramework.Infrastructure.Database.Connections.ConnectionStrings
{
    public class ADODBConnectionStringWriter
    {
        private StringBuilder _sb;
        private const string ParameterFormat = "{0}={1}";
        private const string ParameterSeparator = ";";
        public ADODBConnectionStringWriter()
        {
            _sb = new StringBuilder();
        }

        public ADODBConnectionStringWriter AddParameter(string name, string value)
        {

            return AddParameter(name, ADODBConnectionStringPropertyValueConverter.StringConverter(value)); 
        }

        public ADODBConnectionStringWriter AddParameter(string name, long  value)
        {
            return AddParameter(name, ADODBConnectionStringPropertyValueConverter.NumericConverter(value)); 
        }
        public ADODBConnectionStringWriter AddParameter(string name, bool value)
        {
            return AddParameter(name, ADODBConnectionStringPropertyValueConverter.BooleanConverter(value));
        }

        private ADODBConnectionStringWriter AddParameter(string name, IADODBConnectionStringPropertyValueConverter value)
        {
            _sb.Append(_sb.Length > 0 ? ParameterSeparator : string.Empty)
                .Append(string.Format(ParameterFormat, name, value.ConvertToString()));
            
            return (this);
        }
        public ADODBConnectionStringWriter Add<T>(ADODBConnectionStringParameter<T> p)
        {
            p.AddOn(this);
            return this;
        }

        public string Build(IADODBConnectionString cnnstr)
        {
            return cnnstr.WriteOn(this).Build();
        }
        public string Build()
        {
            return _sb.ToString();
        }
    }
}
