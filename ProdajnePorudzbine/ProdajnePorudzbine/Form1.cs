using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProdajnePorudzbine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // popuniED();

            popuniNalog(0);
            popuniKupac();
            popuniType();
            ucitajKurs();
        }

        private void btnPronadji_Click(object sender, EventArgs e)
        {
            if (cbType.Text == "")
            {
                MessageBox.Show("morate odabrati Vrstu naloga!");
                cbType.Focus();
                return;
            }
            DateTime datumOd = new DateTime(dtpDatum.Value.Year, dtpDatum.Value.Month, dtpDatum.Value.Day);
            DateTime datumDo = new DateTime(dtpDatumDo.Value.Year, dtpDatumDo.Value.Month, dtpDatumDo.Value.Day);



            string qUpit = "SELECT        dbo.[Stirg Produkcija$Sales Header].No_, dbo.[Stirg Produkcija$Customer].Name, dbo.[Stirg Produkcija$Sales Header].[External Document No_], dbo.[Stirg Produkcija$Sales Header].[Document Date],"+

                "     CASE WHEN dbo.[Stirg Produkcija$Sales Header].[Customer Posting Group] = 'INO' THEN t1.[Vrednost porudzbine] * " + tbKurs.Text.Replace(",", ".") + " ELSE t1.[Vrednost porudzbine] END AS [Vrednost porudzbine], " +
                      "   CASE WHEN dbo.[Stirg Produkcija$Sales Header].[Customer Posting Group] = 'INO' THEN t1.[Vrednost porudzbine sa PDV] * " + tbKurs.Text.Replace(",", ".") + " ELSE t1.[Vrednost porudzbine sa PDV] END AS [Vrednost porudzbine sa PDV]," +

                "       CASE WHEN dbo.[Stirg Produkcija$Sales Header].[Customer Posting Group] = 'DOMACI' THEN t1.[Vrednost porudzbine] / " + tbKurs.Text.Replace(",", ".") + " ELSE t1.[Vrednost porudzbine] END AS [Iznos u Evrima], " +
                      "   CASE WHEN dbo.[Stirg Produkcija$Sales Header].[Customer Posting Group] = 'DOMACI' THEN t1.[Vrednost porudzbine sa PDV] / " + tbKurs.Text.Replace(",", ".") + " ELSE t1.[Vrednost porudzbine sa PDV] END AS [Iznos u Evrima sa PDV]," +
             
                       "   dbo.[Stirg Produkcija$Customer].No_ AS Kupac, " +
                   
                    " dbo.[Stirg Produkcija$Sales Header].[Customer Posting Group] as Grupa" +
                       " FROM dbo.[Stirg Produkcija$Sales Header] " +
      "   INNER JOIN " +
               "    (SELECT[Document No_], SUM(Amount) AS [Vrednost porudzbine],SUM([Amount Including VAT]) AS [Vrednost porudzbine sa PDV] " +
                           "     FROM            dbo.[Stirg Produkcija$Sales Line] " +
                            "    GROUP BY [Document No_]) AS t1 ON t1.[Document No_] = dbo.[Stirg Produkcija$Sales Header].No_ INNER JOIN " +
                     "     dbo.[Stirg Produkcija$Customer] ON dbo.[Stirg Produkcija$Sales Header].[Sell-to Customer No_] = dbo.[Stirg Produkcija$Customer].No_ " +
                              " where    (dbo.[Stirg Produkcija$Sales Header].[Document Type] = " + cbType.SelectedValue.ToString() + ") ";

            if (cbPeriod.Checked)
            {
                qUpit += " and (dbo.[Stirg Produkcija$Sales Header].[Document Date] >= CONVERT(DATETIME, '" + datumOd.Year + "-" + datumOd.Month + "-" + datumOd.Day + " 00:00:00', 102))" +
                     " and ( dbo.[Stirg Produkcija$Sales Header].[Document Date] <= CONVERT(DATETIME, '" + datumDo.Year + "-" + datumDo.Month + "-" + datumDo.Day + " 23:59:59', 102)) ";
            }

            if (cbNalog.Text != "")
            {
                qUpit += " and (dbo.[Stirg Produkcija$Sales Header].No_ = N'" + cbNalog.Text + "')";
            }

            if (cbKupac.Text != "")
            {
                qUpit += " AND (dbo.[Stirg Produkcija$Customer].No_ = N'" + cbKupac.SelectedValue + "')";
            }

            if (cbDomaciStrani.Text == "Domaci")
            {

                qUpit += " and ( dbo.[Stirg Produkcija$Sales Header].[Customer Posting Group] = N'DOMACI') ";
            }
            if (cbDomaciStrani.Text == "Strani")
            {

                qUpit += " and ( dbo.[Stirg Produkcija$Sales Header].[Customer Posting Group] = N'INO') ";
            }

            DataTable dt = metode.DB.baza_upit(qUpit);
            if (dt.Rows.Count > 0)
            {
                dgvSalesHeader.DataSource = dt;
                dgvSalesHeader.Columns["Kupac"].Visible = false;
                dgvSalesHeader.Columns["Vrednost porudzbine"].DefaultCellStyle.Format = "N2";
                dgvSalesHeader.Columns["Vrednost porudzbine"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvSalesHeader.Columns["Vrednost porudzbine sa PDV"].DefaultCellStyle.Format = "N2";
                dgvSalesHeader.Columns["Vrednost porudzbine sa PDV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvSalesHeader.Columns["Iznos u Evrima"].DefaultCellStyle.Format = "N2";
                dgvSalesHeader.Columns["Iznos u Evrima"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvSalesHeader.Columns["Iznos u Evrima sa PDV"].DefaultCellStyle.Format = "N2";
                dgvSalesHeader.Columns["Iznos u Evrima sa PDV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvSalesHeader_Click(null, null);
                ukupno();
            }
            else
            {
                dgvSalesHeader.DataSource = null;
                MessageBox.Show("Nema podataka za zadati kreiterijum.");
            }
        }

        private void ukupno()
        {
            double strani = 0;
            double domaci = 0;
            double domaciPDV = 0;
            double straniPDV = 0;
            double straniEvro = 0;
            double straniEvroPDV = 0;
            double domaciEvro = 0;
            double domaciEvroPdv = 0;

            foreach (DataGridViewRow r in dgvSalesHeader.Rows)
            {
                if (r.Cells["Grupa"].Value.ToString() == "INO")
                {
                    strani += double.Parse(r.Cells["Vrednost porudzbine"].Value.ToString());
                    straniPDV += double.Parse(r.Cells["Vrednost porudzbine sa PDV"].Value.ToString());
                    straniEvro += double.Parse(r.Cells["Iznos u Evrima"].Value.ToString());
                    straniEvroPDV += double.Parse(r.Cells["Iznos u Evrima sa PDV"].Value.ToString());
                }
                else
                {
                    domaci += double.Parse(r.Cells["Vrednost porudzbine"].Value.ToString());
                    domaciPDV += double.Parse(r.Cells["Vrednost porudzbine sa PDV"].Value.ToString());
                    domaciEvro += double.Parse(r.Cells["Iznos u Evrima"].Value.ToString());
                    domaciEvroPdv += double.Parse(r.Cells["Iznos u Evrima sa PDV"].Value.ToString());
                }
            }

            lblD.Text = domaci.ToString("#,###.##") + " RSD";
         
            lblS.Text = strani.ToString("#,###.##") + " RSD";
            lblU.Text = (strani + domaci).ToString("#,###.##") + " RSD";

            lblDomaciPDV.Text = domaciPDV.ToString("#,###.##") + " RSD";
            lblStraniPDV.Text = straniPDV.ToString("#,###.##") + " RSD";
            lblPDV.Text = (straniPDV + domaciPDV).ToString("#,###.##") + " RSD";

            lblStraniEvro.Text = straniEvro.ToString("#,###.##")+ " €";
            lblUkuponoEvroDomaci.Text = domaciEvro.ToString("#,###.##") + " €";
            lblUkupnoEvroBez.Text = (straniEvro + domaciEvro).ToString("#,###.##") + " €";

            lblStraniEvroPDV.Text = straniEvroPDV.ToString("#,###.##") + " €";
            lblDomaciEvroPDV.Text = domaciEvroPdv.ToString("#,###.##") + " €";
            lblUkupnoEvroPDV.Text = (straniEvroPDV + domaciEvroPdv).ToString("#,###.##") + " €";

        }
        private void popuniED()
        {

            cbDomaciStrani.DataSource = metode.DB.baza_upit("SELECT DISTINCT TOP (100) PERCENT [External Document No_]" +
                         " FROM             dbo.[Stirg Produkcija$Sales Header]  " +
                         "  ORDER BY [External Document No_]");
            cbDomaciStrani.DisplayMember = "External Document No_";
            cbDomaciStrani.ValueMember = "External Document No_";

        }

        private void popuniNalog(int tip)
        {
            cbNalog.DataSource = metode.DB.baza_upit("SELECT DISTINCT TOP (100) PERCENT No_ " +
                      " FROM            dbo.[Stirg Produkcija$Sales Header]  " +
                      " where  [Document Type]=" + tip + "" +
                      "  ORDER BY No_ ");
            cbNalog.DisplayMember = "No_";
            cbNalog.ValueMember = "No_";
            cbNalog.SelectedIndex = -1;
        }

        private void popuniKupac()
        {
            cbKupac.DataSource = metode.DB.baza_upit("SELECT DISTINCT TOP (100) PERCENT No_, name " +
                      " FROM     [Stirg Produkcija$Customer] " +
                      "  ORDER BY No_ ");
            cbKupac.DisplayMember = "Name";
            cbKupac.ValueMember = "No_";
            cbKupac.SelectedIndex = -1;


        }

        private void popuniType()
        {
            cbType.DataSource = metode.DB.baza_upit("SELECT DISTINCT [Document Type] FROM [Stirg Produkcija$Sales Header]");
            cbType.DisplayMember = "Document Type";
            cbType.ValueMember = "Document Type";
        }

        private void cbType_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                popuniNalog(int.Parse(cbType.SelectedValue.ToString()));
            }
            catch
            { }
        }

        private void ucitajStavke(string nalog)
        {
            string qUpit = "SELECT        [Line No_], [Shipment Date], Quantity, [Unit Price], Amount AS Vrednost, [Amount Including VAT] AS [Vrednost sa PDV], " +
                        " Amount/ " + tbKurs.Text.Replace(",", ".") + " AS [Iznos u Evrima], [Amount Including VAT] / " + tbKurs.Text.Replace(",", ".") + " AS [Iznos u Evrima sa PDV]" +
                        " FROM dbo.[Stirg Produkcija$Sales Line] " +
                        " WHERE([Document No_] = N'" + nalog + "')  AND ([Sell-to Customer No_] <> N'')";
            DataTable dt = metode.DB.baza_upit(qUpit);
            if (dt.Rows.Count > 0)
            {
                dgvSalesLine.DataSource = dt;
                dgvSalesLine.Columns["Vrednost"].DefaultCellStyle.Format = "N2";
                dgvSalesLine.Columns["Unit Price"].DefaultCellStyle.Format = "N2";
                dgvSalesLine.Columns["Quantity"].DefaultCellStyle.Format = "N";
                dgvSalesLine.Columns["Vrednost sa PDV"].DefaultCellStyle.Format = "N2";
                dgvSalesLine.Columns["Iznos u Evrima"].DefaultCellStyle.Format = "N2";
                dgvSalesLine.Columns["Iznos u Evrima sa PDV"].DefaultCellStyle.Format = "N2";

                dgvSalesLine.Columns["Vrednost"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvSalesLine.Columns["Unit Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvSalesLine.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvSalesLine.Columns["Vrednost sa PDV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvSalesLine.Columns["Iznos u Evrima"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvSalesLine.Columns["Iznos u Evrima sa PDV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            else
            {
                dgvSalesLine.DataSource = null;

            }
        }

        private void dgvSalesHeader_Click(object sender, EventArgs e)
        {
            if (dgvSalesHeader.CurrentRow != null)
            {
                ucitajStavke(dgvSalesHeader.CurrentRow.Cells["No_"].Value.ToString());
            }
        }

        private void dgvSalesHeader_MouseEnter(object sender, EventArgs e)
        {
            dgvSalesHeader.Focus();
        }



        private void dgvSalesLine_MouseEnter(object sender, EventArgs e)
        {
            dgvSalesLine.Focus();
        }

        private void dgvSalesHeader_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSalesHeader.CurrentRow != null)
            {
                ucitajStavke(dgvSalesHeader.CurrentRow.Cells["No_"].Value.ToString());
            }
        }

        private void tbKurs_Leave(object sender, EventArgs e)
        {
            if (tbKurs.Text != "")
            {
                metode.DB.pristup_bazi("UPDATE kurs SET   kurs =" + tbKurs.Text.Replace(",", ".") + " WHERE(valuta = N'EUR')");
            }
        }

        private void ucitajKurs()
        {
            tbKurs.Text = metode.DB.baza_upit("SELECT valuta, kurs FROM [stirg_local].dbo.kurs WHERE(valuta = N'EUR')").Rows[0]["kurs"].ToString();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
    }
}
