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
using System.IO;
using System.Threading;
using System.Globalization;
using System.Drawing.Printing;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlTypes;
using System.Transactions;
using System.Xml;

namespace ProdajnePorudzbine
{
    public partial class Form1 : Form
    {
        string uslov = "";
        string naziv = "ProdajnePorudzbine_";
        string dodatniUslov = "";
        string exclude = "";
        ReportDocument ReportDoc;


        int brojIzbacenih;
        string[] kupci;

        public Form1()
        {

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us", false);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-us", false);

            InitializeComponent();

            // popuniED();

            popuniNalog(0);
            popuniKupac();
            popuniType();
            ucitajKurs();

            DataGridViewCheckBoxColumn cbBrisanje = new DataGridViewCheckBoxColumn();
            dgvSalesHeader.Columns.Insert(0, cbBrisanje);
            cbBrisanje.HeaderText = "Izbaci";
            cbBrisanje.Name = "cbBrisanje";
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

            uslov = "";
            naziv = "ProdajnePorudzbine_";
            string qUpit = "SELECT        dbo.[Stirg Produkcija$Sales Header].No_, dbo.[Stirg Produkcija$Customer].Name, dbo.[Stirg Produkcija$Sales Header].[External Document No_], dbo.[Stirg Produkcija$Sales Header].[Document Date]," +

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
                     "     dbo.[Stirg Produkcija$Customer] ON dbo.[Stirg Produkcija$Sales Header].[Sell-to Customer No_] = dbo.[Stirg Produkcija$Customer].No_ ";

            uslov += " where    (dbo.[Stirg Produkcija$Sales Header].[Document Type] = " + cbType.SelectedValue.ToString() + ") ";

            if (cbPeriod.Checked)
            {

                naziv = datumOd.Day.ToString("00") + "." + datumOd.Month.ToString("00") + "-" + datumDo.Day.ToString("00") + "." + datumDo.Month.ToString("00") + "." + datumDo.Year.ToString("00");

                uslov += " and (dbo.[Stirg Produkcija$Sales Header].[Document Date] >= CONVERT(DATETIME, '" + datumOd.Year + "-" + datumOd.Month + "-" + datumOd.Day + " 00:00:00', 102))" +
                     " and ( dbo.[Stirg Produkcija$Sales Header].[Document Date] <= CONVERT(DATETIME, '" + datumDo.Year + "-" + datumDo.Month + "-" + datumDo.Day + " 23:59:59', 102)) ";
            }

            if (cbNalog.Text != "")
            {
                naziv += " " + cbNalog.Text;
                uslov += " and (dbo.[Stirg Produkcija$Sales Header].No_ = N'" + cbNalog.Text + "')";
            }

            if (cbKupac.Text != "")
            {
                naziv += " " + cbKupac.Text;
                uslov += " AND (dbo.[Stirg Produkcija$Customer].No_ = N'" + cbKupac.SelectedValue + "')";
            }

            if (cbDomaciStrani.Text == "Domaci")
            {
                naziv += " Domaci";
                uslov += " and ( dbo.[Stirg Produkcija$Sales Header].[Customer Posting Group] = N'DOMACI') ";
            }
            if (cbDomaciStrani.Text == "Strani")
            {
                naziv += " Strani";
                uslov += " and ( dbo.[Stirg Produkcija$Sales Header].[Customer Posting Group] = N'INO') ";
            }

            uslov += exclude;
            qUpit += uslov;
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
                btnStampa.Enabled = true;
                btnPDF.Enabled = true;

            }
            else
            {
                dgvSalesHeader.DataSource = null;
                MessageBox.Show("Nema podataka za zadati kreiterijum.");

                btnStampa.Enabled = false;
                btnPDF.Enabled = false;
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
                if (r.DefaultCellStyle.BackColor.Name != "Red")
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
            }
            if (cbDomaciStrani.Text != "")
            {
                if (cbDomaciStrani.Text == "Strani")
                {

                    lblS.Text = strani.ToString("#,###.##") + " RSD";
                    lblStraniPDV.Text = straniPDV.ToString("#,###.##") + " RSD";
                    lblStraniEvro.Text = straniEvro.ToString("#,###.##") + " €";
                    lblStraniEvroPDV.Text = straniEvroPDV.ToString("#,###.##") + " €";

                    lblD.Text = "";
                    lblDomaciPDV.Text = "";
                    lblUkuponoEvroDomaci.Text = "";
                    lblDomaciEvroPDV.Text = "";
                }
                else
                {

                    lblS.Text = "";
                    lblStraniPDV.Text = "";
                    lblStraniEvro.Text = "";
                    lblStraniEvroPDV.Text = "";


                    lblD.Text = domaci.ToString("#,###.##") + " RSD";
                    lblDomaciPDV.Text = domaciPDV.ToString("#,###.##") + " RSD";
                    lblUkuponoEvroDomaci.Text = domaciEvro.ToString("#,###.##") + " €";
                    lblDomaciEvroPDV.Text = domaciEvroPdv.ToString("#,###.##") + " €";
                }
            }
            else
            {
                lblS.Text = strani.ToString("#,###.##") + " RSD";
                lblStraniPDV.Text = straniPDV.ToString("#,###.##") + " RSD";
                lblStraniEvro.Text = straniEvro.ToString("#,###.##") + " €";
                lblStraniEvroPDV.Text = straniEvroPDV.ToString("#,###.##") + " €";

                lblD.Text = domaci.ToString("#,###.##") + " RSD";
                lblDomaciPDV.Text = domaciPDV.ToString("#,###.##") + " RSD";
                lblUkuponoEvroDomaci.Text = domaciEvro.ToString("#,###.##") + " €";
                lblDomaciEvroPDV.Text = domaciEvroPdv.ToString("#,###.##") + " €";
            }

