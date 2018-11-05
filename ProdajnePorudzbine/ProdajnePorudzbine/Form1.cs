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

            popuniED();

            popuniNalog(0);
            popuniKupac();
            popuniType();
          
        }

        private void btnPronadji_Click(object sender, EventArgs e)
        {
            if(cbType.Text=="")
            {
                MessageBox.Show("morate odabrati Vrstu naloga!");
                cbType.Focus();
                return;
            }
            DateTime datumOd = new DateTime(dtpDatum.Value.Year, dtpDatum.Value.Month, dtpDatum.Value.Day);
            DateTime datumDo = new DateTime(dtpDatumDo.Value.Year, dtpDatumDo.Value.Month, dtpDatumDo.Value.Day);



            string qUpit = "SELECT        dbo.[Stirg Produkcija$Sales Header].No_, dbo.[Stirg Produkcija$Customer].Name, dbo.[Stirg Produkcija$Sales Header].[External Document No_], dbo.[Stirg Produkcija$Sales Header].[Document Date], t1.[Vrednost porudzbine], " +
                       "  dbo.[Stirg Produkcija$Sales Header].[Customer Posting Group] as Grupa, dbo.[Stirg Produkcija$Customer].No_ AS Kupac " +
                    " FROM dbo.[Stirg Produkcija$Sales Header] " +
      "   INNER JOIN " +
               "    (SELECT[Document No_], SUM(Amount) AS [Vrednost porudzbine] " +
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

            if (cbExternalDocumentNo.Text != "")
            {
                qUpit += " and ( dbo.[Stirg Produkcija$Sales Header].[External Document No_] = N'" + cbExternalDocumentNo.Text + "') ";
            }

            DataTable dt = metode.DB.baza_upit(qUpit);
            if (dt.Rows.Count > 0)
            {
                dgvSalesHeader.DataSource = dt;
                dgvSalesHeader.Columns["Kupac"].Visible = false;
                dgvSalesHeader.Columns["Vrednost porudzbine"].DefaultCellStyle.Format = "N2";
                dgvSalesHeader.Columns["Vrednost porudzbine"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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
            foreach(DataGridViewRow r in dgvSalesHeader.Rows)
            {
                if (r.Cells["Grupa"].Value.ToString() == "INO") strani += double.Parse(r.Cells["Vrednost porudzbine"].Value.ToString());
                else domaci += double.Parse(r.Cells["Vrednost porudzbine"].Value.ToString());
            }

            lblD.Text = domaci.ToString("#,###.##");
            lblS.Text = strani.ToString("#,###.##");
            lblU.Text = (strani + domaci).ToString("#,###.##");
        }
        private void popuniED()
        {

            cbExternalDocumentNo.DataSource = metode.DB.baza_upit("SELECT DISTINCT TOP (100) PERCENT [External Document No_]" +
                         " FROM             dbo.[Stirg Produkcija$Sales Header]  " +
                         "  ORDER BY [External Document No_]");
            cbExternalDocumentNo.DisplayMember = "External Document No_";
            cbExternalDocumentNo.ValueMember = "External Document No_";
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
            string qUpit = "SELECT        [Line No_], [Shipment Date], Quantity, [Unit Price], Amount " +
                        " FROM dbo.[Stirg Produkcija$Sales Line] " +
                        " WHERE([Document No_] = N'" + nalog + "')  AND ([Sell-to Customer No_] <> N'')";
            DataTable dt = metode.DB.baza_upit(qUpit);
            if (dt.Rows.Count > 0)
            {
                dgvSalesLine.DataSource = dt;
                dgvSalesLine.Columns["Amount"].DefaultCellStyle.Format = "N2";
                dgvSalesLine.Columns["Unit Price"].DefaultCellStyle.Format = "N2";
                dgvSalesLine.Columns["Quantity"].DefaultCellStyle.Format = "N";

                dgvSalesLine.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvSalesLine.Columns["Unit Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvSalesLine.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            else
            {
                dgvSalesLine.DataSource = null;
               
            }
        }

        private void dgvSalesHeader_Click(object sender, EventArgs e)
        {
            if(dgvSalesHeader.CurrentRow!=null)
            {
                ucitajStavke(dgvSalesHeader.CurrentRow.Cells["No_"].Value.ToString());
            }
        }
    }
}
