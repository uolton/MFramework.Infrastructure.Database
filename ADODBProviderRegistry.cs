using System;
using System.Collections.Generic;

namespace MFramework.Infrastructure.Database
{
    /// <summary>
    /// Registro dei Provider
    /// </summary>
    public class ADODBProvidersRegistry<T> where T: IEquatable<T>
    {

        private static ADODBProvidersRegistry<T> _istance;
        private Dictionary<T, IADODBProvider<T>> _registry= new Dictionary<T, IADODBProvider<T>>();
        
        private ADODBProvidersRegistry() {  }

        public bool Exist(T providerId)
        {
            return _registry.ContainsKey(providerId);
        }
        public ADODBProvidersRegistry<T> RegisterProvider(IADODBProvider<T> provider)
        {
            
            _registry.Add(provider.Id, provider);
            return (this);
        }

        public long ProvidersCount()
        {
            return _registry.Count;
        }
        public static ADODBProvidersRegistry<T> Instance
        {
            get
            {
                if (_istance == null) _istance = new ADODBProvidersRegistry<T>();
                return _istance;
            }
        }
    }
}
