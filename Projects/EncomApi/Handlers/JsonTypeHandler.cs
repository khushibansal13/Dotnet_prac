using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Newtonsoft.Json;

namespace EncomApi.Handlers
{
    public class JsonTypeHandler<T> : SqlMapper.TypeHandler<T> where T : class
    {
        public override void SetValue(IDbDataParameter parameter, T? value)
        {
            parameter.Value = (value == null) ? (object)DBNull.Value : JsonConvert.SerializeObject(value);
        }

        public override T Parse(object value)
        {
            if (value == null || value == DBNull.Value)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<T>((string)value)!;
        }
    }
}