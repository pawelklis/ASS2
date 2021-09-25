using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ASS2;

namespace ASS2_WF
{
    public partial class frmparcels : Form
    {
        public MachineType machine;
        public frmparcels()
        {
            InitializeComponent();

        }

        private Timer tm;

        private void frmparcels_Load(object sender, EventArgs e)
        {
            tm?.Stop();
            tm = new Timer();
            tm.Interval = 1000;
            tm.Tick += Tm_Tick;
            tm.Start();
        }

        private void Tm_Tick(object sender, EventArgs e)
        {
            BindDG();
        }

        public void BindDG()
        {
            try
            {
            dg1.Invoke(new Action(() =>
            {
                Task.Run(() => { dg1.Invoke(new Action(() => { dg1.DataSource = machine.PArcelsAtLineTable(); })); });
            }));
            }
            catch (Exception)
            {

    
            }

        }
    }
}
