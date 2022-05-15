using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultithreadingOnBoats;
using System.Drawing;
using System.IO;

namespace MultithreadingImitation
{
    public class ShipWinForm : Ship
    {
        public Button Button { get; set; }

        string[] allImages = Directory.GetFiles(@"..\..\..\Pictures\Кораблики");

        Random rnd = new Random();


     
 
        public ShipWinForm(Types type, Sizes size) : base(type, size)
        {
            Button = CreateButton();
            Button.Name = $"Ship - Type {type} Size {size}";
            Button.Click += ButtonClick;
           
        }

        private Button CreateButton()
        {
            Button button = new Button();
            button.Size = new Size(50, 50);
            button.BackgroundImageLayout = ImageLayout.Stretch;
            button.BackgroundImage = RandomImage();
           
            return button;
        }

        public void ButtonClick(object sender, EventArgs e)
        {
            MessageBox.Show(Button.Name);
        }
        private Image RandomImage()
        {   
            return Image.FromFile(allImages[rnd.Next(allImages.Length)]);
        }



    }
}
