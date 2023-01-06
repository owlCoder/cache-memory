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
        }

        /*
         * public string UserID { get; set; }
        public string Username { get; set; }
        public string UserAddress { get; set; }
        public string UserCity { get; set; }
        public string BrojiloId { get; set; }
        public decimal Potroseno { get; set; }
        public string Mesec { get; set; }



         * 
         * 
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
