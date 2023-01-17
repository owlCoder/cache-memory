using Common_Class_Library.Implementations;
using Historical_Component.Interfaces;
using Historical_Component.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace Historical_Component.Implementations
{
    public class Historical : MarshalByRefObject, IHistorical
    {
        public IEnumerable<ModelData> GetAllDataFromDataBase()
        {
            // Log Message
            Console.WriteLine("[REQUEST] GET ALL DATA");

            string query = "select * from POTROSNJA_ENERGIJE";
            List<ModelData> dataList = new List<ModelData>();

            using (IDbConnection connection = Connection.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.Prepare();

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        do
                        {
                            if (!reader.Read())
                                break;

                            ModelData data = new ModelData(reader.GetInt32(0), reader.GetString(1),
                                                           reader.GetString(2), reader.GetString(3),
                                                           reader.GetString(4), reader.GetDecimal(5),
                                                           reader.GetString(6));
                            dataList.Add(data);
                        } while (reader.Read());
                    }
                }
            }

            // Log Message
            Console.WriteLine("[REQUEST] GET ALL DATA SUCCESS\n");

            return dataList;
        }

        public IEnumerable<ModelData> GetSelectedDataByCriteria(string criteria, string value)
        {
            // Log Message
            Console.WriteLine("[REQUEST] GET DATA BY CRITERIA");

            List<ModelData> dataList = new List<ModelData>();

            using (IDbConnection connection = Connection.GetConnection())
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    if (!criteria.Equals("userId"))
                    {
                        string queryID = "select *from POTROSNJA_ENERGIJE where " + criteria + " = :param";

                        command.CommandText = queryID;
                        ParameterUtil.AddParameter(command, "param", DbType.String, 50);
                        command.Prepare();
                        ParameterUtil.SetParameterValue(command, "param", value);

                        using (IDataReader reader = command.ExecuteReader())
                        {

                            do
                            {
                                if (!reader.Read())
                                    break;

                                ModelData data = new ModelData(reader.GetInt32(0), reader.GetString(1),
                                                               reader.GetString(2), reader.GetString(3),
                                                               reader.GetString(4), reader.GetDecimal(5),
                                                               reader.GetString(6));
                                dataList.Add(data);
                            } while (reader.Read());
                        }
                    }
                    else
                    {
                        string query = "select *from POTROSNJA_ENERGIJE where userId = :useridun";

                        command.CommandText = query;
                        ParameterUtil.AddParameter(command, "useridun", DbType.Int32);
                        command.Prepare();
                        ParameterUtil.SetParameterValue(command, "useridun", Int32.Parse(value));

                        using (IDataReader reader = command.ExecuteReader())
                        {
                            do
                            {
                                if (!reader.Read())
                                    break;

                                ModelData data = new ModelData(reader.GetInt32(0), reader.GetString(1),
                                                               reader.GetString(2), reader.GetString(3),
                                                               reader.GetString(4), reader.GetDecimal(5),
                                                               reader.GetString(6));
                                dataList.Add(data);
                            } while (reader.Read());
                        }
                    }
                }
            }

            // Log Message
            Console.WriteLine("[REQUEST] GET DATA BY CRITERIA SUCCESS\n");

            return dataList;
        }

        public int WriteModelDataToDataBase(ModelData data)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                connection.Open();
                return Save(data, connection);
            }
        }

        [ExcludeFromCodeCoverage]
        private int Save(ModelData data, IDbConnection connection)
        {
            // Log Message
            Console.WriteLine("[REQUEST] SAVE DATA SUCCESS\n");

            string insertSql = "insert into POTROSNJA_ENERGIJE (userId, userName, userAddress, userCity, brojiloId, potroseno, potrosnjaMesec) " +
                "values (:userId, :userName , :userAddress, :userCity, :brojiloId, :potroseno, :potrosnjaMesec)";

            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = insertSql;

                ParameterUtil.AddParameter(command, "userId", DbType.Int32);
                ParameterUtil.AddParameter(command, "userName", DbType.String, 50);
                ParameterUtil.AddParameter(command, "userAddress", DbType.String, 50);
                ParameterUtil.AddParameter(command, "userCity", DbType.String, 50);
                ParameterUtil.AddParameter(command, "brojiloId", DbType.String, 50);
                ParameterUtil.AddParameter(command, "potroseno", DbType.Int32);
                ParameterUtil.AddParameter(command, "potrosnjaMesec", DbType.String, 50);
                command.Prepare();
                ParameterUtil.SetParameterValue(command, "userId", data.UserID);
                ParameterUtil.SetParameterValue(command, "userName", data.Username);
                ParameterUtil.SetParameterValue(command, "userAddress", data.UserAddress);
                ParameterUtil.SetParameterValue(command, "userCity", data.UserCity);
                ParameterUtil.SetParameterValue(command, "brojiloId", data.BrojiloId);
                ParameterUtil.SetParameterValue(command, "potroseno", data.Potroseno);
                ParameterUtil.SetParameterValue(command, "potrosnjaMesec", data.Mesec);

                return command.ExecuteNonQuery();
            }
        }
    }
}