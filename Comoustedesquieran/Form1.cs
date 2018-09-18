using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu;
using Emgu.CV;
using Emgu.CV.Structure;
//edges
namespace Comoustedesquieran
{
    public partial class Form1 : Form
    {
        Image<Bgr, byte> ImgInput;
        public Form1()
        {
            InitializeComponent();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ImgInput = new Image<Bgr, byte>(ofd.FileName);
                imageBox1.Image = ImgInput;
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que deseas salir?", "System Message", MessageBoxButtons.YesNo) == DialogResult.Yes) ;
            {
                this.Close();
            }
        }

        private void cannyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(ImgInput == null)
            {
                return;
            }


            Image<Gray, byte> imgCanny = new Image<Gray, byte>(ImgInput.Width, Height, new Gray(100));
            imgCanny = ImgInput.Canny(50, 30);
            imageBox1.Image = imgCanny;
        }

        private void sobelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ImgInput == null)
            {
                return;
            }

            Image<Gray, byte> _imgGray = ImgInput.Convert<Gray, byte>();
            Image<Gray, float> _imgSobel = new Image<Gray, float>(ImgInput.Width, ImgInput.Height, new Gray(100));
            _imgSobel = _imgGray.Sobel(1,1,31);
            imageBox1.Image = _imgSobel;
        }

        private void laplacianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ImgInput == null)
            {
                return;
            }

            Image<Gray, byte> _imgGray = ImgInput.Convert<Gray, byte>();
            Image<Gray, float> imgLaplace = new Image<Gray, float>(ImgInput.Width, ImgInput.Height, new Gray(100));
            imgLaplace = _imgGray.Laplace(5);
            imageBox1.Image = imgLaplace;
        }
    }
}
