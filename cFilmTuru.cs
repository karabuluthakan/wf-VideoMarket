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
    class cFilmTuru
    {
        private int _filmTurNo;
        private string _turAd;
        private string _aciklama;

        #region Properties
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

        public string TurAd
        {
            get
            {
                return _turAd;
            }

            set
            {
                _turAd = value.Substring(0, 1).ToUpper() + value.Substring(1).ToLower();
            }
        }

        public string Aciklama
        {
            get
            {
                return _aciklama;
            }

            set
            {
                _aciklama = value;
            }
        }
        #endregion

        SqlConnection conn = new SqlConnection(cGenel.connStr);

        public void FilmTurleriGoster(ListView liste)
        {
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("Select * from FilmTurleri where Silindi=0", conn);
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr;   //new ile tanımlanmıyor.
            try
            {
                dr = comm.ExecuteReader();  //Çalışırken hata ile karşılaşılabilecek işlemler.
                if(dr.HasRows)  //Eğer DataReader içinde data varsa, HasRows true değeri alır.
                {
                    int i = 0;
                    while (dr.Read())
                    {
                        liste.Items.Add(dr[0].ToString());
                        liste.Items[i].SubItems.Add(dr[1].ToString());
                        liste.Items[i].SubItems.Add(dr[2].ToString());
                        i++;
                    }
                }
            }
            catch (SqlException ex)   //Hata durumunda çalışma catch bloklarından devam eder.
            {                   //Bütün hatalar Exception sınıfı tarafından yakalanır.
                string hata = ex.Message;
            }
            finally { conn.Close(); }   //Hata olsa da olmasa da finally bloğu mutlaka çalışır.
        }
        public bool FilmTuruKontrol(string FilmTuru)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("Select * from FilmTurleri where TurAd = @TurAd and Silindi=0", conn);
            comm.Parameters.Add("@TurAd", SqlDbType.VarChar).Value = FilmTuru;
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr;
            try
            {
                dr = comm.ExecuteReader();
                if(dr.HasRows)
                {
                    Sonuc = true;
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }
            return Sonuc;
        }
        public bool FilmTuruKontrolFromDegistir(string FilmTuru)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("Select * from FilmTurleri where TurAd = @TurAd and Silindi=0", conn);
            comm.Parameters.Add("@TurAd", SqlDbType.VarChar).Value = FilmTuru;
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr;
            try
            {
                dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    Sonuc = true;
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }
            return Sonuc;
        }
        public bool FilmTuruEkle(cFilmTuru ft)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("insert into FilmTurleri (TurAd, Aciklama) values(@TurAd, @Aciklama)", conn);
            comm.Parameters.Add("@TurAd", SqlDbType.VarChar).Value = ft._turAd;
            comm.Parameters.Add("@Aciklama", SqlDbType.VarChar).Value = ft._aciklama;
            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                Sonuc = Convert.ToBoolean(comm.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            return Sonuc;
        }
        public bool FilmTuruGuncelle(cFilmTuru ft)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("update FilmTurleri set TurAd = @TurAd, Aciklama = @Aciklama where FilmTurNo = @FilmTurNo", conn);
            comm.Parameters.Add("@TurAd", SqlDbType.VarChar).Value = ft._turAd;
            comm.Parameters.Add("@Aciklama", SqlDbType.VarChar).Value = ft._aciklama;
            comm.Parameters.Add("@FilmTurNo", SqlDbType.Int).Value = ft._filmTurNo;
            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                Sonuc = Convert.ToBoolean(comm.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            return Sonuc;
        }
    }
}
 