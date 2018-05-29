using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf_VideoMarket
{
    class cMusteri
    {
        private int _musteriNo;
        private string _musteriAdi;
        private string _musteriSoyadi;
        private string _telefon;
        private string _adres;

        #region Properties
        public int MusteriNo
        {
            get
            {
                return _musteriNo;
            }

            set
            {
                _musteriNo = value;
            }
        }

        public string MusteriAdi
        {
            get
            {
                return _musteriAdi;
            }

            set
            {
                _musteriAdi = value.Substring(0, 1).ToUpper() + value.Substring(1).ToLower();
            }
        }

        public string MusteriSoyadi
        {
            get
            {
                return _musteriSoyadi;
            }

            set
            {
                _musteriSoyadi = value.Substring(0, 1).ToUpper() + value.Substring(1).ToLower();
            }
        }

        public string Telefon
        {
            get
            {
                return _telefon;
            }

            set
            {
                _telefon = value;
            }
        }

        public string Adres
        {
            get
            {
                return _adres;
            }

            set
            {
                _adres = value;
            }
        }
        #endregion

        SqlConnection conn = new SqlConnection(cGenel.connStr);

        public void MusterileriGoster(ListView liste)
        {
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("select * from musteriler where silindi=0", conn);
            conn.Open();
            if (conn.State == ConnectionState.Closed) { conn.Open(); }
            SqlDataReader dr;
            try
            {
                dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    int i = 0;
                    while (dr.Read())
                    {
                        liste.Items.Add(dr[0].ToString());
                        liste.Items[i].SubItems.Add(dr[1].ToString());
                        liste.Items[i].SubItems.Add(dr[2].ToString());
                        liste.Items[i].SubItems.Add(dr[3].ToString());
                        liste.Items[i].SubItems.Add(dr[4].ToString());
                        i++;
                    }
                }
            }
            catch (SqlException ex) { string hata = ex.Message; }
            finally { conn.Close(); }
        }

        public bool MusteriKontrol(cMusteri m)
        {
            bool sonuc = false;
            SqlCommand comm = new SqlCommand("select * from musteriler where musteriAdi=@musteriAdi and musteriSoyadi=@musteriSoyadi and telefon=@telefon and silindi=0", conn);
            comm.Parameters.Add("@musteriAdi", SqlDbType.VarChar).Value = m.MusteriAdi;
            comm.Parameters.Add("@musteriSoyadi", SqlDbType.VarChar).Value = m.MusteriSoyadi;
            comm.Parameters.Add("@telefon", SqlDbType.VarChar).Value = m.Telefon;
            if (conn.State == ConnectionState.Closed) { conn.Open(); }
            SqlDataReader dr;
            try
            {
                dr = comm.ExecuteReader();
                if (dr.HasRows) { sonuc = true; }
                dr.Close();
            }
            catch (SqlException ex) { string hata = ex.Message; }
            finally { conn.Close(); }
            return sonuc;
        }

        public bool MusteriKontrolFromDegistir(string musteriAdi, string musteriSoyadi, string telefon, int ID)
        {
            bool sonuc = false;
            SqlCommand comm = new SqlCommand("select * from musteriler where musteriAdi=@musteriAdi and musteriSoyadi=@musteriSoyadi and telefon=@telefon and musteriNo!=@musteriNo and silindi=0", conn);
            comm.Parameters.Add("@musteriAdi", SqlDbType.VarChar).Value = musteriAdi;
            comm.Parameters.Add("@musteriSoyadi", SqlDbType.VarChar).Value = musteriSoyadi;
            comm.Parameters.Add("@telefon", SqlDbType.VarChar).Value = telefon;
            comm.Parameters.Add("@musteriNo", SqlDbType.Int).Value = ID;
            if (conn.State == ConnectionState.Closed) { conn.Open(); }
            SqlDataReader dr;
            try
            {
                sonuc = true;
                dr = comm.ExecuteReader();
                if (dr.HasRows) { sonuc = true; }
                dr.Close();
            }
            catch (SqlException ex) { string hata = ex.Message; }
            finally { conn.Close(); }
            return sonuc;
        }

        public bool MusteriEkle(cMusteri m)
        {
            bool sonuc = false;
            SqlCommand comm = new SqlCommand("insert into musteriler (musteriAdi, musteriSoyadi, telefon, adres) values(@musteriAdi, @musteriSoyadi, @telefon, @adres)", conn);
            comm.Parameters.Add("@musteriAdi", SqlDbType.VarChar).Value = m.MusteriAdi;
            comm.Parameters.Add("@musteriSoyadi", SqlDbType.VarChar).Value = m.MusteriSoyadi;
            comm.Parameters.Add("@telefon", SqlDbType.VarChar).Value = m.Telefon;
            comm.Parameters.Add("@adres", SqlDbType.VarChar).Value = m.Adres;
            if (conn.State == ConnectionState.Closed) conn.Open();
            try { sonuc = Convert.ToBoolean(comm.ExecuteNonQuery()); }
            catch (SqlException ex) { string hata = ex.Message; }
            finally { conn.Close(); }
            return sonuc;
        }
        public bool MusteriGuncelle(cMusteri m)
        {
            bool sonuc = false;
            SqlCommand comm = new SqlCommand("update musteriler set musteriAdi=@musteriAdi, musteriSoyadi=@musteriSoyadi, telefon=@telefon, adres=@adres where musteriNo=@musteriNo", conn);
            comm.Parameters.Add("@musteriAdi", SqlDbType.VarChar).Value = m.MusteriAdi;
            comm.Parameters.Add("@musteriSoyadi", SqlDbType.VarChar).Value = m.MusteriSoyadi;
            comm.Parameters.Add("@telefon", SqlDbType.VarChar).Value = m.Telefon;
            comm.Parameters.Add("@adres", SqlDbType.VarChar).Value = m.Adres;
            comm.Parameters.Add("@musteriNo", SqlDbType.VarChar).Value = m.MusteriNo;
            if (conn.State == ConnectionState.Closed) conn.Open();
            try { sonuc = Convert.ToBoolean(comm.ExecuteNonQuery()); }
            catch (SqlException ex) { string hata = ex.Message; }
            finally { conn.Close(); }
            return sonuc;
        }

        public bool MusteriSil(int ID)
        {
            bool sonuc = false;
            SqlCommand comm = new SqlCommand("update musteriler set silindi=1 where  musteriNo=@musteriNo", conn);
            comm.Parameters.Add("@musteriNo", SqlDbType.Int).Value = ID;
            if (conn.State == ConnectionState.Closed) conn.Open();
            try { sonuc = Convert.ToBoolean(comm.ExecuteNonQuery()); }
            catch (SqlException ex) { string hata = ex.Message; }
            finally { conn.Close(); }
            return sonuc;
        }

        public void MusteriSorgula(string adaGore, ListView liste)
        {
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("select * from musteriler where musteriAdi like @adaGore + '%'  and silindi=0", conn);
            comm.Parameters.Add("@adaGore", SqlDbType.VarChar).Value = adaGore;
            if (conn.State == ConnectionState.Closed) { conn.Open(); }
            SqlDataReader dr;
            try
            {
                dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    int i = 0;
                    while (dr.Read())
                    {
                        liste.Items.Add(dr[0].ToString());
                        liste.Items[i].SubItems.Add(dr[1].ToString());
                        liste.Items[i].SubItems.Add(dr[2].ToString());
                        liste.Items[i].SubItems.Add(dr[3].ToString());
                        liste.Items[i].SubItems.Add(dr[4].ToString());
                        i++;
                    }
                }
            }
            catch (SqlException ex) { string hata = ex.Message; }
            finally { conn.Close(); }
        }

        public void MusterileriGosterBySorgulama(string adaGore, string soyadaGore, string telefonaGore, string adreseGore, ListView liste)
        {
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("select * from musteriler where silindi=0 anad musteriAdi like @adaGore + '%' ",conn);
        }
    }
}
