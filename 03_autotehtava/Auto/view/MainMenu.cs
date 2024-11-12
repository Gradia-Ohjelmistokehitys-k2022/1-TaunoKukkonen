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
        decimal hinta;
        DateTime rekPaiva;
        decimal moottorinTilavuus;
        int mittarinLukema;
        int merkkiId;
        int malliId;
        int variId;
        int polttoaineId;

        int listNumber = -1;

        KaupanLogiikka registerHandler;
        List<Autokauppa.model.Auto> Autot;
        public MainMenu()
        { Autot=new List<Autokauppa.model.Auto>();
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
            foreach (var malli in registerHandler.getAutoModels(0))
            {
                cbMalli.Items.Add(malli.MalliNimi);
            }
            foreach (var polttis in registerHandler.getAllFuel())
            {
                cbPolttoaine.Items.Add(polttis.PolttoName);
            }
            foreach (var vari in registerHandler.getAllColours())
            {
                cbVari.Items.Add(vari.VariNimi);
            }
            Autot = registerHandler.GetAllAutos();
        }

        private void cbMerkki_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbMalli.Items.Clear();
            cbMerkkiNimi = cbMerkki.Text;
            AutoMerkki autoMerkki = registerHandler.getAllAutoMakers().FirstOrDefault(a => a.MerkkiNimi == cbMerkkiNimi);
            merkkiId=autoMerkki.MerkkiId;
            MainMenu_Load(sender, e);
            foreach (var malli in registerHandler.getAutoModels(autoMerkki.MerkkiId))
            {
                cbMalli.Items.Add(malli.MalliNimi);
            }
        }

        private void cbMalli_SelectedIndexChanged(object sender, EventArgs e)
        {
            AutoMalli autoMalli  = registerHandler.getAutoModels(0).FirstOrDefault(a=>a.MalliNimi==cbMalli.Text);
            malliId=autoMalli.MalliId;
        }

        private void cbVari_SelectedIndexChanged(object sender, EventArgs e)
        {
            Vari vari = registerHandler.getAllColours().FirstOrDefault(a=>a.VariNimi == cbVari.Text);
            variId=vari.VariId;
        }

        private void cbPolttoaine_SelectedIndexChanged(object sender, EventArgs e)
        {
            Polttonaine polttonaine = registerHandler.getAllFuel().FirstOrDefault(a=> a.PolttoName==cbPolttoaine.Text);
            polttoaineId = polttonaine.PolttoId;
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
            if (Decimal.TryParse(tbHinta.Text, out decimal val))
            {
                hinta = val;
            }
            
        }
        private void dtpPaiva_ValueChanged(object sender, EventArgs e)
        {
            rekPaiva = dtpPaiva.Value.Date;
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
            if (Decimal.TryParse(tbTilavuus.Text, out decimal val))
            {
                moottorinTilavuus = val;
            }
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
            if (Int32.TryParse(tbMittarilukema.Text, out int val))
            {
                mittarinLukema = val;
            }
        }

        private void btnEdellinen_Click(object sender, EventArgs e)
        {
            listNumber--;
            if (listNumber < 0)
            {
                listNumber = Autot.Count -1;
            }
          

            AutoMerkki autoMerkki = registerHandler.getAllAutoMakers().FirstOrDefault(a => a.MerkkiId == Autot[listNumber].AutonMerkkiId);

            cbMerkki.Text = autoMerkki.MerkkiNimi.ToString();

            AutoMalli autoMalli = registerHandler.getAutoModels(0).FirstOrDefault(a => a.MalliId == Autot[listNumber].AutonMalliId);

            cbMalli.Text = autoMalli.MalliNimi.ToString();

            Polttonaine polttonaine = registerHandler.getAllFuel().FirstOrDefault(a => a.PolttoId == Autot[listNumber].PolttoaineId);

            cbPolttoaine.Text = polttonaine.PolttoName.ToString();

            Vari vari = registerHandler.getAllColours().FirstOrDefault(a => a.VariId == Autot[listNumber].PolttoaineId);

            cbVari.Text = vari.VariNimi.ToString();

            tbHinta.Text = Autot[listNumber].Hinta.ToString();
            tbTilavuus.Text = Autot[listNumber].MoottorinTilavuus.ToString();
            tbMittarilukema.Text = Autot[listNumber].Mittarilukema.ToString();
            tbId.Text = Autot[listNumber].Id.ToString();
            dtpPaiva.Value = Autot[listNumber].RekisteriPaivamaara;

            

        }

        private void btnSeuraava_Click(object sender, EventArgs e)
        {
            listNumber++;
            if (listNumber == Autot.Count) 
            {
                listNumber = 0;
            }
            AutoMerkki autoMerkki = registerHandler.getAllAutoMakers().FirstOrDefault(a => a.MerkkiId == Autot[listNumber].AutonMerkkiId);

            cbMerkki.Text=autoMerkki.MerkkiNimi.ToString();

            AutoMalli autoMalli = registerHandler.getAutoModels(0).FirstOrDefault(a => a.MalliId == Autot[listNumber].AutonMalliId);
            
            cbMalli.Text=autoMalli.MalliNimi.ToString();

            Polttonaine polttonaine = registerHandler.getAllFuel().FirstOrDefault(a => a.PolttoId == Autot[listNumber].PolttoaineId);
            
            cbPolttoaine.Text=polttonaine.PolttoName.ToString();

            Vari vari = registerHandler.getAllColours().FirstOrDefault(a => a.VariId == Autot[listNumber].PolttoaineId);

            cbVari.Text = vari.VariNimi.ToString();

            tbHinta.Text = Autot[listNumber].Hinta.ToString();
            tbTilavuus.Text = Autot[listNumber].MoottorinTilavuus.ToString();
            tbMittarilukema.Text = Autot[listNumber].Mittarilukema.ToString();
            tbId.Text = Autot[listNumber].Id.ToString();
            dtpPaiva.Value = Autot[listNumber].RekisteriPaivamaara;

            
            
        }

        private void btnLisaa_Click(object sender, EventArgs e)
        {
            if (AreFieldsEmpty())
            {
                Autokauppa.model.Auto auto = new Autokauppa.model.Auto()
                {
                    PolttoaineId = polttoaineId,
                    VariId = variId,
                    AutonMalliId = malliId,
                    AutonMerkkiId = merkkiId,
                    Mittarilukema = mittarinLukema,
                    MoottorinTilavuus = moottorinTilavuus,
                    RekisteriPaivamaara = rekPaiva,
                    Hinta=hinta

                };
                registerHandler.SaveCar(auto);
                button1_Click(sender, e);
            }else { MessageBox.Show("Tallennus epäonnistui"); }
           
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
            }
            else
            {
                MessageBox.Show("Yhteyden luonti epäonnistui");
            }
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cbPolttoaine.Text = string.Empty;
            cbMerkki.Text = string.Empty;
            cbVari.Text = string.Empty;
            cbMalli.Text = string.Empty;
            tbHinta.Text = string.Empty;
            tbId.Text = string.Empty;
            tbMittarilukema.Text = string.Empty;
            tbTilavuus.Text = string.Empty;
        }
        private bool AreFieldsEmpty()
        {
            if (cbPolttoaine.Text != string.Empty && 
                cbMerkki.Text != string.Empty &&
            cbVari.Text != string.Empty &&
            cbMalli.Text != string.Empty &&
            tbHinta.Text != string.Empty && tbHinta.Text != tbHintaDefText && 
            tbMittarilukema.Text != string.Empty && tbMittarilukema.Text != tbLukemaDefText &&
            tbTilavuus.Text != string.Empty && tbTilavuus.Text != tbTilavuusDefText) {  return true; }
            else { return false; }
        }
    }
}
