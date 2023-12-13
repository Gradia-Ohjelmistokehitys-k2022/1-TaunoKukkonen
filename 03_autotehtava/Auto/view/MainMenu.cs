using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Autokauppa.model;
using Autokauppa.controller;
using System.Diagnostics.Eventing.Reader;
using Auto.model;


namespace Autokauppa.view
{
    public partial class MainMenu : Form
    {
        string tbHintaDefText = "Hinta";
        string tbTilavuusDefText = "Moottorin tilavuus";
        string tbLukemaDefText = "Mittarin lukema";
        string cbMerkkiNimi;
        

        KaupanLogiikka registerHandler;

        public MainMenu()
        {
            registerHandler = new KaupanLogiikka();
            InitializeComponent();
            // formload
        }
        private void MainMenu_Load(object sender, EventArgs e)
        {
            tbHinta.Text = tbHintaDefText;
            tbTilavuus.Text = tbTilavuusDefText;
            tbMittarilukema.Text = tbLukemaDefText;
            registerHandler.GetModels();
            foreach (var merkki in registerHandler.getAllAutoMakers())
            {
                cbMerkki.Items.Add(merkki.MerkkiNimi);
            }
        }

        private void cbMerkki_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbMalli.Items.Clear();
            cbMerkkiNimi = cbMerkki.Text;
            AutoMerkki autoMerkki = registerHandler.getAllAutoMakers().FirstOrDefault(a => a.MerkkiNimi==cbMerkkiNimi);
            
            MainMenu_Load(sender,e);
            foreach (var malli in registerHandler.getAutoModels(autoMerkki.MerkkiId))
            {
                cbMalli.Items.Add(malli.MalliNimi);
            }
        }

        private void cbMalli_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbVari_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbPolttoaine_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbId_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbHinta_Enter(object sender, EventArgs e)
        {
            if (tbHinta.Text == tbHintaDefText)
            {
                tbHinta.Text = String.Empty;
            }
        }

        private void tbHinta_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void dtpPaiva_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tbTilavuus_Enter(object sender, EventArgs e)
        {
            if (tbTilavuus.Text == tbTilavuusDefText)
            {
                tbTilavuus.Text = string.Empty;
            }
        }

        private void tbTilavuus_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbMittarilukema_Enter(object sender, EventArgs e)
        {
            if (tbMittarilukema.Text == tbLukemaDefText)
            {
                tbMittarilukema.Text = String.Empty;
            }
        }

        private void tbMittarilukema_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEdellinen_Click(object sender, EventArgs e)
        {

        }

        private void btnSeuraava_Click(object sender, EventArgs e)
        {

        }

        private void btnLisaa_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void testaaTietokantaaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (registerHandler.TestDatabaseConnection())
            {
                MessageBox.Show("Yhteys luotu");
            }else 
            {
                MessageBox.Show("Yhteyden luonti epäonnistui");
            }
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

      
        
        
    }
}
