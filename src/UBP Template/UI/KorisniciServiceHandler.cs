using System;
using System.Data.Common;
using UBP_Template.Models;
using UBP_Template.Services;

namespace UBP_Template.UI
{
    public class KorisniciServiceHandler
    {
        private static readonly KorisniciService servisKorisnici = new KorisniciService();

        public void MeniKorisnici()
        {
            string unosKorisnika;

            do
            {
                Console.WriteLine("Odaberite opciju za rad sa tabelom Korisnici");
                Console.WriteLine("1 - Prikaz svih korisnika");
                Console.WriteLine("2 - Prikaz korisnika sa odredjenim ID");
                Console.WriteLine("3 - Broj korisnika u bazi podataka");
                Console.WriteLine("4 - Brisanje korisnika sa odredjenim ID");
                Console.WriteLine("5 - Postoji li korisnik sa odredjenim ID");
                Console.WriteLine("6 - Dodavanje novog korisnika");
                Console.WriteLine("0 - Izlaz");

                Console.Write("\nVas izbor\n>> ");
                unosKorisnika = Console.ReadLine();

                switch (unosKorisnika)
                {
                    case "1":
                        PrikazSvih();
                        break;
                    case "2":
                        PrikazPoId();
                        break;
                    case "3":
                        KorisnikaUBazi();
                        break;
                    case "4":
                        BrisanjeKorisnika();
                        break;
                    case "5":
                        PostojiLi();
                        break;
                    case "6":
                        Dodavanje();
                        break;
                }

                Console.WriteLine("\n");
            } while (!unosKorisnika.Equals("0"));

            Console.WriteLine("\n");
        }

        private void Dodavanje()
        {
            Korisnik novi = new Korisnik(16, "amamam", "123", "dsadsadsa");
            Korisnik postojeci = new Korisnik(16, "Kin", "12344", "Novi Sad");

            try
            {
                int rowsAffected = servisKorisnici.Save(novi);

                if (rowsAffected != 0)
                {
                    Console.WriteLine("\n\n------------ Korisnik dodat -------");
                }
                else
                {
                    Console.WriteLine("\n\n------------ Korisnik NIJE dodat -------");
                }

                PrikazSvih();

                rowsAffected = servisKorisnici.Save(postojeci);

                if (rowsAffected != 0)
                {
                    Console.WriteLine("\n\n------------ Korisnik dodat -------");
                }
                else
                {
                    Console.WriteLine("\n\n------------ Korisnik NIJE dodat -------");
                }
            }
            catch (DbException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void PostojiLi()
        {
            int id = -1;

            do
            {
                Console.Write("\nUnesite id korisnika kojeg trazite\n>> ");
                id = Int32.Parse(Console.ReadLine());
            } while (id < 1);

            try
            {
                bool postoji = servisKorisnici.ExistById(id);

                if(postoji == true)
                {
                    Console.WriteLine("\n\n------------ Korisnik sa ID: {0} postoji u bazi podataka! -------------", id);
                }
                else
                {
                    Console.WriteLine("\n\n------------ Korisnik sa ID: {0} ne postoji u bazi podataka! -------------", id);
                }
            }
            catch(DbException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void BrisanjeKorisnika()
        {
            int id = -1;

            do
            {
                Console.Write("\nUnesite id korisnika kojeg brisete\n>> ");
                id = Int32.Parse(Console.ReadLine());
            } while (id < 1);

            try
            {
                int rowsAffected = servisKorisnici.DeleteById(id);

                if (rowsAffected != 0)
                {
                    Console.WriteLine("\n\n------------ Korisnik sa ID: {0} ne postoji u bazi podataka! -------------", id);
                }
                else
                {
                    Console.WriteLine("\n\n------------ Korisnik sa ID: {0} je obrisan iz baze podataka! -------------", id);
                }
            }
            catch (DbException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void KorisnikaUBazi()
        {
            try
            {
                int brojKorisnika = servisKorisnici.GetBrojSvihKorisnika();    
                Console.WriteLine("\nBroj korisnika u bazi podataka je: " + brojKorisnika);
            }
            catch (DbException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void PrikazSvih()
        {
            Console.WriteLine("\n----------------------------------------------------------------------");
            Console.WriteLine(Korisnik.GetFormatedHeader());
            Console.WriteLine("----------------------------------------------------------------------");

            try
            {
                foreach (Korisnik korisnik in servisKorisnici.GetAllKorisnici())
                {
                    Console.WriteLine(korisnik);
                    Console.WriteLine("----------------------------------------------------------------------");
                }
            }
            catch (DbException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void PrikazPoId()
        {
            int id = -1;

            do
            {
                Console.Write("\nUnesite id korisnika koji trazite\n>> ");
                id = Int32.Parse(Console.ReadLine());
            } while (id < 1);

            Korisnik trazeni = null;

            try
            {
                trazeni = servisKorisnici.GetExactKorisnici(id);
            }
            catch(DbException e)
            {
                Console.WriteLine(e.Message);
            }

            if (trazeni == null)
            {
                Console.WriteLine("\n\n------------ Korisnik sa ID: {0} ne postoji u bazi podataka! -------------", id);
            }
            else
            {
                Console.WriteLine("\n----------------------------------------------------------------------");
                Console.WriteLine(Korisnik.GetFormatedHeader());
                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine(trazeni);
                Console.WriteLine("----------------------------------------------------------------------");
            }
        }
    }
}
