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
    class cFilm
    {
        private int _filmNo;
        private string _filmAdi;
        private int _filmTurNo;
        private string _yonetmen;
        private string _oyuncular;
        private string _ozet;
        private double _fiyat;
        private int _miktar;

        #region Properties
        public int FilmNo
        {
            get
            {
                return _filmNo;
            }

            set
            {
                _filmNo = value;
            }
        }

        public string FilmAdi
        {
            get
            {
                return _filmAdi;
            }

            set
            {
                _filmAdi = value.Substring(0, 1).ToUpper() + value.Substring(1).ToLower(); ;
            }
        }

        public int FilmTurNo
        {
            get
            {
                return _filmTurNo;
            }

            set
            {
                _filmTurNo = value;
            }
        }

        public string Yonetmen
        {
            get
            {
                return _yonetmen;
            }

            set
            {
                _yonetmen = value.Substring(0, 1).ToUpper() + value.Substring(1).ToLower();
            }
        }

        public string Oyuncular
        {
            get
            {
                return _oyuncular;
            }

            set
            {
                _oyuncular = value;
            }
        }

        public string Ozet
        {
            get
            {
                return _ozet;
            }

            set
            {
                _ozet = value;
            }
        }

        public double Fiyat
        {
            get
            {
                return _fiyat;
            }

            set
            {
                _fiyat = value;
            }
        }

        public int Miktar
        {
            get
            {
                return _miktar;
            }

            set
            {
                _miktar = value;
            }
        }
        #endregion

        SqlConnection conn = new SqlConnection(cGenel.connStr);

        public bool FilmEkle(cFilm f)
        {
            bool sonuc = false;
            SqlCommand comm = new SqlCommand("insert into filmler (filmAdi, filmTurNo, yonetmen, oyuncular, ozet,fiyat,miktar) values(@filmAdi, @filmTurNo, @yonetmen, @oyuncular, @ozet, @fiyat, @miktar)", conn);
            comm.Parameters.Add("@filmAdi", SqlDbType.VarChar).Value = f.FilmAdi;
            comm.Parameters.Add("@filmTurNo", SqlDbType.Int).Value = f.FilmTurNo;
            comm.Parameters.Add("@yonetmen", SqlDbType.VarChar).Value = f.Yonetmen;
            comm.Parameters.Add("@oyuncular", SqlDbType.VarChar).Value = f.Oyuncular;
            comm.Parameters.Add("@ozet", SqlDbType.VarChar).Value = f.Ozet;
            comm.Parameters.Add("@fiyat", SqlDbType.Money).Value = f.Fiyat;
            comm.Parameters.Add("@miktar", SqlDbType.Int).Value = f.Miktar;
            if (conn.State == ConnectionState.Closed) conn.Open();
            try { sonuc = Convert.ToBoolean(comm.ExecuteNonQuery()); }
            catch (SqlException ex) { string hata = ex.Message; }
            finally { conn.Close(); }
            return sonuc;
        }

        public bool FilmKontrol(cFilm f)
        {
            bool sonuc = false;
            SqlCommand comm = new SqlCommand("select * from filmler where filmAdi=@filmAdi and yonetmen=@yonetmen and varMi=1", conn);
            comm.Parameters.Add("@filmAdi", SqlDbType.VarChar).Value = f.FilmAdi;
            comm.Parameters.Add("@yonetmen", SqlDbType.VarChar).Value = f.Yonetmen;
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

        public void FilmleriGoster(ListView liste)
        {
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("select filmNo, filmAdi, filmler.filmTurNo, yonetmen, oyuncular, ozet, fiyat, varMi, miktar from filmler inner join filmTurleri on filmler.FilmTurNo = filmTurleri.FilmTurNo where varMi=1", conn);
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
                        liste.Items[i].SubItems.Add(dr[5].ToString());
                        liste.Items[i].SubItems.Add(dr[6].ToString());
                        liste.Items[i].SubItems.Add(dr[7].ToString());
                        liste.Items[i].SubItems.Add(dr[8].ToString());
                        i++;
                    }
                }
            }
            catch (SqlException ex) { string hata = ex.Message; }
            finally { conn.Close(); }
        }

        public bool FilmKontrolFromDegistir(cFilm f)
        {
            bool sonuc = false;
            SqlCommand comm = new SqlCommand("select * from filmler where filmAdi=@filmAdi and yonetmen=@yonetmen and filmTurNo=@filmTurNo and filmNo!=@filmNo and varMi=1", conn);
            comm.Parameters.Add("@filmAdi", SqlDbType.VarChar).Value = f.FilmAdi;
            comm.Parameters.Add("@yonetmen", SqlDbType.VarChar).Value = f.Yonetmen;
            comm.Parameters.Add("@filmNo", SqlDbType.Int).Value = f.FilmNo;
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

        public bool FilmSil(int ID)
        {
            bool sonuc = false;
            SqlCommand comm = new SqlCommand("update filmler set varMi=0 where  filmNo=@filmNo", conn);
            comm.Parameters.Add("@filmNo", SqlDbType.Int).Value = ID;
            if (conn.State == ConnectionState.Closed) conn.Open();
            try { sonuc = Convert.ToBoolean(comm.ExecuteNonQuery()); }
            catch (SqlException ex) { string hata = ex.Message; }
            finally { conn.Close(); }
            return sonuc;
        }

        public bool FilmGuncelle(cFilm f)
        {
            bool sonuc = false;
            SqlCommand comm = new SqlCommand("update filmler set filmAdi=@filmAdi, filmTurNo=@filmTurNo, yonetmen=@yonetmen, oyuncular=@oyuncular, ozet=@ozet, fiyat=@fiyat, miktar=@miktar where filmNo=@filmNo", conn);
            comm.Parameters.Add("@filmAdi", SqlDbType.VarChar).Value = f.FilmAdi;
            comm.Parameters.Add("@filmTurNo", SqlDbType.Int).Value = f.FilmTurNo;
            comm.Parameters.Add("@yonetmen", SqlDbType.VarChar).Value = f.Yonetmen;
            comm.Parameters.Add("@oyuncular", SqlDbType.VarChar).Value = f.Oyuncular;
            comm.Parameters.Add("@ozet", SqlDbType.VarChar).Value = f.Ozet;
            comm.Parameters.Add("@fiyat", SqlDbType.VarChar).Value = f.Fiyat;
            comm.Parameters.Add("@miktar", SqlDbType.VarChar).Value = f.Miktar;
            comm.Parameters.Add("@filmNo", SqlDbType.VarChar).Value = f.FilmNo;
            if (conn.State == ConnectionState.Closed) conn.Open();
            try { sonuc = Convert.ToBoolean(comm.ExecuteNonQuery()); }
            catch (SqlException ex) { string hata = ex.Message; }
            finally { conn.Close(); }
            return sonuc;
        }

        public void FilmSorgula(string adaGore, ListView liste)
        {
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("select filmNo, filmAdi, filmler.filmTurNo, turAdi, yonetmen,oyuncular,ozet, fiyat, miktar from filmler inner join filmTurleri on filmler.filmTurNo=filmturleri.filmTurNo where filmAdi like @filmAdi + '%'  and varMi=1", conn);
            comm.Parameters.Add("@filmAdi", SqlDbType.VarChar).Value = adaGore;
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
                        liste.Items[i].SubItems.Add(dr[5].ToString());
                        liste.Items[i].SubItems.Add(dr[6].ToString());
                        liste.Items[i].SubItems.Add(dr[7].ToString());
                        liste.Items[i].SubItems.Add(dr[8].ToString());
                        liste.Items[i].SubItems.Add(dr[9].ToString());
                        i++;
                    }
                }
            }
            catch (SqlException ex) { string hata = ex.Message; }
            finally { conn.Close(); }
        }
    }
}
