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
        private string _turAdi;
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

        public string TurAdi
        {
            get
            {
                return _turAdi;
            }

            set
            {
                _turAdi = value.Substring(0, 1).ToUpper() + value.Substring(1).ToLower();
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

        public bool FilmTurKontrol(string filmTuru)
        {
            bool sonuc = false;
            SqlCommand comm = new SqlCommand("select * from filmTurleri where turAdi=@turAdi and silindi=0", conn);
            comm.Parameters.Add("@turAdi", SqlDbType.VarChar).Value = filmTuru;
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlDataReader dr;
            try
            {
                dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    sonuc = true;
                }
                dr.Close();
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return sonuc;
        }
        public bool FilmTuruKontrolFromDegistir(string FilmTuru, int TurNo)
        {
            bool sonuc = false;
            SqlCommand comm = new SqlCommand("select * from filmTurleri where turAdi=@turAdi and filmTurNo!=@filmTurNo and silindi=0", conn);
            comm.Parameters.Add("@turAdi", SqlDbType.VarChar).Value = FilmTuru;
            comm.Parameters.Add("@filmTurNo", SqlDbType.Int).Value = TurNo;
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlDataReader dr;
            try
            {
                dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    sonuc = true;
                }
                dr.Close();
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }
            return sonuc;
        }


        public void FilmTurleriGoster(ListView liste)
        {
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("select * from filmTurleri where silindi=0", conn);
            conn.Open();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlDataReader dr; //new ile tanımlanmıyor.
            try
            {
                //Çalışırken hata ile karşılaşılabilecek işlemler try içine yazılır.
                dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    //Eğer DataReader içinde data varsa, HasRows true değeri alır.
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
            catch (SqlException ex) //Hata durumunda çalışma catch bloklarından devam eder.
            {
                //Bütün hatalar Exception sınıfı tarafından yakalanır.
                //Sql ile ilgili daha detaylı hata bildirimi almak için SqlException kullanılır.
                string hata = ex.Message;
            }
            finally
            {
                //finally kullanılmak zorunda değil!
                //Hata olsa da olmasa da finally bloğu mutlaka çalışır.
                conn.Close();
            }
        }
        //public void FilmTurleriGoster(ComboBox liste)
        //{
        //    liste.Items.Clear();
        //    SqlCommand comm = new SqlCommand("select * from filmTurleri where silindi=0", conn);

        //    if (conn.State == ConnectionState.Closed)
        //    {
        //        conn.Open();
        //    }
        //    SqlDataReader dr; //new ile tanımlanmıyor.
        //    try
        //    {
        //        //Çalışırken hata ile karşılaşılabilecek işlemler try içine yazılır.
        //        dr = comm.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            while (dr.Read())
        //            {
        //                liste.Items.Add(dr["turAdi"].ToString());
        //            }
        //        }
        //    }
        //    catch (SqlException ex) //Hata durumunda çalışma catch bloklarından devam eder.
        //    {
        //        //Bütün hatalar Exception sınıfı tarafından yakalanır.
        //        //Sql ile ilgili daha detaylı hata bildirimi almak için SqlException kullanılır.
        //        string hata = ex.Message;
        //    }
        //    finally
        //    {
        //        //finally kullanılmak zorunda değil!
        //        //Hata olsa da olmasa da finally bloğu mutlaka çalışır.
        //        conn.Close();
        //    }
        //}

        public void FilmTurleriGoster(ComboBox liste)
        {
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("select * from filmTurleri where silindi=0", conn);

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlDataReader dr; //new ile tanımlanmıyor.
            try
            {
                //Çalışırken hata ile karşılaşılabilecek işlemler try içine yazılır.
                dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        cFilmTuru ft = new cFilmTuru();
                        ft.FilmTurNo = Convert.ToInt32(dr[0]);
                        ft.TurAdi = dr[1].ToString();
                        liste.Items.Add(ft);
                    }
                }
            }
            catch (SqlException ex) //Hata durumunda çalışma catch bloklarından devam eder.
            {
                //Bütün hatalar Exception sınıfı tarafından yakalanır.
                //Sql ile ilgili daha detaylı hata bildirimi almak için SqlException kullanılır.
                string hata = ex.Message;
            }
            finally
            {
                //finally kullanılmak zorunda değil!
                //Hata olsa da olmasa da finally bloğu mutlaka çalışır.
                conn.Close();
            }
        }
        public bool FilmTuruEkle(cFilmTuru ft)
        {
            bool sonuc = false;
            SqlCommand comm = new SqlCommand("insert into filmTurleri (turAdi, aciklama) values(@turAdi, @aciklama)", conn);
            comm.Parameters.Add("@turAdi", SqlDbType.VarChar).Value = ft._turAdi;
            comm.Parameters.Add("@aciklama", SqlDbType.VarChar).Value = ft._aciklama;
            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                sonuc = Convert.ToBoolean(comm.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }

            return sonuc;
        }
        public bool FilmTuruGuncelle(cFilmTuru ft)
        {
            bool sonuc = false;
            SqlCommand comm = new SqlCommand("update filmTurleri set turAdi=@turAdi, aciklama=@aciklama where filmTurNo=@filmTurNo", conn);
            comm.Parameters.Add("@turAdi", SqlDbType.VarChar).Value = ft._turAdi;
            comm.Parameters.Add("@aciklama", SqlDbType.VarChar).Value = ft._aciklama;
            comm.Parameters.Add("@filmTurNo", SqlDbType.VarChar).Value = ft._filmTurNo;
            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                sonuc = Convert.ToBoolean(comm.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }

            return sonuc;
        }

        public bool FilmTuruSil(int ID)
        {
            bool sonuc = false;
            SqlCommand comm = new SqlCommand("update filmTurleri set silindi=1 where  filmTurNo=@filmTurNo", conn);
            comm.Parameters.Add("@filmTurNo", SqlDbType.Int).Value = ID;
            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                sonuc = Convert.ToBoolean(comm.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }
            return sonuc;
        }

        public int FilmTurNoGetir(string filmTuru)
        {
            int turNo = 0;
            SqlCommand comm = new SqlCommand("select filmTurNo from filmTurleri where turAdi= @turAdi and silindi=0", conn);
            comm.Parameters.Add("@turAdi", SqlDbType.VarChar).Value = filmTuru;
            if (conn.State == ConnectionState.Closed) { conn.Open(); }
            try { turNo = Convert.ToInt32(comm.ExecuteScalar()); }
            catch (SqlException ex) { string hata = ex.Message; }
            finally { conn.Close(); }
            return turNo;
        }



        public override string ToString()
        {
            return TurAdi;
        }
    }
}
