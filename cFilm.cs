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
        private string _filmAd;
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

        public string FilmAd
        {
            get
            {
                return _filmAd;
            }

            set
            {
                _filmAd = value.Substring(0, 1).ToUpper() + value.Substring(1).ToLower();
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

        public void FilmleriGoster(ListView liste)
        {
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("Select FilmNo, FilmAd, Filmler.FilmTurNo, TurAd, Yonetmen, Oyuncular, Ozet, Fiyat, Miktar from Filmler inner join FilmTurleri on Filmler.FilmTurNo = FilmTurleri.FilmTurNo where Varmi=1", conn);
            if (conn.State == ConnectionState.Closed) conn.Open();
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
            catch (SqlException ex)   //Hata durumunda çalışma catch bloklarından devam eder.
            {                   //Bütün hatalar Exception sınıfı tarafından yakalanır.
                string hata = ex.Message;
            }
            finally { conn.Close(); }   //Hata olsa da olmasa da finally bloğu mutlaka çalışır.
        }
        public void FilmleriGosterByAdaGore(string AdaGore, ListView liste)
        {
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("Select FilmNo, FilmAd, Filmler.FilmTurNo, TurAd, Yonetmen, Oyuncular, Ozet, Fiyat, Miktar from Filmler inner join FilmTurleri on Filmler.FilmTurNo = FilmTurleri.FilmTurNo where FilmAd like @FilmAd + '%' and Varmi=1", conn);
            comm.Parameters.Add("@FilmAd", SqlDbType.VarChar).Value = AdaGore;
            if (conn.State == ConnectionState.Closed) conn.Open();
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
            catch (SqlException ex)   //Hata durumunda çalışma catch bloklarından devam eder.
            {                   //Bütün hatalar Exception sınıfı tarafından yakalanır.
                string hata = ex.Message;
            }
            finally { conn.Close(); }   //Hata olsa da olmasa da finally bloğu mutlaka çalışır.
        }
        public bool FilmKontrol(cFilm f)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("Select * from Filmler where FilmAd = @FilmAd and Yonetmen = @Yonetmen and Varmi=1", conn);
            comm.Parameters.Add("@FilmAd", SqlDbType.VarChar).Value = f.FilmAd;
            comm.Parameters.Add("@Yonetmen", SqlDbType.VarChar).Value = f.Yonetmen;
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
        public bool FilmKontrolFromDegistir(cFilm f)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("Select * from Filmler where FilmAd = @FilmAd and Yonetmen = @Yonetmen and FilmNo != @FilmNo and Varmi=1", conn);
            comm.Parameters.Add("@FilmAd", SqlDbType.VarChar).Value = f.FilmAd;
            comm.Parameters.Add("@Yonetmen", SqlDbType.VarChar).Value = f.Yonetmen;
            comm.Parameters.Add("@FilmNo", SqlDbType.Int).Value = f.FilmNo;
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
        public bool FilmEkle(cFilm f)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("insert into Filmler (FilmAd, FilmTurNo, Yonetmen, Oyuncular, Ozet, Fiyat, Miktar) values(@FilmAd, @FilmTurNo, @Yonetmen, @Oyuncular, @Ozet, @Fiyat, @Miktar)", conn);
            comm.Parameters.Add("@FilmAd", SqlDbType.VarChar).Value = f._filmAd;
            comm.Parameters.Add("@FilmTurNo", SqlDbType.Int).Value = f._filmTurNo;
            comm.Parameters.Add("@Yonetmen", SqlDbType.VarChar).Value = f._yonetmen;
            comm.Parameters.Add("@Oyuncular", SqlDbType.VarChar).Value = f._oyuncular;
            comm.Parameters.Add("@Ozet", SqlDbType.VarChar).Value = f._ozet;
            comm.Parameters.Add("@Fiyat", SqlDbType.Money).Value = f._fiyat;
            comm.Parameters.Add("@Miktar", SqlDbType.Int).Value = f._miktar;
            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                Sonuc = Convert.ToBoolean(comm.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }
            return Sonuc;
        }
        public bool FilmGuncelle(cFilm f)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("update Filmler set FilmAd=@FilmAd, FilmTurNo=@FilmTurNo, Yonetmen=@Yonetmen, Oyuncular=@Oyuncular, Ozet=@Ozet, Fiyat=@Fiyat, Miktar=@Miktar where FilmNo=@FilmNo", conn);
            comm.Parameters.Add("@FilmAd", SqlDbType.VarChar).Value = f._filmAd;
            comm.Parameters.Add("@FilmTurNo", SqlDbType.Int).Value = f._filmTurNo;
            comm.Parameters.Add("@Yonetmen", SqlDbType.VarChar).Value = f._yonetmen;
            comm.Parameters.Add("@Oyuncular", SqlDbType.VarChar).Value = f._oyuncular;
            comm.Parameters.Add("@Ozet", SqlDbType.VarChar).Value = f._ozet;
            comm.Parameters.Add("@Fiyat", SqlDbType.Money).Value = f._fiyat;
            comm.Parameters.Add("@Miktar", SqlDbType.Int).Value = f._miktar;
            comm.Parameters.Add("@FilmNo", SqlDbType.Int).Value = f._filmNo;
            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                Sonuc = Convert.ToBoolean(comm.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }
            return Sonuc;
        }
        public bool FilmSil(int ID)   
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("update Filmler set Varmi = 0 where FilmNo = @FilmNo", conn);
            comm.Parameters.Add("@FilmNo", SqlDbType.Int).Value = ID;
            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                Sonuc = Convert.ToBoolean(comm.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }
            return Sonuc;
        }
    }
}
