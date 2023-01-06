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

        public IEnumerable<ModelData> GetSelectedDataByCriteria(string criteriaName, string criteria)
        {
            List<ModelData> dataList = new List<ModelData>();

            string queryID = "select * from POTROSNJA_ENERGIJE where userId = :userId";
            string queryName = "select * from POTROSNJA_ENERGIJE where userName = :userName";
            string queryAddr = "select * from POTROSNJA_ENERGIJE where userAddress = :userAddress";
            string queryCity = "select * from POTROSNJA_ENERGIJE where userCity = :userCity";
            string queryBrojiloId = "select * from POTROSNJA_ENERGIJE where brojiloId = :brojiloId";
            string queryPotroseno = "select * from POTROSNJA_ENERGIJE where potroseno = :potroseno";
            string queryMesecno = "select * from POTROSNJA_ENERGIJE where potrosnjaMesec = :potrosnjaMesec";

            using (IDbConnection connection = Connection.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    if (criteria == "userId")
                    {
                        command.CommandText = queryID;
                        ParameterUtil.AddParameter(command, "userId", DbType.String, 50);
                        command.Prepare();
                    }
                    else if (criteria == "userName")
                    {
                        command.CommandText = queryName;
                        ParameterUtil.AddParameter(command, "userName", DbType.String, 50);
                        command.Prepare();
                    }
                    else if (criteria == "userAddress")
                    {
                        command.CommandText = queryAddr;
                        ParameterUtil.AddParameter(command, "userAddress", DbType.String, 50);
                        command.Prepare();
                    }
                    else if (criteria == "userCity")
                    {
                        command.CommandText = queryCity;
                        ParameterUtil.AddParameter(command, "userCity", DbType.String, 50);
                        command.Prepare();
                    }
                    else if (criteria == "brojiloId")
                    {
                        command.CommandText = queryBrojiloId;
                        ParameterUtil.AddParameter(command, "brojiloId", DbType.String, 50);
                        command.Prepare();
                    }
                    else if (criteria == "potroseno")
                    {
                        command.CommandText = queryPotroseno;
                        ParameterUtil.AddParameter(command, "potroseno", DbType.Int32);
                        command.Prepare();
                    }
                    else if (criteria == "potrosnjaMesec")
                    {
                        command.CommandText = queryMesecno;
                        ParameterUtil.AddParameter(command, "potrosnjaMesec", DbType.String, 50);
                        command.Prepare();
                    }
                    else
                        return dataList;

                    





                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ModelData theatre = new ModelData(reader.GetInt32(0), reader.GetString(1),
                                reader.GetString(2), reader.GetString(3), reader.GetInt32(4));
                            data.Add(theatre);
                        }
                    }
                }
            }
        }

        /*
         public IEnumerable<Theatre> FindAllById(IEnumerable<int> ids)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select id_th, name_th, address_th, website_th, place_id_pl from theatre where id_th in (");
            foreach (int id in ids)
            {
                sb.Append(":id" + id + ",");
            }
            sb.Remove(sb.Length - 1, 1); // delete last ','
            sb.Append(")");

            List<Theatre> theatreList = new List<Theatre>();

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = sb.ToString();
                    foreach (int id in ids)
                    {
                        ParameterUtil.AddParameter(command, "id" + id, DbType.Int32);
                    }
                    command.Prepare();

                    foreach (int id in ids)
                    {
                        ParameterUtil.SetParameterValue(command, "id" + id, id);
                    }
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Theatre theatre = new Theatre(reader.GetInt32(0), reader.GetString(1),
                                reader.GetString(2), reader.GetString(3), reader.GetInt32(4));
                            theatreList.Add(theatre);
                        }
                    }
                }
            }

            return theatreList;
        }
        */


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