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

            cFilm f = new wf_VideoMarket.cFilm();
            f.FilmleriGoster(lvFilmler);

            cFilmTuru ft = new cFilmTuru();
            ft.FilmTurleriGoster(cbFilmTurleri);
        }
        private void cbFilmTurleri_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtFilmTuru.Text = cbFilmTurleri.SelectedItem.ToString();
            //cFilmTuru ft = new cFilmTuru();
            //cGenel.turno = ft.FilmTurNoGetirByFilmTuru(txtFilmTuru.Text);
            cFilmTuru ft = (cFilmTuru)cbFilmTurleri.SelectedItem;
            //cFilmTuru ft = cbFilmTurleri.SelectedItem as cFilmTuru;
            txtFilmTuru.Text = ft.TurAd;
            cGenel.turno = ft.FilmTurNo;
            txtYonetmen.Focus();
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
            if (txtFilmAdi.Text.Trim() != "" && txtYonetmen.Text.Trim() != "" && txtFilmTuru.Text.Trim() != "")
            {
                cFilm f = new cFilm();
                f.FilmAd = txtFilmAdi.Text;  //Property'lere gidip Set çalışarak filtreler uygulanıyor. 
                f.Yonetmen = txtYonetmen.Text;
                if (f.FilmKontrol(f))    //Önceden kayıtlı mı? (true-false)
                {
                    MessageBox.Show("Zaten sistemde kayıtlı!", "Önceden Girilmiş!");
                }
                else
                {
                    f.FilmTurNo = cGenel.turno;    //Diğer özellikler yukarda eklenmişti.
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
                    catch(Exception)
                    {
                        MessageBox.Show("Fiyat alanını kontrol ediniz!", "Dikkat! Hatalı Fiyat girişi!");
                        txtFiyat.Focus(); return;
                    }
                    try
                    {
                        f.Miktar = Convert.ToInt32(txtMiktar.Text);
                    }
                    catch (FormatException)
                    {
                        f.Miktar = 10;  //Sayı girilmediğinde yada boş geçildiğinde default olarak 10
                    }                                                               //kabul edilir.
                    catch (Exception)
                    {
                        MessageBox.Show("Miktar alanını kontrol ediniz!", "Dikkat! Hatalı Miktar girişi!");
                        txtMiktar.Focus(); return;
                    }
                    
                    if (f.FilmEkle(f))
                    {
                        MessageBox.Show("Film bilgileri eklendi.", "Kayıt tamamlandı.");
                        f.FilmleriGoster(lvFilmler);
                        btnKaydet.Enabled = false;
                        Temizle();
                    }
                    else { MessageBox.Show("Kayıt ekleme gerçekleşmedi!", "Kayıt tamamlanamadı!"); }
                }
            }
            else { MessageBox.Show("Film Adı, Türü, Yönetmen bilgisi girmelisiniz!", "Dikkat! Eksik Bilgi!"); }
            txtFilmAdi.Focus();
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
        private void lvFilmler_DoubleClick(object sender, EventArgs e)
        {
            cGenel.filmno = Convert.ToInt32(lvFilmler.SelectedItems[0].SubItems[0].Text);
            txtFilmAdi.Text = lvFilmler.SelectedItems[0].SubItems[1].Text;
            cGenel.turno = Convert.ToInt32(lvFilmler.SelectedItems[0].SubItems[2].Text);
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
        private void btnDegistir_Click(object sender, EventArgs e)
        {
            if (txtFilmAdi.Text.Trim() != "" && txtYonetmen.Text.Trim() != "" && txtFilmTuru.Text.Trim() != "")
            {
                cFilm f = new cFilm();
                f.FilmAd = txtFilmAdi.Text;  //Property'lere gidip Set çalışarak filtreler uygulanıyor. 
                f.Yonetmen = txtYonetmen.Text;
                f.FilmNo = cGenel.filmno;
                if (f.FilmKontrolFromDegistir(f))    //Önceden kayıtlı mı? (true-false)
                {
                    MessageBox.Show("Zaten sistemde kayıtlı!", "Önceden Girilmiş!");
                }
                else
                {
                    f.FilmTurNo = cGenel.turno;    //Diğer özellikler yukarda eklenmişti.
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
                        MessageBox.Show("Fiyat alanını kontrol ediniz!", "Dikkat! Hatalı Fiyat girişi!");
                        txtFiyat.Focus(); return;
                    }
                    try
                    {
                        f.Miktar = Convert.ToInt32(txtMiktar.Text);
                    }
                    catch (FormatException)
                    {
                        f.Miktar = 10;  //Sayı girilmediğinde yada boş geçildiğinde default olarak 10
                    }                                                               //kabul edilir.
                    catch (Exception)
                    {
                        MessageBox.Show("Miktar alanını kontrol ediniz!", "Dikkat! Hatalı Miktar girişi!");
                        txtMiktar.Focus(); return;
                    }
                    if (f.FilmGuncelle(f))
                    {
                        MessageBox.Show("Film bilgileri güncellendi.", "Değişiklik tamamlandı.");
                        f.FilmleriGoster(lvFilmler);
                        btnKaydet.Enabled = false;
                        Temizle();
                    }
                    else { MessageBox.Show("Güncelleme gerçekleşmedi!", "Değişiklik tamamlanamadı!"); }
                }
            }
            else { MessageBox.Show("Film Adı, Türü, Yönetmen bilgisi girmelisiniz!", "Dikkat! Eksik Bilgi!"); }
            txtFilmAdi.Focus();
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Silmek İstiyor musunuz?", "SİLİNSİN Mİ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cFilm f = new cFilm();
                if (f.FilmSil(cGenel.filmno))
                {
                    MessageBox.Show("Film bilgileri silindi.", "Silme tamamlandı.");
                    f.FilmleriGoster(lvFilmler);
                    btnDegistir.Enabled = false;
                    btnSil.Enabled = false;
                    Temizle();
                }
                else { MessageBox.Show("Film bilgileri silinemedi!", "Dikkat! Silme tamamlanamadı!"); }
            }
        }
        private void txtAdaGore_TextChanged(object sender, EventArgs e)
        {
            cFilm f = new cFilm();
            f.FilmleriGosterByAdaGore(txtAdaGore.Text, lvFilmler);
        }
    }
}
