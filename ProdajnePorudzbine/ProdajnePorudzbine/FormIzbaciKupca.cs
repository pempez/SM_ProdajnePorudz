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
        public FormIzbaciKupca()
        {
            InitializeComponent();
            popuniKupce();
            filter = "";
            DataGridViewCheckBoxColumn cbBrisanje = new DataGridViewCheckBoxColumn();
            dgvIzbaci.Columns.Insert(0, cbBrisanje);
            cbBrisanje.HeaderText = "Izbaci";
            cbBrisanje.Name = "cbBrisanje";

          
        }

        private void popuniKupce()
        {
            dgvIzbaci.DataSource = metode.DB.baza_upit(" SELECT   No_, Name FROM     dbo.[Stirg Produkcija$Customer] order by name");

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
                    kupci[brojac] = r.Cells["Name"].Value.ToString()+",";
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
            }
        }
    }
}
