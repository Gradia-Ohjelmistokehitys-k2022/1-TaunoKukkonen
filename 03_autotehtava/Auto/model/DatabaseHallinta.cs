﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Windows.Forms;
using Auto.model;





namespace Autokauppa.model
{
    public class DatabaseHallinta
    {
        SqlConnection dbYhteys = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog = Autokauppa");
        List<Auto> Autot = new List<Auto>();
        List<AutoMalli> kaikkiMallit = new List<AutoMalli>();

        public bool connectDatabase()
        {
            try
            {
                using (dbYhteys)
                {
                    dbYhteys.Open();
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Virheilmoitukset:" + e);
                dbYhteys.Close();
                return false;

            }
        }

        public void disconnectDatabase()
        {
            if (dbYhteys.State == ConnectionState.Open)
            {
                dbYhteys.Close();
                Console.WriteLine("Yhteys suljettu");
            }
            else { Console.WriteLine("Ei yheteyttä suljettavaksi"); }

        }

        public bool saveAutoIntoDatabase(Auto newAuto)
        {
            OpenConnection();
            using (SqlTransaction transaction = dbYhteys.BeginTransaction())
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = dbYhteys;
                    cmd.Transaction = transaction;
                    try
                    {
                        cmd.CommandText = "INSERT INTO auto (Hinta,Rekisteri_paivamaara,Moottorin_tilavuus,Mittarilukema,AutonMerkkiID,AutonMalliID,VaritID,PolttoaineID) VALUES (@Hinta,@Rekisteri_paivamaara,@Moottorin_tilavuus,@Mittarilukema,@AutonMerkkiID,@AutonMalliID,@VaritID,@PolttoaineID)";
                        cmd.Parameters.AddWithValue("@Hinta", newAuto.Hinta);
                        cmd.Parameters.AddWithValue("@Rekisteri_paivamaara", newAuto.RekisteriPaivamaara);
                        cmd.Parameters.AddWithValue("@Moottorin_tilavuus", newAuto.MoottorinTilavuus);
                        cmd.Parameters.AddWithValue("@Mittarilukema", newAuto.Mittarilukema);
                        cmd.Parameters.AddWithValue("@AutonMerkkiID", newAuto.AutonMerkkiId);
                        cmd.Parameters.AddWithValue("@AutonMalliID", newAuto.AutonMalliId);
                        cmd.Parameters.AddWithValue("@VaritID", newAuto.VariId);
                        cmd.Parameters.AddWithValue("@PolttoaineID", newAuto.PolttoaineId);
                        cmd.ExecuteNonQuery();

                        transaction.Commit();
                        return true;



                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw e;
                        CloseConnection();
                        return false;
                    }
                }
            }


        }

        public List<AutoMerkki> getAllAutoMakersFromDatabase()
        {
            OpenConnection();
            List<AutoMerkki> palaute = new List<AutoMerkki>();
            if (dbYhteys.State == ConnectionState.Open)
            {
                using SqlCommand cmd = new SqlCommand("SELECT * FROM AutonMerkki", dbYhteys);
                var dataadapter = new SqlDataAdapter(cmd);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AutoMerkki merkki = new AutoMerkki()
                    {
                        MerkkiId = Convert.ToInt32(reader["ID"]),
                        MerkkiNimi = reader["Merkki"].ToString()
                    };
                    palaute.Add(merkki);
                }
            }
            else { Console.WriteLine("Virhe Teikijöiden haussa"); }
            CloseConnection();
            return palaute;

        }

        public List<AutoMalli> getAutoModelsByMakerId(int makerId)
        {
            List<AutoMalli> palaute = new List<AutoMalli>();
            foreach (AutoMalli malli in kaikkiMallit)
            {
                if (malli.MerkkiId == makerId)
                {
                    palaute.Add(malli);
                }
                else if (makerId == 0)
                {
                    palaute.Add(malli);
                }

            }
            return palaute;
        }
        public void GetCarModels()
        {
            OpenConnection();
            kaikkiMallit.Clear();
            try
            {
                using SqlCommand cmd = new SqlCommand("SELECT * FROM AutonMallit", dbYhteys);
                var dataadapter = new SqlDataAdapter(cmd);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AutoMalli malli = new AutoMalli()
                    {
                        MerkkiId = Convert.ToInt32(reader["AutonMerkkiID"]),
                        MalliNimi = reader["Auton_mallin_nimi"].ToString(),
                        MalliId = Convert.ToInt32(reader["ID"]),

                    };
                    kaikkiMallit.Add(malli);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Mallien haku ei onnistunut");
                throw ex;
            }
            CloseConnection();
        }
        public List<Polttonaine> GetFuel()
        {
            List<Polttonaine> polttoaine = new List<Polttonaine>();
            OpenConnection();
            try
            {
                using SqlCommand cmd = new SqlCommand("SELECT * FROM Polttoaine", dbYhteys);
                var dataadapter = new SqlDataAdapter(cmd);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Polttonaine polt = new Polttonaine()
                    {
                        PolttoId = Convert.ToInt32(reader["ID"]),
                        PolttoName = reader["Polttoaineen_nimi"].ToString()
                    };
                    polttoaine.Add(polt);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            CloseConnection();
            return polttoaine;
        }
        public List<Vari> GetAllVari()
        {
            OpenConnection();
            List<Vari> vari = new List<Vari>();
            try
            {
                using SqlCommand cmd = new SqlCommand("SELECT * FROM Varit", dbYhteys);
                var dataadapter = new SqlDataAdapter(cmd);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Vari vari1 = new Vari()
                    {
                        VariId = Convert.ToInt32(reader["ID"]),
                        VariNimi = reader["Varin_nimi"].ToString(),
                    }; vari.Add(vari1);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            CloseConnection();
            return vari;
        }
        public void OpenConnection()
        {
            if (dbYhteys.State != ConnectionState.Open)
            {
                dbYhteys.Open();
            }
        }
        public void CloseConnection()
        {

            if (dbYhteys.State == ConnectionState.Open)
            {
                dbYhteys.Close();
            }
        }
        public List<Auto> GetAllCars()
        { 
            OpenConnection();
            List<Auto> cars = new List<Auto>();
            try
            {
                using SqlCommand cmd = new SqlCommand("SELECT * FROM auto ORDER BY Hinta ASC, Rekisteri_Paivamaara ASC", dbYhteys);
                var dataadapter = new SqlDataAdapter(cmd);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Auto auto = new Auto()
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        Hinta = reader.GetDecimal("Hinta"),
                        RekisteriPaivamaara = reader.GetDateTime("Rekisteri_paivamaara"),
                        MoottorinTilavuus = reader.GetDecimal("Moottorin_tilavuus"),
                        Mittarilukema = Convert.ToInt32(reader["Mittarilukema"]),
                        AutonMerkkiId = Convert.ToInt32(reader["AutonMerkkiID"]),
                        AutonMalliId = Convert.ToInt32(reader["AutonMalliID"]),
                        VariId = Convert.ToInt32(reader["VaritID"]),
                        PolttoaineId = Convert.ToInt32(reader["PolttoaineID"])
                    };
                    cars.Add(auto);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            CloseConnection();
            return cars;
        }
    }
}

