using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MFramework.Infrastructure.Database.Connections.Converter
{
    public static class ADODBConnectionStringPropertyValueConverter
    {
        public static IADODBConnectionStringPropertyValueConverter BooleanConverter(bool value)
        {
            return new ADODBConnectionStringPropertyValueConverterBoolean(value);
        }
        public static IADODBConnectionStringPropertyValueConverter NumericConverter(long value)
        {
            return new ADODBConnectionStringPropertyValueConverterNumeric(value);
        }
        public static IADODBConnectionStringPropertyValueConverter StringConverter(string value)
        {
            return new ADODBConnectionStringPropertyValueConverterString(value);
        }

        public static IADODBConnectionStringPropertyValueConverter BooleanConverter()
        {
            return new ADODBConnectionStringPropertyValueConverterBoolean();            
        }
        public static IADODBConnectionStringPropertyValueConverter NumericConverter()
        {
            return new ADODBConnectionStringPropertyValueConverterNumeric();
        }
        public static IADODBConnectionStringPropertyValueConverter StringConverter()
        {
            return new ADODBConnectionStringPropertyValueConverterString();
        }
        private class ADODBConnectionStringPropertyValueConverterBoolean : ADODBConnectionStringPropertyValueConverterBase<bool>
        {

            public ADODBConnectionStringPropertyValueConverterBoolean(bool value):base(value){}
            public ADODBConnectionStringPropertyValueConverterBoolean() { }
            private string True_Symbol = "True";
            private string False_Symbol = "False";
            public override string ConvertToString()
            {
                return (_value? True_Symbol: False_Symbol);
            }

            public override bool Accept(string value)
            {
                if (value.ToUpper().Equals(True_Symbol.ToUpper())) return(_value = true);
                if (value.ToUpper().Equals(False_Symbol.ToUpper())) return ! (_value = false);
                return false;
            }
   
        }
        private class ADODBConnectionStringPropertyValueConverterNumeric : ADODBConnectionStringPropertyValueConverterBase<long>
        {
            public ADODBConnectionStringPropertyValueConverterNumeric(long value) : base(value) { }
            public ADODBConnectionStringPropertyValueConverterNumeric() : base() { }
            public override string ConvertToString()
            {
                return _value.ToString(CultureInfo.InvariantCulture);
            }

            public override bool Accept(string value)
            {
                return long.TryParse(value, out _value);
            }

        }
        private class ADODBConnectionStringPropertyValueConverterString : ADODBConnectionStringPropertyValueConverterBase<string>
        {

            public ADODBConnectionStringPropertyValueConverterString(string value) : base(value) { }
            public ADODBConnectionStringPropertyValueConverterString(): base() { }
            public override string ConvertToString()
            {
                return _value;
            }

            public override bool Accept(string value)
            {
                _value = value;
                return true;
            }

        }
    }
}
