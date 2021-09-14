using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ASS2;

namespace ASS2_WF
{
    public partial class usDirections : UserControl
    {
        DirectionType selectedDirection=null;
        public usDirections()
        {
            InitializeComponent();
        }


        DictType dict = DictType.Load<DictType>(1);
        private void usDirections_Load(object sender, EventArgs e)
        {
            Bind();
        }



        void Bind()
        {
            foreach(var d in dict.Directions)
            {
                toolStripComboBox1.Items.Add(d.Name);
            }
            try
            { toolStripComboBox1.SelectedIndex = 0; }
            catch { }  
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            foreach(var d in dict.Directions)
            {
                if (d.Name == toolStripComboBox1.ComboBox.SelectedItem  )
                    selectedDirection = d;
                BindDG();
                
            }
        }

        void BindDG()
        {
            dg1.DataSource = selectedDirection?.ToTable();
            
        }

        private void addDirection_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(textBox1.Text))
            {
                if (!dict.Directions.Exists(x => x.Name == textBox1.Text)){
                    DirectionType t = new DirectionType();
                    t.Name = textBox1.Text;
                    dict.Directions.Add(t);
                    dict.Save();

                    button2.PerformClick();
                    Bind();
                }
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnSave.PerformClick();
            selectedDirection.Items.Add(new DirectionItemType());
            BindDG();
        }

        private void dg1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dg1.Columns[e.ColumnIndex].Name == "usun")
            {
                btnSave.PerformClick();

                string name = dg1.Rows[e.RowIndex].Cells["colname"].Value.ToString();
                string wsr = dg1.Rows[e.RowIndex].Cells["colwsr"].Value.ToString();
                string pnafrom = dg1.Rows[e.RowIndex].Cells["colpnafrom"].Value.ToString();
                string pnato = dg1.Rows[e.RowIndex].Cells["colpnato"].Value.ToString();

                foreach (var i in selectedDirection.Items)
                {
                    if(i.Name==name)
                        if(i.WSR==wsr)
                            if(i.PnaFrom==pnafrom)
                                if (i.PnaTo == pnato)
                                {
                                    selectedDirection.Items.Remove(i);
                                    dict.Save();
                                    BindDG();
                                    break;
                                }

                }
            }
        }

        private void dg1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dg1.EndEdit();
            selectedDirection.Items.Clear();
            foreach(DataGridViewRow row in dg1.Rows)
            {
                string name = row.Cells["colname"].Value.ToString() ;
                string wsr = row.Cells["colwsr"].Value.ToString();
                string pnafrom = row.Cells["colpnafrom"].Value.ToString();
                string pnato = row.Cells["colpnato"].Value.ToString();

                selectedDirection.AddItem(new DirectionItemType() { WSR = wsr, PnaFrom = pnafrom, PnaTo = pnato, Name=name });
            }

            dict.Save();
            BindDG();
        }
    }
}
