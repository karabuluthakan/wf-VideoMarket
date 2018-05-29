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
            cMusteri m = new cMusteri();
            m.MusterileriGoster(lvMusteriler);
        }
        private void Temizle()
        {
            //txtMusteriAdi.Clear();
            //txtMusteriSoyadi.Clear();
            //txtMusteriTelefonu.Clear();
            //txtMusteriAdresi.Clear();
            //txtMusteriArama.Clear();
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    TextBox txt = item as TextBox;
                    txt.Clear();
                }
            }
            txtMusteriAdi.Focus();
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
            if (txtMusteriAdi.Text.Trim() != "" && txtMusteriSoyadi.Text.Trim() != "" && txtMusteriTelefonu.Text.Trim() != "")
            {
                cMusteri m = new cMusteri();
                if (m.MusteriKontrol(m))
                { MessageBox.Show("Sistemde kayıtlı olan bir müşteri girdiniz!", "Önceden girilmiş"); }
                else
                {
                    m.MusteriAdi = txtMusteriAdi.Text;
                    m.MusteriSoyadi = txtMusteriSoyadi.Text;
                    m.Telefon = txtMusteriTelefonu.Text;
                    m.Adres = txtMusteriAdresi.Text;
                    if (m.MusteriEkle(m))
                    {
                        MessageBox.Show("Müşteri eklendi.", "Kayıt tamamlandı.");
                        m.MusterileriGoster(lvMusteriler);
                        btnKaydet.Enabled = false;
                        Temizle();
                    }
                    else { MessageBox.Show("Kayıt ekleme gerçekleştirilemedi!", "Kayıt tamamlanamadı."); }
                }
            }
            else { MessageBox.Show("Müşteri adı, soyadı ve telefon bilgilerini girmelisiniz!", "Dikkat! Eksik bilgi!"); }
            txtMusteriAdi.Focus();
        }

        private void btnDegistir_Click(object sender, EventArgs e)
        {
            if (txtMusteriAdi.Text.Trim() != "" && txtMusteriSoyadi.Text.Trim() != "" && txtMusteriTelefonu.Text.Trim() != "")
            {
                cMusteri m = new cMusteri();
                if (m.MusteriKontrolFromDegistir(txtMusteriAdi.Text, txtMusteriSoyadi.Text, txtMusteriTelefonu.Text, cGenel.musteriID))
                { MessageBox.Show("Sistemde kayıtlı olan bir müşteri girdiniz!", "Önceden girilmiş"); }
                else
                {
                    m.MusteriNo = cGenel.musteriID;
                    m.MusteriAdi = txtMusteriAdi.Text;
                    m.MusteriSoyadi = txtMusteriSoyadi.Text;
                    m.Telefon = txtMusteriTelefonu.Text;
                    m.Adres = txtMusteriAdresi.Text;
                    if (m.MusteriGuncelle(m))
                    {
                        MessageBox.Show("Müşteri bilgileri güncellendi.", "Güncelleme tamamlandı.");
                        m.MusterileriGoster(lvMusteriler);
                        btnKaydet.Enabled = false;
                        btnSil.Enabled = false;
                        Temizle();
                    }
                    else { MessageBox.Show("Kayıt güncelleme gerçekleştirilemedi!", "Güncelleme tamamlanamadı."); }
                }
            }
            else { MessageBox.Show("Müşteri adı, soyadı ve telefon bilgilerini girmelisiniz!", "Dikkat! Eksik bilgi!"); }
            txtMusteriAdi.Focus();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Silmek istiyor musunuz?", "Silinsin mi?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cMusteri m = new cMusteri();
                if (m.MusteriSil(cGenel.musteriID))
                {
                    MessageBox.Show("Müşteri bilgileri silindi.", "Silme işlemi tamamlandı.");
                    m.MusterileriGoster(lvMusteriler);
                    btnKaydet.Enabled = false;
                    btnSil.Enabled = false;
                    Temizle();
                }
                else { MessageBox.Show("Müşteri bilgileri silinemedi.", "Dikkat! Silme işlemi tamamlanamadı!"); }
            }
        }

        private void lvMusteriler_DoubleClick(object sender, EventArgs e)
        {
            Temizle();
            cGenel.musteriID = Convert.ToInt32(lvMusteriler.SelectedItems[0].SubItems[0].Text);
            txtMusteriAdi.Text = lvMusteriler.SelectedItems[0].SubItems[1].Text;
            txtMusteriSoyadi.Text = lvMusteriler.SelectedItems[0].SubItems[2].Text;
            txtMusteriTelefonu.Text = lvMusteriler.SelectedItems[0].SubItems[3].Text;
            txtMusteriAdresi.Text = lvMusteriler.SelectedItems[0].SubItems[4].Text;
            btnDegistir.Enabled = true;
            btnSil.Enabled = true;
            btnKaydet.Enabled = false;
            txtMusteriAdi.Focus();
        }

        private void txtMusteriArama_TextChanged(object sender, EventArgs e)
        {
            cMusteri m = new cMusteri();
            m.MusteriSorgula(txtMusteriArama.Text,lvMusteriler);
        }
    }
}
