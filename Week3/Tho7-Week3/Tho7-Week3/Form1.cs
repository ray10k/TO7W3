using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tho7_Week3.ImageModifications;
using Tho7_Week3.ImageModifications.Filters;
using Tho7_Week3.ImageModifications.Noise;

namespace Tho7_Week3
{
    /*
     * Sommige onderdelen zijn nog uitgecommentarieerd aangezien ik nog geen noise filters had
     * 
     * 
     * 
     * */
    /// <summary>
    /// Form to load the images and process them with the given filters
    /// </summary>
    /// <author>
    /// Erwim Bonnet
    /// </author>
    public partial class Form1 : Form
    {
        private Bitmap InputImage;

        private List<VisionAlgorithm> filters;
        private List<NoiseBase> noise;

        private int pixCount = 0;

        public Form1()
        {
            InitializeComponent();
            imageView1.SetParent(this);
            imageView2.BoxName = "Image with Noise";
            imageView3.BoxName = "Result Image";
            InitFilters();
            InitNoise();
        }

        private void InitFilters()
        {
            //Add filters here
            filters = new List<VisionAlgorithm>();
            filters.Add(new MedianAlgorithmUnsafe3x3BMCopy("Median"));

            foreach (VisionAlgorithm alg in filters)
            {
                CBFilter.Items.Add(alg.Name);
            }
            CBFilter.SelectedIndex = 0;
        }

        private void InitNoise()
        {
            //Add noise here
            noise = new List<NoiseBase>();
            noise.Add(new SnPNoiseAlgorithm("Salt and Pepper - 10", 10));
            noise.Add(new SnPNoiseAlgorithm("Salt and Pepper - 20"));

            foreach (NoiseBase n in noise)
            {
                CBNoise.Items.Add(n.Name);
            }
            CBNoise.SelectedIndex = 0;
        }

        private void openImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenImage();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
       
        private void InputImageDoubleClick(object sender, EventArgs e)
        {
            OpenImage();
        }

        public void OpenImage()
        {
            OpenFileDialog oFD = new OpenFileDialog();
            oFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            oFD.Filter = "Image Files(*.BMP;*.JPG;*.JPEG;*.PNG;)|*.BMP;*.JPG;*.JPEG;*.PNG;";
            oFD.FilterIndex = 1;
            oFD.RestoreDirectory = true;
            if (oFD.ShowDialog() == DialogResult.OK)
            {
                String CurrentFileName = Path.GetFullPath(oFD.FileName);
                InputImage = new Bitmap(CurrentFileName);
                imageView1.Image = InputImage;
                pixCount = InputImage.Width * InputImage.Height;
                PixCount.Text = pixCount + " Pixels";
            }
        }

        private void BStart_Click(object sender, EventArgs e)
        {
            bool canRun = true;
            if (CBNoise.Items.Count == 0 || CBFilter.Items.Count == 0)
                canRun = false;
            if (imageView1.Image == null)
                canRun = false;

            if (canRun)
            {
                int correct = 0;
                NoiseBase nb = null;

                foreach (NoiseBase nBase in noise)
                {
                    if (CBNoise.SelectedItem.Equals(nBase.Name))
                    {
                        nb = nBase;
                    }
                }
                imageView2.Image = nb.MakeNoise(imageView1.Image);
                correct = BitmapCompare.BmpCompare.GetEqualPixelCount(InputImage, imageView2.Image);
                NoisePixels.Text = correct + " Pixels";
                NoisePerc.Text = String.Format("{0:0.000}% ", ((double)correct / (double)pixCount) * 100.0);

                VisionAlgorithm alg = null;
                foreach (VisionAlgorithm al in filters)
                {
                    if (CBFilter.SelectedItem.Equals(al.Name))
                    {
                        alg = al;
                    }
                }
                imageView3.Image = alg.DoAlgorithm(imageView2.Image);
                MedianCompare.DoAlgorithm(InputImage, imageView3.Image);
                CorrectedPix.Text = MedianCompare.pixelsCorrect + " Pixels";
                CorrectedPerc.Text = String.Format("{0:0.000}% ", MedianCompare.percentageCorrect);
                //correct = BitmapCompare.BmpCompare.GetEqualPixelCount(InputImage, imageView3.Image);
                //CorrectedPix.Text = correct + " Pixels";
                //CorrectedPerc.Text = String.Format("{0:0.000}% ", ((double)correct / (double)pixCount) * 100.0);
                
            }
        }
    }
}
