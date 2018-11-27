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
    public partial class FormIzbaciKupca : Form
    {
        public string filter { get; set; }
        public string[] kupci { get; set; }
        public int brojIzbacenih { get; set; }
        int brojSelektovanih = 0;
        public FormIzbaciKupca(string[] selektovaniKupci)
        {
            InitializeComponent();
            popuniKupce();
            filter = "";
            DataGridViewCheckBoxColumn cbBrisanje = new DataGridViewCheckBoxColumn();
            dgvIzbaci.Columns.Insert(0, cbBrisanje);
            cbBrisanje.ReadOnly = false;
            cbBrisanje.HeaderText = "Izbaci";
            cbBrisanje.Name = "cbBrisanje";
            cbBrisanje.TrueValue = true;
            cbBrisanje.FalseValue = false;

            oznaciKupce(selektovaniKupci);
        }

        private void popuniKupce()
        {
            dgvIzbaci.DataSource = metode.DB.baza_upit(" SELECT   No_, Name FROM     dbo.[Stirg Produkcija$Customer] order by name");

        }

        private void oznaciKupce(string[] kupciZaOznacavanje)
        {
            if (kupciZaOznacavanje != null)
            {

                int brojKupaca = kupciZaOznacavanje.Length;
                if (brojKupaca > 0)
                {
                    foreach (string kup in kupciZaOznacavanje)
                    {
                      
                        foreach (DataGridViewRow r in dgvIzbaci.Rows)
                        {
                           
                            try
                            {
                                if (r.Cells["Name"].Value.ToString() == kup)
                                {

                                    //dgvIzbaci.CurrentCell = dgvIzbaci.Rows[r.Index].Cells[0];
                                    //dgvIzbaci_CellContentClick();

                                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)r.Cells[0];
                                    chk.Value = chk.TrueValue;
                                    ((DataGridViewCheckBoxCell)r.Cells[0]).Value = true;



                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                    }
                  
                }
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            int brojac = 0;
            kupci = new string[brojSelektovanih];

            foreach (DataGridViewRow r in dgvIzbaci.Rows)
            {
                if (r.DefaultCellStyle.BackColor.Name == "Red")
                {
                    filter += " AND (dbo.[Stirg Produkcija$Customer].No_ <> N'" + r.Cells["No_"].Value.ToString() + "') ";
                    kupci[brojac] = r.Cells["Name"].Value.ToString();
                    brojac++;
                }
            }

            brojIzbacenih = brojac;
            this.Close();
        }

        private void dgvIzbaci_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvIzbaci.CurrentCell.ColumnIndex.ToString() == "0")
            {
                DataGridViewCheckBoxCell cbZaBrisanje = new DataGridViewCheckBoxCell();
                cbZaBrisanje = (DataGridViewCheckBoxCell)dgvIzbaci.Rows[dgvIzbaci.CurrentRow.Index].Cells[0];

                if (e.ColumnIndex == 0)
                {
                    if (cbZaBrisanje.Value == null)
                        cbZaBrisanje.Value = true;
                    else cbZaBrisanje.Value = !bool.Parse(cbZaBrisanje.Value.ToString());


                    if (bool.Parse(cbZaBrisanje.Value.ToString()))
                    {
                        dgvIzbaci.CurrentRow.DefaultCellStyle.BackColor = Color.Red;
                        brojSelektovanih++;
                    }
                    else
                    {
                        dgvIzbaci.CurrentRow.DefaultCellStyle.BackColor = Color.White;
                        brojSelektovanih--;
                    }
                }
                string BOJA = dgvIzbaci.CurrentRow.DefaultCellStyle.BackColor.Name;
                if (BOJA == "Red")
                {
                    dgvIzbaci.CurrentRow.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.DarkRed;
                    dgvIzbaci.CurrentRow.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
                }
                if (BOJA == "White")
                {
                    dgvIzbaci.CurrentRow.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
                    dgvIzbaci.CurrentRow.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
                }
            }
        }

        private void dgvIzbaci_CellContentClick()
        {
            if (dgvIzbaci.CurrentCell.ColumnIndex.ToString() == "0")
            {
                DataGridViewCheckBoxCell cbZaBrisanje = (DataGridViewCheckBoxCell)dgvIzbaci.Rows[dgvIzbaci.CurrentRow.Index].Cells[0];


                if (cbZaBrisanje.Value == null)
                    cbZaBrisanje.Value = true;
                else cbZaBrisanje.Value = !bool.Parse(cbZaBrisanje.Value.ToString());


                if (bool.Parse(cbZaBrisanje.Value.ToString()))
                {
                    dgvIzbaci.Rows[3].Visible = false;
                    dgvIzbaci.CurrentRow.DefaultCellStyle.BackColor = Color.Red;
                    brojSelektovanih++;
                }
                else
                {
                    dgvIzbaci.CurrentRow.DefaultCellStyle.BackColor = Color.White;
                    brojSelektovanih--;
                }

            }
        }
    }
}
