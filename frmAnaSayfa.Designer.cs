namespace wf_VideoMarket
{
    partial class frmAnaSayfa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mnuAnasayfa = new System.Windows.Forms.MenuStrip();
            this.filmBilgileriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mitmFilmTanimlama = new System.Windows.Forms.ToolStripMenuItem();
            this.mitmFilmTuruTanimlama = new System.Windows.Forms.ToolStripMenuItem();
            this.mitmFilmSorgulama = new System.Windows.Forms.ToolStripMenuItem();
            this.müşterilerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mitmMusteriTanimlama = new System.Windows.Forms.ToolStripMenuItem();
            this.mitmMusteriSorgulama = new System.Windows.Forms.ToolStripMenuItem();
            this.satışİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mitmFilmSatis = new System.Windows.Forms.ToolStripMenuItem();
            this.mitmSatisSorgulama = new System.Windows.Forms.ToolStripMenuItem();
            this.raporlamaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mitmSatisAnalizi = new System.Windows.Forms.ToolStripMenuItem();
            this.mitmCikis = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAnasayfa.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuAnasayfa
            // 
            this.mnuAnasayfa.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.mnuAnasayfa.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filmBilgileriToolStripMenuItem,
            this.müşterilerToolStripMenuItem,
            this.satışİşlemleriToolStripMenuItem,
            this.raporlamaToolStripMenuItem,
            this.mitmCikis});
            this.mnuAnasayfa.Location = new System.Drawing.Point(0, 0);
            this.mnuAnasayfa.Name = "mnuAnasayfa";
            this.mnuAnasayfa.Size = new System.Drawing.Size(858, 29);
            this.mnuAnasayfa.TabIndex = 1;
            this.mnuAnasayfa.Text = "menuStrip1";
            // 
            // filmBilgileriToolStripMenuItem
            // 
            this.filmBilgileriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitmFilmTanimlama,
            this.mitmFilmTuruTanimlama,
            this.mitmFilmSorgulama});
            this.filmBilgileriToolStripMenuItem.Name = "filmBilgileriToolStripMenuItem";
            this.filmBilgileriToolStripMenuItem.Size = new System.Drawing.Size(108, 25);
            this.filmBilgileriToolStripMenuItem.Text = "&Film Bilgileri";
            // 
            // mitmFilmTanimlama
            // 
            this.mitmFilmTanimlama.Name = "mitmFilmTanimlama";
            this.mitmFilmTanimlama.Size = new System.Drawing.Size(227, 26);
            this.mitmFilmTanimlama.Text = "Film &Tanımlama";
            this.mitmFilmTanimlama.Click += new System.EventHandler(this.mitmFilmTanimlama_Click);
            // 
            // mitmFilmTuruTanimlama
            // 
            this.mitmFilmTuruTanimlama.Name = "mitmFilmTuruTanimlama";
            this.mitmFilmTuruTanimlama.Size = new System.Drawing.Size(227, 26);
            this.mitmFilmTuruTanimlama.Text = "Film T&ürü Tanımlama";
            this.mitmFilmTuruTanimlama.Click += new System.EventHandler(this.mitmFilmTuruTanimlama_Click);
            // 
            // mitmFilmSorgulama
            // 
            this.mitmFilmSorgulama.Name = "mitmFilmSorgulama";
            this.mitmFilmSorgulama.Size = new System.Drawing.Size(227, 26);
            this.mitmFilmSorgulama.Text = "Film &Sorgulama";
            this.mitmFilmSorgulama.Click += new System.EventHandler(this.mitmFilmSorgulama_Click);
            // 
            // müşterilerToolStripMenuItem
            // 
            this.müşterilerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitmMusteriTanimlama,
            this.mitmMusteriSorgulama});
            this.müşterilerToolStripMenuItem.Name = "müşterilerToolStripMenuItem";
            this.müşterilerToolStripMenuItem.Size = new System.Drawing.Size(93, 25);
            this.müşterilerToolStripMenuItem.Text = "&Müşteriler";
            // 
            // mitmMusteriTanimlama
            // 
            this.mitmMusteriTanimlama.Name = "mitmMusteriTanimlama";
            this.mitmMusteriTanimlama.Size = new System.Drawing.Size(214, 26);
            this.mitmMusteriTanimlama.Text = "Müşteri &Tanımlama";
            this.mitmMusteriTanimlama.Click += new System.EventHandler(this.mitmMusteriTanimlama_Click);
            // 
            // mitmMusteriSorgulama
            // 
            this.mitmMusteriSorgulama.Name = "mitmMusteriSorgulama";
            this.mitmMusteriSorgulama.Size = new System.Drawing.Size(214, 26);
            this.mitmMusteriSorgulama.Text = "Müşteri &Sorgulama";
            this.mitmMusteriSorgulama.Click += new System.EventHandler(this.mitmMusteriSorgulama_Click);
            // 
            // satışİşlemleriToolStripMenuItem
            // 
            this.satışİşlemleriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitmFilmSatis,
            this.mitmSatisSorgulama});
            this.satışİşlemleriToolStripMenuItem.Name = "satışİşlemleriToolStripMenuItem";
            this.satışİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(118, 25);
            this.satışİşlemleriToolStripMenuItem.Text = "&Satış İşlemleri";
            // 
            // mitmFilmSatis
            // 
            this.mitmFilmSatis.Name = "mitmFilmSatis";
            this.mitmFilmSatis.Size = new System.Drawing.Size(193, 26);
            this.mitmFilmSatis.Text = "Film &Satış";
            // 
            // mitmSatisSorgulama
            // 
            this.mitmSatisSorgulama.Name = "mitmSatisSorgulama";
            this.mitmSatisSorgulama.Size = new System.Drawing.Size(193, 26);
            this.mitmSatisSorgulama.Text = "Satış S&orgulama";
            // 
            // raporlamaToolStripMenuItem
            // 
            this.raporlamaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitmSatisAnalizi});
            this.raporlamaToolStripMenuItem.Name = "raporlamaToolStripMenuItem";
            this.raporlamaToolStripMenuItem.Size = new System.Drawing.Size(98, 25);
            this.raporlamaToolStripMenuItem.Text = "&Raporlama";
            // 
            // mitmSatisAnalizi
            // 
            this.mitmSatisAnalizi.Name = "mitmSatisAnalizi";
            this.mitmSatisAnalizi.Size = new System.Drawing.Size(215, 26);
            this.mitmSatisAnalizi.Text = "&Detaylı Satış Analizi";
            // 
            // mitmCikis
            // 
            this.mitmCikis.Name = "mitmCikis";
            this.mitmCikis.Size = new System.Drawing.Size(55, 25);
            this.mitmCikis.Text = "&Çıkış";
            this.mitmCikis.Click += new System.EventHandler(this.mitmCikis_Click);
            // 
            // frmAnaSayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 497);
            this.Controls.Add(this.mnuAnasayfa);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuAnasayfa;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmAnaSayfa";
            this.Text = "VideoMarket Anasayfa İşlemleri";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mnuAnasayfa.ResumeLayout(false);
            this.mnuAnasayfa.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuAnasayfa;
        private System.Windows.Forms.ToolStripMenuItem filmBilgileriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mitmFilmTanimlama;
        private System.Windows.Forms.ToolStripMenuItem mitmFilmTuruTanimlama;
        private System.Windows.Forms.ToolStripMenuItem mitmFilmSorgulama;
        private System.Windows.Forms.ToolStripMenuItem müşterilerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mitmMusteriTanimlama;
        private System.Windows.Forms.ToolStripMenuItem mitmMusteriSorgulama;
        private System.Windows.Forms.ToolStripMenuItem satışİşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mitmFilmSatis;
        private System.Windows.Forms.ToolStripMenuItem mitmSatisSorgulama;
        private System.Windows.Forms.ToolStripMenuItem raporlamaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mitmSatisAnalizi;
        private System.Windows.Forms.ToolStripMenuItem mitmCikis;
    }
}