            lblU.Text = (strani + domaci).ToString("#,###.##") + " RSD";
            lblPDV.Text = (straniPDV + domaciPDV).ToString("#,###.##") + " RSD";
            lblUkupnoEvroBez.Text = (straniEvro + domaciEvro).ToString("#,###.##") + " €";
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

        private void dgvSalesHeader_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {



        }

        private void dgvSalesHeader_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvSalesHeader.CurrentCell.ColumnIndex.ToString() == "0")
            {
                DataGridViewCheckBoxCell cbZaBrisanje = new DataGridViewCheckBoxCell();
                cbZaBrisanje = (DataGridViewCheckBoxCell)dgvSalesHeader.Rows[dgvSalesHeader.CurrentRow.Index].Cells[0];

                if (e.ColumnIndex == 0)
                {
                    if (cbZaBrisanje.Value == null)
                        cbZaBrisanje.Value = true;
                    else cbZaBrisanje.Value = !bool.Parse(cbZaBrisanje.Value.ToString());


                    if (bool.Parse(cbZaBrisanje.Value.ToString()))
                    {
                        dgvSalesHeader.CurrentRow.DefaultCellStyle.BackColor = Color.Red;

                    }
                    else
                        dgvSalesHeader.CurrentRow.DefaultCellStyle.BackColor = Color.White;
                }

                ukupno();
                string BOJA = dgvSalesHeader.CurrentRow.DefaultCellStyle.BackColor.Name;
                if (BOJA == "Red")
                {
                    dgvSalesHeader.CurrentRow.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.DarkRed;
                    dgvSalesHeader.CurrentRow.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
                }
                if (BOJA == "White")
                {
                    dgvSalesHeader.CurrentRow.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
                    dgvSalesHeader.CurrentRow.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
                }
            }
        }

        private void izbaciIzIzvestaja()
        {
            dodatniUslov = "";

            foreach (DataGridViewRow r in dgvSalesHeader.Rows)
            {
                if (r.DefaultCellStyle.BackColor.Name == "Red")
                {
                    dodatniUslov += " and (dbo.[Stirg Produkcija$Sales Header].No_ <> N'" + r.Cells["No_"].Value.ToString() + "') ";
                }
            }



        }

        private void btnStampa_Click(object sender, EventArgs e)
        {
            izbaciIzIzvestaja();

            makeReport("C:\\Program files\\SM\\ProdajnePoruzbine.rpt");
            SetParameters(uslov + dodatniUslov, tbKurs.Text);

            Report rep = new Report(ReportDoc);
            rep.ShowDialog();

        }

        private void SetParameters(string uslov, string kurs)
        {
            ReportDoc.SetParameterValue("uslov", uslov);
            ReportDoc.SetParameterValue("kurs", kurs.Replace(".", ","));

        }

        private void makeReport(string ReportFile)
        {
            ReportDoc = new ReportDocument();
            TextReader textReader = new StreamReader("c:\\Program files\\SM\\dblogon.txt");
            string uid = textReader.ReadLine();
            string pwd = textReader.ReadLine();
            string server = textReader.ReadLine();
            string db = textReader.ReadLine();
            textReader.Close();

            ReportDoc.Load(ReportFile);
            ReportDoc.SetDatabaseLogon(uid, pwd, server, db);
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo("C:\\Dokumenti");
            if (!dir.Exists)
            {
                Directory.CreateDirectory("C:\\Dokumenti");
            }

            makeReport("C:\\Program files\\SM\\ProdajnePoruzbine.rpt");
            SetParameters(uslov, tbKurs.Text);

            //  Report rep = new Report(ReportDoc);
            naziv += ".pdf";
            ReportDoc.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, "C:\\Dokumenti\\" + naziv);

            MessageBox.Show("PDF file uspesno sacuvan u C:\\Dokumenti\\" + naziv, "Uspesno", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormIzbaciKupca f1 = new FormIzbaciKupca();
            f1.ShowDialog();
            exclude = "";
            rtbIzbaceni.Text = "";

            try
            {
                exclude += f1.filter;
                brojIzbacenih = f1.brojIzbacenih;
                kupci = f1.kupci;

                string sviKupci = string.Join(",", kupci);
                rtbIzbaceni.Text = sviKupci;
            }
            catch
            {
                
            }
            }
    }
}
