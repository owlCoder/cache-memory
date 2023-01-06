using Common.Implementations;
using Historical.Interfaces;
using Historical.Utils;
using System;
using System.Collections.Generic;
using System.Data;

namespace Historical.Implementations
{
    public class Historical : IHistorical
    {
        public IEnumerable<ModelData> GetAllDataFromDataBase()
        {
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
                        while (reader.Read())
                        {
                            ModelData data = new ModelData(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                                                                reader.GetString(4), reader.GetDecimal(5), reader.GetString(6));
                            dataList.Add(data);
                        }
                    }
                }
            }
            return dataList;
        }

        public IEnumerable<ModelData> GetSelectedDataByCriteria(string value, string criteria)
        {
            List<ModelData> dataList = new List<ModelData>();

            using (IDbConnection connection = Connection.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    if (!criteria.Equals("potroseno"))
                    {
                        string queryID = "select * from POTROSNJA_ENERGIJE where " + criteria + " = :param";

                        command.CommandText = queryID;
                        ParameterUtil.AddParameter(command, "param", DbType.String, 50);
                        command.Prepare();
                        ParameterUtil.SetParameterValue(command, "param", value);
                    }
                    else
                    {
                        string queryPotroseno = "select * from POTROSNJA_ENERGIJE where potroseno = :potroseno";

                        command.CommandText = queryPotroseno;
                        ParameterUtil.AddParameter(command, "potroseno", DbType.Int32);
                        command.Prepare();
                        ParameterUtil.SetParameterValue(command, "potroseno", Int32.Parse(value));
                    }         

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ModelData data = new ModelData(reader.GetString(0), reader.GetString(1), reader.GetString(2),
                                                           reader.GetString(3), reader.GetString(4), reader.GetDecimal(5),
                                                           reader.GetString(6));
                            dataList.Add(data);
                        }
                    }
                }
            }

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

        private int Save(ModelData data, IDbConnection connection)
        {
            string insertSql = "insert into POTROSNJA_ENERGIJE (userId, userName, userAddress, userCity, brojiloId, potroseno, potrosnjaMesec) " +
                "values (:userId, :userName , :userAddress, :userCity, :brojiloId, :potroseno, :potrosnjaMesec)";

            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = insertSql;

                ParameterUtil.AddParameter(command, "userId", DbType.String, 50);
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