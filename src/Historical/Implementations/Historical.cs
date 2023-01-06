using Common.Implementations;
using Historical.Interfaces;
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
            throw new NotImplementedException();
        }

        public bool WriteModelDataToDataBase(ModelData data)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                connection.Open();
                return Save(data, connection);
            }
        }

        private int Save(ModelData data, IDbConnection connection)
        {


        }
    }
}
/*
public int Save(Theatre entity)
        {
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                return Save(entity, connection);
            }
        }

        // used by save and saveAll
        private int Save(Theatre theatre, IDbConnection connection)
        {
            // id_th intentionally in the last place, so that the order between commands remains the same
            string insertSql = "insert into theatre (name_th, address_th, website_th, place_id_pl, id_th) " +
                "values (:name_th, :address_th , :website_th, :place_id_pl, :id_th)";
            string updateSql = "update theatre set name_th=:name_th, address_th=:address_th, " +
                "website_th=:website_th, place_id_pl=:place_id_pl where id_th=:id_th";
            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = ExistsById(theatre.IdTh, connection) ? updateSql : insertSql;
                ParameterUtil.AddParameter(command, "name_th", DbType.String, 50);
                ParameterUtil.AddParameter(command, "address_th", DbType.String, 50);
                ParameterUtil.AddParameter(command, "website_th", DbType.String, 50);
                ParameterUtil.AddParameter(command, "place_id_pl", DbType.String, 50);
                ParameterUtil.AddParameter(command, "id_th", DbType.Int32);
                command.Prepare();
                ParameterUtil.SetParameterValue(command, "id_th", theatre.IdTh);            
                ParameterUtil.SetParameterValue(command, "name_th", theatre.NameTh);        
                ParameterUtil.SetParameterValue(command, "address_th", theatre.AddressTh);
                ParameterUtil.SetParameterValue(command, "website_th", theatre.WebsiteTh);
                ParameterUtil.SetParameterValue(command, "place_id_pl", theatre.PlaceIdPl);
                return command.ExecuteNonQuery();
            }
        }

*/