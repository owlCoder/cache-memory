using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace Historical
{
    public class Historical : IHistorical
    {
        public int UpisPodatkaUBazuPodataka(Podatak data)
        {
            using (IDbConnection connection = Konekcija.GetConnection())
            {
                connection.Open();
                return SacuvajPodatke(data, connection);
            }
        }

        public IEnumerable<Podatak> OdredjeniPodaciIzBazePodataka(string criteria, string value)
        {
            Console.WriteLine("Primljen zahtev za prihvat podataka po kriterijumu!");

            List<Podatak> podaci = new List<Podatak>();

            using (IDbConnection koneckija = Konekcija.GetConnection())
            {
                koneckija.Open();

                using (IDbCommand command = koneckija.CreateCommand())
                {
                    if (!criteria.Equals("rbr"))
                    {
                        string queryID = "select *from POTROSNJA where " + criteria + " = :param";

                        command.CommandText = queryID;
                        PodesavanjeParametera.AddParameter(command, "param", DbType.String, 50);
                        command.Prepare();
                        PodesavanjeParametera.SetParameterValue(command, "param", value);

                        using (IDataReader reader = command.ExecuteReader())
                        {

                            do
                            {
                                if (!reader.Read())
                                    break;

                                Podatak data = new Podatak(reader.GetInt32(0), reader.GetString(1),
                                                               reader.GetString(2), reader.GetString(3),
                                                               reader.GetInt32(4), reader.GetDecimal(5),
                                                               reader.GetString(6));
                                podaci.Add(data);
                            } while (true);
                        }
                    }
                    else
                    {
                        string query = "select *from POTROSNJA where rbr = :rb";

                        command.CommandText = query;
                        PodesavanjeParametera.AddParameter(command, "rb", DbType.Int32);
                        command.Prepare();
                        PodesavanjeParametera.SetParameterValue(command, "rb", Int32.Parse(value));

                        using (IDataReader reader = command.ExecuteReader())
                        {
                            do
                            {
                                if (!reader.Read())
                                    break;

                                Podatak data = new Podatak(reader.GetInt32(0), reader.GetString(1),
                                                               reader.GetString(2), reader.GetString(3),
                                                               reader.GetInt32(4), reader.GetDecimal(5),
                                                               reader.GetString(6));
                                podaci.Add(data);
                            } while (true);
                        }
                    }
                }
            }

            Console.WriteLine("Zahtev uspesno izvrsen. Podaci poslati!\n");

            return podaci;
        }

        public IEnumerable<Podatak> SviPodaciIzBazePodataka()
        {
            Console.WriteLine("Primljen zahtev za prihvat svih podataka iz baze podataka!");

            string query = "select * from POTROSNJA";
            List<Podatak> podaci = new List<Podatak>();

            using (IDbConnection konekcija = Konekcija.GetConnection())
            {
                konekcija.Open();
                using (IDbCommand command = konekcija.CreateCommand())
                {
                    command.CommandText = query;
                    command.Prepare();

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        do
                        {
                            if (!reader.Read())
                                break;

                            Podatak data = new Podatak(reader.GetInt32(0), reader.GetString(1),
                                                           reader.GetString(2), reader.GetString(3),
                                                           reader.GetInt32(4), reader.GetDecimal(5),
                                                           reader.GetString(6));
                            podaci.Add(data);
                        } while (true);
                    }
                }
            }

            Console.WriteLine("Zahtev uspesno izvrsen. Podaci poslati!\n");

            return podaci;
        }

        [ExcludeFromCodeCoverage]
        private int SacuvajPodatke(Podatak podatak, IDbConnection konekcija)
        {
            Console.WriteLine("Slanje zahteva za upis podatka u bazu podataka...\n");

            string insertSql = "insert into POTROSNJA (rbr, korisnickoIme, adresa, grad, idBrojila, potrosnja, mesec) " +
                "values (:id, :kime, :adr, :gr, :idb, :potrosnja, :mesec)";

            using (IDbCommand command = konekcija.CreateCommand())
            {
                command.CommandText = insertSql;

                PodesavanjeParametera.AddParameter(command, "id", DbType.Int32);
                PodesavanjeParametera.AddParameter(command, "kime", DbType.String, 50);
                PodesavanjeParametera.AddParameter(command, "adr", DbType.String, 50);
                PodesavanjeParametera.AddParameter(command, "gr", DbType.String, 50);
                PodesavanjeParametera.AddParameter(command, "idb", DbType.Int32);
                PodesavanjeParametera.AddParameter(command, "potrosnja", DbType.Decimal);
                PodesavanjeParametera.AddParameter(command, "mesec", DbType.String, 50);
                command.Prepare();
                PodesavanjeParametera.SetParameterValue(command, "id", podatak.Rbr);
                PodesavanjeParametera.SetParameterValue(command, "kime", podatak.KorisnickoIme);
                PodesavanjeParametera.SetParameterValue(command, "adr", podatak.Adresa);
                PodesavanjeParametera.SetParameterValue(command, "gr", podatak.Grad);
                PodesavanjeParametera.SetParameterValue(command, "idb", podatak.IdBrojila);
                PodesavanjeParametera.SetParameterValue(command, "potrosnja", podatak.Potrosnja);
                PodesavanjeParametera.SetParameterValue(command, "mesec", podatak.Mesec);

                return command.ExecuteNonQuery();
            }
        }
    }
}
