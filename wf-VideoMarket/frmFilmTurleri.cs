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
            txtAciklama.Clear();
            txtFilmTuru.Clear();
            txtFilmTuru.Focus();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtFilmTuru.Text.Trim() != "")
            {
                cFilmTuru ft = new cFilmTuru();
                if (ft.FilmTurKontrol(txtFilmTuru.Text))
                {
                    //Önceden kayıtlı mı? (true-false)
                    MessageBox.Show("Sistemde kayıtlı olan bir isim girdiniz!", "Önceden girilmiş");
                }
                else
                {
                    //Yeni girilen filmTuru sisteme kaydedilecek.
                    ft.TurAdi = txtFilmTuru.Text;
                    ft.Aciklama = txtAciklama.Text;
                    if (ft.FilmTuruEkle(ft))
                    {
                        MessageBox.Show("Film türü eklendi.", "Kayıt tamamlandı.");
                        ft.FilmTurleriGoster(lvFilmTurleri);
                        btnKaydet.Enabled = false;
                        Temizle();
                    }
                    else
                    {
                        MessageBox.Show("Kayıt ekleme gerçekleştirilemedi!", "Kayıt tamamlanamadı.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Film Türü Bilgisi Girmelisiniz!", "Dikkat! Eksik bilgi!");
            }
            txtFilmTuru.Focus();
        }
        private void lvFilmTurleri_DoubleClick(object sender, EventArgs e)
        {
            Temizle();
            cGenel.turNo = Convert.ToInt32(lvFilmTurleri.SelectedItems[0].SubItems[0].Text);
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
                if (ft.FilmTuruKontrolFromDegistir(txtFilmTuru.Text, cGenel.turNo))
                {
                    //Önceden kayıtlı mı? (true-false)
                    MessageBox.Show("Sistemde kayıtlı olan bir isim girdiniz!", "Önceden girilmiş");
                }
                else
                {
                    //Yeni girilen filmTuru sisteme kaydedilecek.
                    ft.FilmTurNo = cGenel.turNo;
                    ft.TurAdi = txtFilmTuru.Text;
                    ft.Aciklama = txtAciklama.Text;
                    if (ft.FilmTuruGuncelle(ft))
                    {
                        MessageBox.Show("Film türü güncellendi.", "Güncelleme tamamlandı.");
                        ft.FilmTurleriGoster(lvFilmTurleri);
                        btnKaydet.Enabled = false;
                        btnSil.Enabled = false;
                        Temizle();
                    }
                    else
                    {
                        MessageBox.Show("Kayıt güncelleme gerçekleştirilemedi!", "Güncelleme tamamlanamadı.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Film Türü Bilgisi Girmelisiniz!", "Dikkat! Eksik bilgi!");
            }
            txtFilmTuru.Focus();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Silmek istiyor musunuz?", "Silinsin mi?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cFilmTuru ft = new cFilmTuru();
                if (ft.FilmTuruSil(cGenel.turNo))
                {
                    MessageBox.Show("Film türü silindi.", "Silme işlemi tamamlandı.");
                    ft.FilmTurleriGoster(lvFilmTurleri);
                    btnKaydet.Enabled = false;
                    btnSil.Enabled = false;
                    Temizle();
                }
                else
                {
                    MessageBox.Show("Film türü silinemedi.", "Dikkat! Silme işlemi tamamlanamadı!");
                }
            }
        }
    
        
    }
}
