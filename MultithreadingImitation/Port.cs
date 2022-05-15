using MultithreadingOnBoats;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MultithreadingImitation
{
    public partial class Port : Form
    {
        int  ShipCount = 50;
        ShipGeneratorWinForm generator;
        TunnelWinForm tunnel;
        public Port()
        {
            InitializeComponent();

           



        }

        private void start_Click(object sender, EventArgs e)
        {
            Thread a=new Thread(Start);
            a.Start();
          


        }
        public void Start()
        {
         
            
            //for (int i = 0; i < ShipCount; i++)
            //{
            //    var ship = new ShipWinForm(ShipGenerator.CreateType(), ShipGenerator.CreateSize());

            //    generator.ShipTable.Controls.Add(ship.Button);

            //}
            //for (int i = 0; i < 3; i++)
            //{
            //    MessageBox.Show(ShipCount.ToString());
            //}
        }

        private void Port_Load(object sender, EventArgs e)
        {
            generator = new ShipGeneratorWinForm(ShipCount, this);
            tunnel = new TunnelWinForm(this);
            for (int i = 0; i < ShipCount; i++)
            {
                var ship = new ShipWinForm(ShipGenerator.CreateType(), ShipGenerator.CreateSize());

                generator.ShipTable.Controls.Add(ship.Button);

            }
        }
    }
}
