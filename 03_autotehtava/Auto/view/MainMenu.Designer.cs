namespace Autokauppa.view
{
    partial class MainMenu
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
            btnSeuraava = new System.Windows.Forms.Button();
            gbAuto = new System.Windows.Forms.GroupBox();
            label4 = new System.Windows.Forms.Label();
            cbPolttoaine = new System.Windows.Forms.ComboBox();
            label3 = new System.Windows.Forms.Label();
            cbVari = new System.Windows.Forms.ComboBox();
            label2 = new System.Windows.Forms.Label();
            cbMalli = new System.Windows.Forms.ComboBox();
            dtpPaiva = new System.Windows.Forms.DateTimePicker();
            tbMittarilukema = new System.Windows.Forms.TextBox();
            tbTilavuus = new System.Windows.Forms.TextBox();
            tbHinta = new System.Windows.Forms.TextBox();
            tbId = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            cbMerkki = new System.Windows.Forms.ComboBox();
            btnEdellinen = new System.Windows.Forms.Button();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            testaaTietokantaaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            btnLisaa = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            gbAuto.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // btnSeuraava
            // 
            btnSeuraava.Location = new System.Drawing.Point(111, 291);
            btnSeuraava.Name = "btnSeuraava";
            btnSeuraava.Size = new System.Drawing.Size(78, 31);
            btnSeuraava.TabIndex = 17;
            btnSeuraava.Text = "Seuraava";
            btnSeuraava.UseVisualStyleBackColor = true;
            btnSeuraava.Click += btnSeuraava_Click;
            // 
            // gbAuto
            // 
            gbAuto.Controls.Add(label4);
            gbAuto.Controls.Add(cbPolttoaine);
            gbAuto.Controls.Add(label3);
            gbAuto.Controls.Add(cbVari);
            gbAuto.Controls.Add(label2);
            gbAuto.Controls.Add(cbMalli);
            gbAuto.Controls.Add(dtpPaiva);
            gbAuto.Controls.Add(tbMittarilukema);
            gbAuto.Controls.Add(tbTilavuus);
            gbAuto.Controls.Add(tbHinta);
            gbAuto.Controls.Add(tbId);
            gbAuto.Controls.Add(label1);
            gbAuto.Controls.Add(cbMerkki);
            gbAuto.Location = new System.Drawing.Point(10, 34);
            gbAuto.Name = "gbAuto";
            gbAuto.Size = new System.Drawing.Size(281, 251);
            gbAuto.TabIndex = 18;
            gbAuto.TabStop = false;
            gbAuto.Text = "Auton tiedot";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(159, 178);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(61, 15);
            label4.TabIndex = 29;
            label4.Text = "Polttoaine";
            // 
            // cbPolttoaine
            // 
            cbPolttoaine.FormattingEnabled = true;
            cbPolttoaine.Location = new System.Drawing.Point(160, 200);
            cbPolttoaine.Name = "cbPolttoaine";
            cbPolttoaine.Size = new System.Drawing.Size(106, 23);
            cbPolttoaine.TabIndex = 28;
            cbPolttoaine.SelectedIndexChanged += cbPolttoaine_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(158, 125);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(26, 15);
            label3.TabIndex = 27;
            label3.Text = "Väri";
            // 
            // cbVari
            // 
            cbVari.FormattingEnabled = true;
            cbVari.Location = new System.Drawing.Point(160, 146);
            cbVari.Name = "cbVari";
            cbVari.Size = new System.Drawing.Size(106, 23);
            cbVari.TabIndex = 26;
            cbVari.SelectedIndexChanged += cbVari_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(158, 74);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(33, 15);
            label2.TabIndex = 25;
            label2.Text = "Malli";
            // 
            // cbMalli
            // 
            cbMalli.FormattingEnabled = true;
            cbMalli.Location = new System.Drawing.Point(160, 96);
            cbMalli.Name = "cbMalli";
            cbMalli.Size = new System.Drawing.Size(106, 23);
            cbMalli.TabIndex = 24;
            cbMalli.SelectedIndexChanged += cbMalli_SelectedIndexChanged;
            // 
            // dtpPaiva
            // 
            dtpPaiva.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpPaiva.Location = new System.Drawing.Point(15, 94);
            dtpPaiva.Name = "dtpPaiva";
            dtpPaiva.Size = new System.Drawing.Size(102, 23);
            dtpPaiva.TabIndex = 23;
            dtpPaiva.ValueChanged += dtpPaiva_ValueChanged;
            // 
            // tbMittarilukema
            // 
            tbMittarilukema.Location = new System.Drawing.Point(15, 146);
            tbMittarilukema.Name = "tbMittarilukema";
            tbMittarilukema.Size = new System.Drawing.Size(102, 23);
            tbMittarilukema.TabIndex = 22;
            tbMittarilukema.TextChanged += tbMittarilukema_TextChanged;
            tbMittarilukema.Enter += tbMittarilukema_Enter;
            // 
            // tbTilavuus
            // 
            tbTilavuus.Location = new System.Drawing.Point(15, 120);
            tbTilavuus.Name = "tbTilavuus";
            tbTilavuus.Size = new System.Drawing.Size(102, 23);
            tbTilavuus.TabIndex = 21;
            tbTilavuus.TextChanged += tbTilavuus_TextChanged;
            tbTilavuus.Enter += tbTilavuus_Enter;
            // 
            // tbHinta
            // 
            tbHinta.Location = new System.Drawing.Point(15, 68);
            tbHinta.Name = "tbHinta";
            tbHinta.Size = new System.Drawing.Size(102, 23);
            tbHinta.TabIndex = 20;
            tbHinta.TextChanged += tbHinta_TextChanged;
            tbHinta.Enter += tbHinta_Enter;
            // 
            // tbId
            // 
            tbId.Location = new System.Drawing.Point(15, 41);
            tbId.Name = "tbId";
            tbId.ReadOnly = true;
            tbId.Size = new System.Drawing.Size(102, 23);
            tbId.TabIndex = 19;
            tbId.Text = "ID";
            tbId.TextChanged += tbId_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(158, 30);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(69, 15);
            label1.TabIndex = 18;
            label1.Text = "Automerkki";
            // 
            // cbMerkki
            // 
            cbMerkki.FormattingEnabled = true;
            cbMerkki.Location = new System.Drawing.Point(158, 49);
            cbMerkki.Name = "cbMerkki";
            cbMerkki.Size = new System.Drawing.Size(106, 23);
            cbMerkki.TabIndex = 17;
            cbMerkki.SelectedIndexChanged += cbMerkki_SelectedIndexChanged;
            // 
            // btnEdellinen
            // 
            btnEdellinen.Location = new System.Drawing.Point(10, 291);
            btnEdellinen.Name = "btnEdellinen";
            btnEdellinen.Size = new System.Drawing.Size(81, 31);
            btnEdellinen.TabIndex = 19;
            btnEdellinen.Text = "Edellinen";
            btnEdellinen.UseVisualStyleBackColor = true;
            btnEdellinen.Click += btnEdellinen_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { exitToolStripMenuItem, aboutToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            menuStrip1.Size = new System.Drawing.Size(570, 24);
            menuStrip1.TabIndex = 20;
            menuStrip1.Text = "menuStrip1";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { exitToolStripMenuItem1 });
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            exitToolStripMenuItem.Text = "Tiedosto";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem1
            // 
            exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            exitToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            exitToolStripMenuItem1.Text = "Poistu";
            exitToolStripMenuItem1.Click += exitToolStripMenuItem1_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { testaaTietokantaaToolStripMenuItem });
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            aboutToolStripMenuItem.Text = "Muuta...";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // testaaTietokantaaToolStripMenuItem
            // 
            testaaTietokantaaToolStripMenuItem.Name = "testaaTietokantaaToolStripMenuItem";
            testaaTietokantaaToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            testaaTietokantaaToolStripMenuItem.Text = "Testaa tietokantaa";
            testaaTietokantaaToolStripMenuItem.Click += testaaTietokantaaToolStripMenuItem_Click;
            // 
            // btnLisaa
            // 
            btnLisaa.Location = new System.Drawing.Point(214, 291);
            btnLisaa.Name = "btnLisaa";
            btnLisaa.Size = new System.Drawing.Size(78, 31);
            btnLisaa.TabIndex = 21;
            btnLisaa.Text = "Lisää";
            btnLisaa.UseVisualStyleBackColor = true;
            btnLisaa.Click += btnLisaa_Click;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(321, 291);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(119, 31);
            button1.TabIndex = 30;
            button1.Text = "Tyhjennä laatikot";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(570, 350);
            Controls.Add(button1);
            Controls.Add(btnLisaa);
            Controls.Add(btnEdellinen);
            Controls.Add(gbAuto);
            Controls.Add(btnSeuraava);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new System.Windows.Forms.Padding(4);
            Name = "MainMenu";
            Text = "MainMenu";
            Load += MainMenu_Load;
            gbAuto.ResumeLayout(false);
            gbAuto.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button btnSeuraava;
        private System.Windows.Forms.GroupBox gbAuto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbPolttoaine;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbVari;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbMalli;
        private System.Windows.Forms.DateTimePicker dtpPaiva;
        private System.Windows.Forms.TextBox tbMittarilukema;
        private System.Windows.Forms.TextBox tbTilavuus;
        private System.Windows.Forms.TextBox tbHinta;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbMerkki;
        private System.Windows.Forms.Button btnEdellinen;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testaaTietokantaaToolStripMenuItem;
        private System.Windows.Forms.Button btnLisaa;
        private System.Windows.Forms.Button button1;
    }
}