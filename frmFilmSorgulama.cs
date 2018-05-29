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
    public partial class frmFilmSorgulama : Form
    {
        public frmFilmSorgulama()
        {
            InitializeComponent();
        }
        cFilm f = new cFilm();
        private void frmFilmSorgulama_Load(object sender, EventArgs e)
        {
            f.FilmleriGoster(lvFilmler);

            cFilmTuru ft = new cFilmTuru();
            ft.FilmTurleriGoster(cbFilmTurleri);
            //cbFilmTurleri.Items.Add("Tüm Türler");  //Listenin sonuna ekler.
            cbFilmTurleri.Items.Insert(0, "Tüm Türler");
            cbFilmTurleri.SelectedIndex = 0;
        }
    }
}
