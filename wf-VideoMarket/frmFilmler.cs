using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf_VideoMarket
{
    public partial class frmFilmler : Form
    {
        public frmFilmler()
        {
            InitializeComponent();
        }

        private void frmFilmler_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;

            cFilm f = new cFilm();
            f.FilmleriGoster(lvFilmler);

            cFilmTuru ft = new cFilmTuru();
            ft.FilmTurleriGoster(cbFilmTurleri);
        }

        private void cbFilmTurleri_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtFilmTuru.Text = cbFilmTurleri.SelectedItem.ToString();
            //cFilmTuru ft = new cFilmTuru();
            //cGenel.turNo = ft.FilmTurNoGetir(txtFilmTuru.Text);
            cFilmTuru ft = (cFilmTuru)cbFilmTurleri.SelectedItem;
            txtFilmTuru.Text = ft.TurAdi;
            cGenel.turNo = ft.FilmTurNo;
            txtYonetmen.Focus();
        }

        private void Temizle()
        {
            txtFilmAdi.Clear();
            txtYonetmen.Clear();
            txtOyuncular.Clear();
            txtOzet.Clear();
            txtFiyat.Text = "0";
            txtMiktar.Text = "10";
            txtFilmAdi.Focus();
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            btnKaydet.Enabled = true;
            btnDegistir.Enabled = false;
            btnSil.Enabled = false;
            Temizle();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtFilmAdi.Text.Trim() != "" && txtFilmTuru.Text.Trim() != "" && txtYonetmen.Text.Trim() != "")
            {
                cFilm f = new cFilm();
                f.FilmAdi = txtFilmAdi.Text;
                f.Yonetmen = txtYonetmen.Text;
                if (f.FilmKontrol(f))
                {
                    MessageBox.Show("Sistemde kayıtlı bir film girdiniz!", "Önceden girilmiş!");
                }
                else
                {
                    f.FilmTurNo = cGenel.turNo;
                    f.Oyuncular = txtOyuncular.Text;
                    f.Ozet = txtOzet.Text;
                    try
                    {
                        f.Fiyat = Convert.ToDouble(txtFiyat.Text);
                    }
                    catch (FormatException) //Sayı bulup çeviremezse düşeceği hata FormatException olur.
                    {
                        f.Fiyat = 0;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Fiyat alanını kontrol ediniz!", "Dikkat! Hatalı Fiyat girişi!");
                        txtFiyat.Focus();
                        return; //Bu aşamada hata yakalanıyorsa metotdan çıkması için return kullanılır.
                    }
                    try
                    {
                        f.Miktar = Convert.ToInt32(txtMiktar.Text);
                    }
                    catch (FormatException) //Sayı bulup çeviremezse düşeceği hata FormatException olur.
                    {
                        f.Miktar = 10; //Sayı girilmediğinde ya da boş geçildiğinde default olarak 10 atar.
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Miktar alanını kontrol ediniz!", "Dikkat! Hatalı Miktar girişi!");
                        txtMiktar.Focus();
                        return; //Bu aşamada hata yakalanıyorsa metotdan çıkması için return kullanılır.
                    }
                }
                if (f.FilmEkle(f))
                {
                    MessageBox.Show("Film bilgileri eklendi.", "Kayıt tamamlandı.");
                    f.FilmleriGoster(lvFilmler);
                    btnKaydet.Enabled = false;
                    Temizle();
                }
            }
        }

        private void btnDegistir_Click(object sender, EventArgs e)
        {
            if (txtFilmAdi.Text.Trim() != "" && txtFilmTuru.Text.Trim() != "" && txtYonetmen.Text.Trim() != "")
            {
                cFilm f = new cFilm();
                f.FilmAdi = txtFilmAdi.Text;
                f.Yonetmen = txtYonetmen.Text;
                f.FilmNo = cGenel.filmNo;
                if (f.FilmKontrolFromDegistir(f))
                { MessageBox.Show("Sistemde kayıtlı olan bir film girdiniz!", "Önceden girilmiş"); }
                else
                {
                    f.FilmTurNo = cGenel.turNo;
                    f.Oyuncular = txtOyuncular.Text;
                    f.Ozet = txtOzet.Text;
                    try
                    {
                        f.Fiyat = Convert.ToDouble(txtFiyat.Text);
                    }
                    catch (FormatException)
                    {
                        f.Fiyat = 0;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Fiyat alanını kontrol ediniz!", "Dikkat hatalı fiyat girişi!");
                        txtFiyat.Focus();
                        return;
                    }
                    try
                    {
                        f.Miktar = Convert.ToInt32(txtMiktar.Text);
                    }
                    catch (FormatException)
                    {
                        f.Miktar = 10;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Miktar alanını kontrol ediniz!", "Dikkat hatalı miktar girişi!");
                        txtMiktar.Focus();
                        return;
                    }
                    
                    if (f.FilmGuncelle(f))
                    {
                        MessageBox.Show("Film bilgileri güncellendi.", "Güncelleme tamamlandı.");
                        f.FilmleriGoster(lvFilmler);
                        btnKaydet.Enabled = false;
                        btnSil.Enabled = false;
                        Temizle();
                    }
                    else { MessageBox.Show("Kayıt güncelleme gerçekleştirilemedi!", "Güncelleme tamamlanamadı."); }
                }
            }
            else { MessageBox.Show("Film adı ve yönetmen bilgilerini girmelisiniz!", "Dikkat! Eksik bilgi!"); }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Silmek istiyor musunuz?", "Silinsin mi?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cFilm f = new cFilm();
                if (f.FilmSil(cGenel.filmNo))
                {
                    MessageBox.Show("Film silindi.", "Silme işlemi tamamlandı.");
                    f.FilmleriGoster(lvFilmler);
                    btnKaydet.Enabled = false;
                    btnSil.Enabled = false;
                    Temizle();
                }
                else { MessageBox.Show("Film silinemedi.", "Dikkat! Silme işlemi tamamlanamadı!"); }
            }
        }

        private void lvFilmler_DoubleClick(object sender, EventArgs e)
        {
            Temizle();
            cGenel.filmNo = Convert.ToInt32(lvFilmler.SelectedItems[0].SubItems[0].Text);
            txtFilmAdi.Text = lvFilmler.SelectedItems[0].SubItems[1].Text;
            cGenel.turNo = Convert.ToInt32(lvFilmler.SelectedItems[0].SubItems[2].Text);
            txtFilmTuru.Text = lvFilmler.SelectedItems[0].SubItems[3].Text;
            txtYonetmen.Text = lvFilmler.SelectedItems[0].SubItems[4].Text;
            txtOyuncular.Text = lvFilmler.SelectedItems[0].SubItems[5].Text;
            txtOzet.Text = lvFilmler.SelectedItems[0].SubItems[6].Text;
            txtFiyat.Text = lvFilmler.SelectedItems[0].SubItems[7].Text;
            txtMiktar.Text = lvFilmler.SelectedItems[0].SubItems[8].Text;
            btnDegistir.Enabled = true;
            btnSil.Enabled = true;
            btnKaydet.Enabled = false;
            txtFilmAdi.Focus();
        }

        private void txtFilmArama_TextChanged(object sender, EventArgs e)
        {
            cFilm f = new cFilm();
            f.FilmSorgula(txtFilmArama.Text, lvFilmler);
        }
    }
}



