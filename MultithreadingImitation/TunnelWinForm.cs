using MultithreadingOnBoats;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultithreadingImitation
{
    public class TunnelWinForm : Tunnel
    {
        Form MainForm;

        public TableLayoutPanel TunnelTable{get;set;}
            
        
        public TunnelWinForm(Form form):base()
        {
            MainForm = form;
            TunnelTable = CreateTable();
        }
        public TableLayoutPanel CreateTable()
        {

            var table = new TableLayoutPanel();
            var heightTable = 1;
            var widthTable = MaxShipsInTunnel * 80 / heightTable;
            table.Size = new Size(widthTable, heightTable * 50);
            table.Location = new Point(200, 300);
            table.BackColor = Color.Yellow;
            table.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            for (int i = 0; i < heightTable; i++)
            {
                table.RowStyles.Add(new RowStyle(SizeType.Percent, table.Size.Height));
                table.RowCount++;
            }

            for (int i = 0; i < MaxShipsInTunnel; i++)
            {
                table.ColumnCount++;
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent));
                table.ColumnStyles[i].Width = table.Width / MaxShipsInTunnel;
            }

            MainForm.Controls.Add(table);
            return table;
        }
    }
}
