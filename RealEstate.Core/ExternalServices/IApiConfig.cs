using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RealEstate.Core.ExternalServices
{
    public abstract class IApiConfig
    {
        public string Version { get; }

        public virtual bool Verify()
        {
            foreach (var prop in this.GetType().GetProperties())
            {
                if (prop.IsDefined(typeof(RequiredAttribute), false))
                {
                    object value = prop.GetValue(this, null);
                    if (isValNullOrEmpty(value))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static bool isValNullOrEmpty(object val)
        {
            switch (val)
            {
                case null: return true;
                case Guid g: return g == Guid.Empty;
                case String s: return String.IsNullOrWhiteSpace(s);
                case DateTime dt: return dt == DateTime.MinValue;
                case double db: return db == double.MaxValue;
                case int i: return i == int.MinValue;
                case IList list: return list.Count == 0;
                case long l: return l == long.MinValue;
                case Uri uri: return String.IsNullOrWhiteSpace(uri.Host);
                default:
                    {
                        Type t = val.GetType();
                        throw new Exception($"Attempting to parse an unknown datatype: '{t}'");
                    }
            }
        }
    }
}
