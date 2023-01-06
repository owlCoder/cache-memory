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
            string query = "select * from Potrosnja_Energije";
            List<ModelData> dataList = new List<ModelData>();

            using (IDbConnection connection = Connection.GetConnection())
            {
                connection.Open();
                

            }
        }

        /*
        public IEnumerable<Theatre> FindAll()
        {
            string query = "select id_th, name_th, address_th, website_th, place_id_pl from theatre";
            List<Theatre> theatreList = new List<Theatre>();

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
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
                            Theatre theatre = new Theatre(reader.GetInt32(0), reader.GetString(1),
                                reader.GetString(2), reader.GetString(3), reader.GetInt32(4));
                            theatreList.Add(theatre);
                        }
                    }
                }
            }
        */

        public IEnumerable<ModelData> GetSelectedDataByCriteria(string criteriaName, string criteria)
        {
            throw new NotImplementedException();
        }

        public bool WriteModelDataToDataBase(ModelData data)
        {
            throw new NotImplementedException();
        }
    }
}
