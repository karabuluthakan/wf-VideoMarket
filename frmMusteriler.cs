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
    public partial class frmMusteriler : Form
    {
        public frmMusteriler()
        {
            InitializeComponent();
        }

        private void frmMusteriler_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            cMusteri m = new wf_VideoMarket.cMusteri();
            m.MusterileriGoster(lvMusteriler);
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
            if (txtAdi.Text.Trim() != "" && txtSoyadi.Text.Trim() != "" && txtTelefon.Text.Trim() != "")
            {
                cMusteri m = new cMusteri();
                m.MusteriAd = txtAdi.Text;  //Property'lere gidip Set çalışarak filtreler uygulanıyor. 
                m.MusteriSoyad = txtSoyadi.Text;
                m.Telefon = txtTelefon.Text;
                if (m.MusteriKontrol(m))    //Önceden kayıtlı mı? (true-false)
                {
                    MessageBox.Show("Zaten sistemde kayıtlı!", "Önceden Girilmiş!");
                }
                else
                {
                    //Yeni girilen müşteri sisteme kayıt edilecek.
                    m.Adres = txtAdres.Text;    //Diğer özellikler yukarda eklenmişti.
                    if (m.MusteriEkle(m))
                    {
                        MessageBox.Show("Müşteri eklendi.", "Kayıt tamamlandı.");
                        m.MusterileriGoster(lvMusteriler);
                        btnKaydet.Enabled = false;
                        Temizle();
                    }
                    else { MessageBox.Show("Kayıt ekleme gerçekleşmedi!", "Kayıt tamamlanamadı!"); }
                }
            }
            else { MessageBox.Show("Müşteri Adı, Soyadı, Telefon bilgisi girmelisiniz!", "Dikkat! Eksik Bilgi!"); }
            txtAdi.Focus();
        }
        private void btnDegistir_Click(object sender, EventArgs e)
        {
            if (txtAdi.Text.Trim() != "" && txtSoyadi.Text.Trim() != "" && txtTelefon.Text.Trim() != "")
            {
                cMusteri m = new cMusteri();
                m.MusteriAd = txtAdi.Text;   
                m.MusteriSoyad = txtSoyadi.Text;
                m.Telefon = txtTelefon.Text;
                m.MusteriNo = cGenel.musterino;
                if (m.MusteriKontrolFromDegistir(m))    //Önceden kayıtlı mı? (true-false)
                {
                    MessageBox.Show("Zaten sistemde kayıtlı!", "Önceden Girilmiş!");
                }
                else
                {
                    m.Adres = txtAdres.Text;    //Diğer özellikler yukarda eklenmişti.
                    if (m.MusteriGuncelle(m))
                    {
                        MessageBox.Show("Müşteri güncellendi.", "Değişiklik tamamlandı.");
                        m.MusterileriGoster(lvMusteriler);
                        btnDegistir.Enabled = false;
                        btnSil.Enabled = false;
                        Temizle();
                    }
                    else { MessageBox.Show("Kayıt güncelleme gerçekleşmedi!", "Değişiklik tamamlanamadı!"); }
                }
            }
            else { MessageBox.Show("Müşteri Adı, Soyadı, Telefon bilgisi girmelisiniz!", "Dikkat! Eksik Bilgi!"); }
            txtAdi.Focus();
        }
        private void Temizle()
        {
            txtAdi.Clear();
            txtSoyadi.Clear();
            txtTelefon.Clear();
            txtAdres.Clear();
            txtAdi.Focus();
        }
        private void lvMusteriler_DoubleClick(object sender, EventArgs e)
        {
            cGenel.musterino = Convert.ToInt32(lvMusteriler.SelectedItems[0].SubItems[0].Text);
            txtAdi.Text = lvMusteriler.SelectedItems[0].SubItems[1].Text;
            txtSoyadi.Text = lvMusteriler.SelectedItems[0].SubItems[2].Text;
            txtTelefon.Text = lvMusteriler.SelectedItems[0].SubItems[3].Text;
            txtAdres.Text = lvMusteriler.SelectedItems[0].SubItems[4].Text;
            btnDegistir.Enabled = true;
            btnSil.Enabled = true;
            btnKaydet.Enabled = false;
            txtAdi.Focus();
        }

        private void txtAdaGore_TextChanged(object sender, EventArgs e)
        {
            cMusteri m = new wf_VideoMarket.cMusteri();
            m.MusterileriGosterByAdaGore(txtAdaGore.Text, lvMusteriler);
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Silmek İstiyor musunuz?", "SİLİNSİN Mİ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cMusteri m = new cMusteri();
                if (m.MusteriSil(cGenel.musterino))
                {
                    MessageBox.Show("Müşteri bilgileri silindi.", "Silme tamamlandı.");
                    m.MusterileriGoster(lvMusteriler);
                    btnDegistir.Enabled = false;
                    btnSil.Enabled = false;
                    Temizle();
                }
                else { MessageBox.Show("Müşteri silinemedi!", "Dikkat! Silme tamamlanamadı!"); }
            }
        }
    }
}
