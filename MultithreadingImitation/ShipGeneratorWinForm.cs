using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultithreadingImitation
{
   
    public class ShipGeneratorWinForm
    {
        Form MainForm { get; set; }

        int NumberOfAllShips;

        public TableLayoutPanel ShipTable{ get; set; }

        public ShipGeneratorWinForm(int numberOfAllShips, Form form)
        {
            MainForm = form;
            NumberOfAllShips = numberOfAllShips;
            ShipTable=CreateTableLayot();
        }

        public TableLayoutPanel CreateTableLayot()
        {
            var table = new TableLayoutPanel();
            table.Name = "shipGenerator";
            var heightTable = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(NumberOfAllShips) / 10));
            var widthTable = NumberOfAllShips * 80 / heightTable;
            table.Size = new Size(widthTable, heightTable * 50);
            table.Location = new Point(0, 20);
            //table.BackColor = MainForm.BackColor;
            table.BackColor = Color.Black;
            table.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            for (int i = 0; i < heightTable; i++)
            {
                table.RowStyles.Add(new RowStyle(SizeType.Percent, table.Size.Height));
                table.RowCount++;
            }

            for (int i = 0; i < NumberOfAllShips / (heightTable); i++)
            {
                table.ColumnCount++;
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent));
                table.ColumnStyles[i].Width = table.Width / NumberOfAllShips;
            }
            MainForm.Controls.Add(table);
            return table;
        }
    }
}
