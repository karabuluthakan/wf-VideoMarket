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
    public partial class frmFilmTurleri : Form
    {
        public frmFilmTurleri()
        {
            InitializeComponent();
        }
        private void frmFilmTurleri_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            cFilmTuru ft = new cFilmTuru();
            ft.FilmTurleriGoster(lvFilmTurleri);
        }
        private void btnYeni_Click(object sender, EventArgs e)
        {
            btnKaydet.Enabled = true;
            btnDegistir.Enabled = false;
            btnSil.Enabled = false;
            Temizle();
        }
        private void Temizle()
        {
            txtFilmTuru.Clear();
            txtAciklama.Clear();
            txtFilmTuru.Focus();
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if(txtFilmTuru.Text.Trim() != "")
            {
                cFilmTuru ft = new cFilmTuru();
                if(ft.FilmTuruKontrol(txtFilmTuru.Text))    //Önceden kayıtlı mı? (true-false)
                {
                    MessageBox.Show("Zaten sistemde kayıtlı!", "Önceden Girilmiş!");
                }
                else
                {
                    //Yeni girilen FilmTuru sisteme kayıt edilecek.
                    ft.TurAd = txtFilmTuru.Text;
                    ft.Aciklama = txtAciklama.Text;
                    if(ft.FilmTuruEkle(ft))
                    {
                        MessageBox.Show("Film Türü eklendi.", "Kayıt tamamlandı.");
                        ft.FilmTurleriGoster(lvFilmTurleri);
                        btnKaydet.Enabled = false;
                        Temizle();
                    }
                    else { MessageBox.Show("Kayıt ekleme gerçekleşmedi!", "Kayıt tamamlanamadı!"); }
                }
            }
            else { MessageBox.Show("Film Türü bilgisi girmelisiniz!", "Dikkat! Eksik Bilgi!"); }
            txtFilmTuru.Focus();
        }
        private void lvFilmTurleri_DoubleClick(object sender, EventArgs e)
        {
            cGenel.turno = Convert.ToInt32(lvFilmTurleri.SelectedItems[0].SubItems[0].Text);
            txtFilmTuru.Text = lvFilmTurleri.SelectedItems[0].SubItems[1].Text;
            txtAciklama.Text = lvFilmTurleri.SelectedItems[0].SubItems[2].Text;
            btnDegistir.Enabled = true;
            btnSil.Enabled = true;
            btnKaydet.Enabled = false;
            txtFilmTuru.Focus();
        }
        private void btnDegistir_Click(object sender, EventArgs e)
        {
            if (txtFilmTuru.Text.Trim() != "")
            {
                cFilmTuru ft = new cFilmTuru();
                if (ft.FilmTuruKontrolFromDegistir(txtFilmTuru.Text, cGenel.turno))    //Değiştirilecek kayıttan başka önceden kayıtlı bir FilmTürü giriliyorsa uyarsın? (true-false)
                {
                    MessageBox.Show("Zaten sistemde kayıtlı!", "Önceden Girilmiş!");
                }
                else
                {
                    ft.FilmTurNo = cGenel.turno;
                    ft.TurAd = txtFilmTuru.Text;
                    ft.Aciklama = txtAciklama.Text;
                    if (ft.FilmTuruGuncelle(ft))
                    {
                        MessageBox.Show("Film Türü güncellendi.", "Değişiklik tamamlandı.");
                        ft.FilmTurleriGoster(lvFilmTurleri);
                        btnDegistir.Enabled = false;
                        btnSil.Enabled = false;
                        Temizle();
                    }
                    else { MessageBox.Show("Kayıt güncelleme gerçekleşmedi!", "Değişiklik tamamlanamadı!"); }
                }
            }
            else { MessageBox.Show("Film Türü bilgisi girmelisiniz!", "Dikkat! Eksik Bilgi!"); }
            txtFilmTuru.Focus();
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Silmek İstiyor musunuz?", "SİLİNSİN Mİ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cFilmTuru ft = new cFilmTuru();
                if(ft.FilmTuruSil(cGenel.turno))
                {
                    MessageBox.Show("Film Türü silindi.", "Silme tamamlandı.");
                    ft.FilmTurleriGoster(lvFilmTurleri);
                    btnDegistir.Enabled = false;
                    btnSil.Enabled = false;
                    Temizle();
                }
                else { MessageBox.Show("Film Türü silinemedi!", "Dikkat! Silme tamamlanamadı!"); }
            }
        }
    }
}
