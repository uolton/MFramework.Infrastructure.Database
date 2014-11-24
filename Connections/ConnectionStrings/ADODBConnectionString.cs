using System.Collections.Generic;
using System.Data.SqlClient;
using MFramework.Common.Core.Collections;
using MFramework.Common.Core.Collections.Extensions;
using MFramework.Common.Core.Extensions;
using MFramework.Common.Validation;

namespace MFramework.Infrastructure.Database.Connections.ConnectionStrings
{
    public partial class ADODBConnectionString : ValidatableObjectBase<ADODBConnectionString, ADODBConnectionString.ADODBConnectionStringValidator>, IADODBConnectionString
    {

        
        #region fields
        protected  Dictionary<string,IListTypeAdapter>  _properties;
        #endregion

        public  ADODBConnectionString(){
            _properties = new Dictionary<string, IListTypeAdapter>();
            }

        

        public IADODBConnectionString AddProperty(string name, string value)
        {
            return (Add(name, new ADODBConnectionStringParameter<string>(name, value)));
        }
        public IADODBConnectionString AddProperty(string name, bool value)
        {
            return (Add(name, new ADODBConnectionStringParameter<bool>(name, value)));
        }
        public IADODBConnectionString AddProperty(string name, long value)
        {
            return (Add(name,new ADODBConnectionStringParameter<long>(name, value)));
        }
        private ADODBConnectionString Add(string propertyName,IListTypeAdapter property)
        {
            _properties.Add(propertyName,property);
            return this;
        }

        public T ValueOf<T>(string parameterName) 
        {
            if (IsDefined(parameterName)) return _properties[parameterName].ValueGet<T>();
            return default(T);
        }
        public ADODBConnectionStringWriter WriteOn(ADODBConnectionStringWriter writer)
        {
            _properties.Values.ForEach( p => p.As<IADODBConnectionStringParameter>().AddOn(writer));
            return (writer);
        }

        public long PropertyCount()
        {
            return _properties.Count;
        }

        public bool IsDefined(string parameterName)
        {
            return _properties.ContainsKey(parameterName);
        }
        public static ADODBConnectionStringReader Reader { get { return new ADODBConnectionStringReader();} }
        public static ADODBConnectionStringWriter Writer { get { return new ADODBConnectionStringWriter(); } }
        
/// <summary>
/// Costanti 
/// 
/// </summary>
        public static class Defaults
        {
            // all
            //        internal const string NamedConnection           = "";

            // Odbc
            public  const string Driver = "";
            public const string Dsn = "";

            // OleDb
            public const bool AdoNetPooler = false;
            public const string FileName = "";
            public const int OleDbServices = ~(/*DBPROPVAL_OS_AGR_AFTERSESSION*/0x00000008 | /*DBPROPVAL_OS_CLIENTCURSOR*/0x00000004); // -13
            public const string Provider = "";

            // OracleClient
            public const bool Unicode = false;
            public const bool OmitOracleConnectionName = false;

            // SqlClient
            public const ApplicationIntent ApplicationIntent = System.Data.SqlClient.ApplicationIntent.ReadWrite;
            public const string ApplicationName = ".Net SqlClient Data Provider";
            public const bool AsynchronousProcessing = false;
            public const string AttachDBFilename = "";
            public const int ConnectTimeout = 15;
            public const bool ConnectionReset = true;
            public const bool ContextConnection = false;
            public const string CurrentLanguage = "";
            public const string DataSource = "";
            public const bool Encrypt = false;
            public const bool Enlist = true;
            public const string FailoverPartner = "";
            public const string InitialCatalog = "";
            public const bool IntegratedSecurity = false;
            public const int LoadBalanceTimeout = 0; // default of 0 means don't use
            public const bool MultipleActiveResultSets = false;
            public const bool MultiSubnetFailover = false;
            public const int MaxPoolSize = 100;
            public const int MinPoolSize = 0;
            public const string NetworkLibrary = "";
            public const int PacketSize = 8000;
            public const string Password = "";
            public const bool PersistSecurityInfo = false;
            public const bool Pooling = true;
            public const bool TrustServerCertificate = false;
            public const string TypeSystemVersion = "Latest";
            public const string UserID = "";
            public const bool UserInstance = false;
            public const bool Replication = false;
            public const string WorkstationID = "";
            public const string TransactionBinding = "Implicit Unbind";
            public const int ConnectRetryCount = 1;
            public const int ConnectRetryInterval = 10;
        }

        public static class OptionKeywords
        {
            // Odbc
            public const string Driver = "driver";
            public const string Pwd = "pwd";
            public const string UID = "uid";

            // OleDb
            public const string DataProvider = "data provider";
            public const string ExtendedProperties = "extended properties";
            public const string FileName = "file name";
            public const string Provider = "provider";
            public const string RemoteProvider = "remote provider";

            // common keywords (OleDb, OracleClient, SqlClient)
            public const string Password = "password";
            public const string UserID = "user id";
        }

        public static class Keywords
        {
            // all
            //        public const string NamedConnection           = "Named Connection";

            // Odbc
            public const string Driver = "Driver";
            public const string Dsn = "Dsn";
            public const string FileDsn = "FileDsn";
            public const string SaveFile = "SaveFile";

            // OleDb
            public const string FileName = "File Name";
            public const string OleDbServices = "OLE DB Services";
            public const string Provider = "Provider";

            // OracleClient
            public const string Unicode = "Unicode";
            public const string OmitOracleConnectionName = "Omit Oracle Connection Name";

            // SqlClient
            public const string ApplicationIntent = "ApplicationIntent";
            public const string ApplicationName = "Application Name";
            public const string AsynchronousProcessing = "Asynchronous Processing";
            public const string AttachDBFilename = "AttachDbFilename";
            public const string ConnectTimeout = "Connect Timeout";
            public const string ConnectionReset = "Connection Reset";
            public const string ContextConnection = "Context Connection";
            public const string CurrentLanguage = "Current Language";
            public const string Encrypt = "Encrypt";
            public const string FailoverPartner = "Failover Partner";
            public const string InitialCatalog = "Initial Catalog";
            public const string MultipleActiveResultSets = "MultipleActiveResultSets";
            public const string MultiSubnetFailover = "MultiSubnetFailover";
            public const string NetworkLibrary = "Network Library";
            public const string PacketSize = "Packet Size";
            public const string Replication = "Replication";
            public const string TransactionBinding = "Transaction Binding";
            public const string TrustServerCertificate = "TrustServerCertificate";
            public const string TypeSystemVersion = "Type System Version";
            public const string UserInstance = "User Instance";
            public const string WorkstationID = "Workstation ID";
            public const string ConnectRetryCount = "ConnectRetryCount";
            public const string ConnectRetryInterval = "ConnectRetryInterval";

            // common keywords (OleDb, OracleClient, SqlClient)
            public const string DataSource = "Data Source";
            public const string IntegratedSecurity = "Integrated Security";
            public const string Password = "Password";
            public const string PersistSecurityInfo = "Persist Security Info";
            public const string UserID = "User ID";

            // managed pooling (OracleClient, SqlClient)
            public const string Enlist = "Enlist";
            public const string LoadBalanceTimeout = "Load Balance Timeout";
            public const string MaxPoolSize = "Max Pool Size";
            public const string Pooling = "Pooling";
            public const string MinPoolSize = "Min Pool Size";
        }


    }
}
