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
    public partial class frmMusteriSorgulama : Form
    {
        public frmMusteriSorgulama()
        {
            InitializeComponent();
        }
        cMusteri m = new cMusteri();
        private void frmMusteriSorgulama_Load(object sender, EventArgs e)
        {
            m.MusterileriGoster(lvMusteriler);
        }
        private void txtAdaGore_TextChanged(object sender, EventArgs e)
        {
            m.MusterileriGosterBySorgulama(txtAdaGore.Text, txtSoyadaGore.Text, txtTelefonaGore.Text, txtAdreseGore.Text, lvMusteriler);
        }
        private void txtSoyadaGore_TextChanged(object sender, EventArgs e)
        {
            m.MusterileriGosterBySorgulama(txtAdaGore.Text, txtSoyadaGore.Text, txtTelefonaGore.Text, txtAdreseGore.Text, lvMusteriler);
        }
        private void txtTelefonaGore_TextChanged(object sender, EventArgs e)
        {
            m.MusterileriGosterBySorgulama(txtAdaGore.Text, txtSoyadaGore.Text, txtTelefonaGore.Text, txtAdreseGore.Text, lvMusteriler);
        }
        private void txtAdreseGore_TextChanged(object sender, EventArgs e)
        {
            m.MusterileriGosterBySorgulama(txtAdaGore.Text, txtSoyadaGore.Text, txtTelefonaGore.Text, txtAdreseGore.Text, lvMusteriler);
        }
    }
}
