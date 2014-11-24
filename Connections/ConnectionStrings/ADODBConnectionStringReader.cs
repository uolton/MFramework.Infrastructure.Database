using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MFramework.Infrastructure.Database.Connections.Converter;

namespace MFramework.Infrastructure.Database.Connections.ConnectionStrings
{
    public class ADODBConnectionStringReader
    {
        private static List<IADODBConnectionStringPropertyValueConverter> _converters= new List<IADODBConnectionStringPropertyValueConverter>();        
        private string _cnnstr;
        private const string ConnectionStringParameterRegExp = "([^=;]+)=([^=;]+)";
        private List<string> _unrecongnizedSection = new List<string>();
        static ADODBConnectionStringReader()
        {
            _converters.Add(ADODBConnectionStringPropertyValueConverter.BooleanConverter());
            _converters.Add(ADODBConnectionStringPropertyValueConverter.NumericConverter());
            _converters.Add(ADODBConnectionStringPropertyValueConverter.StringConverter());
        }
        public ADODBConnectionStringReader():this(string.Empty)
        {
            
        }
        public ADODBConnectionStringReader(string connectionString)
        {
            _cnnstr = connectionString;
        }

        public ADODBConnectionStringReader ReadFrom(string connectionString)
        {
            _cnnstr = connectionString;
            return this;
        }
        public IEnumerable<string> Unrecognized()
        {
            return _unrecongnizedSection;
        }
        private void AddUnrecognizedSection(string unrecognizedPart)
        {
            _unrecongnizedSection.Add(unrecognizedPart);
        }
        private void Parse(Func<string, dynamic,IADODBConnectionString> parseAction)
        {

            int nextOfset = 0;
            _unrecongnizedSection.Clear();
            foreach (Match match in Regex.Matches(_cnnstr, ConnectionStringParameterRegExp))
            {
                if (match.Groups[0].Index != nextOfset)
                    AddUnrecognizedSection(_cnnstr.Substring(nextOfset, match.Groups[0].Index - nextOfset -1));
                
                parseAction(match.Groups[1].Value.Trim(), ConvertValue(match.Groups[2].Value.Trim()));
                nextOfset = match.Groups[0].Index + match.Groups[0].Length + 1;
            }
            
        }

        private static dynamic ConvertValue(string value)
        {
            return _converters.Find(c => c.Accept(value)).Value;
        }

        public bool Build()
        {

            return Build(new ADODBConnectionString());
        }
        public bool Build(IADODBConnectionString cnnStr)
        {
            
            Parse((p, v) => cnnStr.AddProperty(p, v));
            return (_unrecongnizedSection.Count== 0);
        }

        
    }
}
