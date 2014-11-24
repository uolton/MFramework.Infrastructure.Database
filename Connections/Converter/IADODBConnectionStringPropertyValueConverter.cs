using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFramework.Infrastructure.Database.Connections.Converter
{
    public interface IADODBConnectionStringPropertyValueConverter
    {
        string ConvertToString();
        bool Accept(string value);
        dynamic Value { get; }
    }

    public abstract class ADODBConnectionStringPropertyValueConverterBase<T> : IADODBConnectionStringPropertyValueConverter
    {
        protected T _value;
        public ADODBConnectionStringPropertyValueConverterBase() { }

        public ADODBConnectionStringPropertyValueConverterBase(T value)
        {
            _value = value;
        }
        public abstract string ConvertToString();
        public abstract bool Accept(string value);
        public dynamic Value { get { return _value; } }
    }
}
