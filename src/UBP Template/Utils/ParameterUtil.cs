using System;
using System.Data;
using System.Data.Common;

namespace UBP_Template.Utils
{
    class ParameterUtil
    {
        public static void AddParameter(IDbCommand command, string name, DbType type)
        {
            IDbDataParameter parameter = command.CreateParameter();
            parameter.ParameterName = name;
            parameter.DbType = type;
            command.Parameters.Add(parameter);
        }

        public static void AddParameter(IDbCommand command, string name, DbType type, ParameterDirection direction)
        {
            IDbDataParameter parameter = command.CreateParameter();
            parameter.ParameterName = name;
            parameter.DbType = type;
            parameter.Direction = direction;
            command.Parameters.Add(parameter);
        }

        public static void AddParameter(IDbCommand command, string name, DbType type, int size)
        {
            IDbDataParameter parameter = command.CreateParameter();
            parameter.ParameterName = name;
            parameter.DbType = type;
            parameter.Size = size;
            command.Parameters.Add(parameter);
        }

        public static void SetParameterValue(IDbCommand command, string name, Object value)
        {
            DbParameter parameter = (DbParameter)command.Parameters[name];
            parameter.Value = value;
        }

        public static object GetParameterValue(IDbCommand command, string name)
        {
            DbParameter parameter = (DbParameter)command.Parameters[name];
            return parameter.Value;
        }
    }
}
