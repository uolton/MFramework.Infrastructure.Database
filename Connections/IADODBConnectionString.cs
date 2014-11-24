using MFramework.Common.Validation;
using MFramework.Infrastructure.Database.Connections.ConnectionStrings;

namespace MFramework.Infrastructure.Database.Connections
{
    public interface IADODBConnectionString:IValidatable
    {
        IADODBConnectionString AddProperty(string name, string value);
        IADODBConnectionString AddProperty(string name, bool value);
        IADODBConnectionString AddProperty(string name, long value);
        ADODBConnectionStringWriter WriteOn(ADODBConnectionStringWriter writer);
        T ValueOf<T>(string parameterName);
        long PropertyCount();
        bool IsDefined(string parameterName);
    }

}
