using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Week4.Algorithms;

namespace Week4
{
    /// <Author>
    /// Erwin Bonnet
    /// </Author>
    public partial class Form1 : Form
    {
        private List<KeyValuePair<string, NumberPlateCoordinates>> xmlData;
        private List<NumberPlateCoordinates> algoData;

        private List<VisionAlgorithm> algorithms;

        private List<double> overlap;
        private double avgOverlap;

        public Form1()
        {
            InitializeComponent();
            algoData = new List<NumberPlateCoordinates>();
            algorithms = new List<VisionAlgorithm>();
            algorithms.Add(new SobolAlgorithm("Sobol scan"));
            // ADD ALGORITHMS HERE
            //         /\
            //        //\\
            //       //||\\
            //      // || \\
            //         ||
            //
            // example: algorithms.add(new workingAlgorithm());
            overlap = new List<double>();
            avgOverlap = 0.0;

            cbAlgo.Items.Clear();
            for (int i = 0; i < algorithms.Count; i++)
                cbAlgo.Items.Add(algorithms[i].Name);
        }

        private void bOpenXml_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "XML files | *.xml";
            ofd.AddExtension = true;
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                xmlData = XMLReader.ReadXML(ofd.FileName);
                ShowDataInGui();
            }
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            if (xmlData == null)
                xmlData = XMLReader.ReadXML();

            Bitmap b;
            for (int i = 0; i < xmlData.Count; i++)
            {
                b = new Bitmap(XMLReader.xmlPath.Substring(0, XMLReader.xmlPath.LastIndexOf("\\") + 1) + xmlData[i].Value.FileName);
                algoData.Add(algorithms[cbAlgo.SelectedIndex].DoAlgorithm(b));
            }
            ShowDataInGui();
        }

        private void ShowDataInGui()
        {
            cbImage.Items.Clear();
            double o;
            for (int i = 0; i < xmlData.Count; i++)
            {
                cbImage.Items.Add(xmlData[i].Value.FileName);
                if (algoData.Count != 0)
                {
                    o = CalculateOverlap(i);
                    overlap.Add(o);
                    avgOverlap += o;
                }
            }
            avgOverlap /= (double)xmlData.Count;
            cbImage.SelectedIndex = 0;
        }

        private void cbImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbImage.SelectedIndex;
            Point p;
            p = xmlData[index].Value.LeftTop;
            lXMLul.Text = "{" + p.X + ", " + p.Y + "}";
            p = xmlData[index].Value.RightTop;
            lXMLur.Text = "{" + p.X + ", " + p.Y + "}";
            p = xmlData[index].Value.LeftBottom;
            lXMLll.Text = "{" + p.X + ", " + p.Y + "}";
            p = xmlData[index].Value.RightBottom;
            lXMLlr.Text = "{" + p.X + ", " + p.Y + "}";

            string path = XMLReader.xmlPath;
            path = path.Substring(0, path.IndexOf("\\") + 1);
            pbInput.Image = new Bitmap(path + xmlData[index].Value.FileName);

            if (algoData.Count != 0 && algoData.Count > index)
            {
                p = algoData[index].LeftTop;
                lALGOul.Text = "{" + p.X + ", " + p.Y + "}";
                p = algoData[index].RightTop;
                lALGOur.Text = "{" + p.X + ", " + p.Y + "}";
                p = algoData[index].LeftBottom;
                lALGOll.Text = "{" + p.X + ", " + p.Y + "}";
                p = algoData[index].RightBottom;
                lALGOlr.Text = "{" + p.X + ", " + p.Y + "}";
            }
            if (overlap.Count != 0)
                lOverlap.Text = String.Format("{0:0.000}% ", overlap[index]);
            else
                lOverlap.Text = String.Format("{0:0.000}% ", 0.0);
            lAVGoverlap.Text = String.Format("{0:0.000}% ", avgOverlap);
        }

        private double CalculateOverlap(int cbImageIndex)
        {
            double overlap = 0.0;
            Rectangle rXml = AverageValues(xmlData[cbImageIndex].Value.LeftTop, xmlData[cbImageIndex].Value.RightTop, xmlData[cbImageIndex].Value.LeftBottom, xmlData[cbImageIndex].Value.RightBottom);
            Rectangle rAlgo = AverageValues(algoData[cbImageIndex].LeftTop, algoData[cbImageIndex].RightTop, algoData[cbImageIndex].LeftBottom, algoData[cbImageIndex].RightBottom);

            int xmlArea = rXml.Width * rXml.Height;
            int algoArea = rAlgo.Width * rAlgo.Height;

            if (rXml.IntersectsWith(rAlgo)) 
            {
                int[] xxyy = new int[4];
                xxyy[0] = rXml.X <= rAlgo.X ? rAlgo.X : rXml.X;
                xxyy[1] = rXml.Right <= rAlgo.Right ? rXml.Right : rAlgo.Right;
                xxyy[2] = rXml.Y <= rAlgo.Y ? rAlgo.Y : rXml.Y;
                xxyy[3] = rXml.Bottom <= rAlgo.Bottom ? rXml.Bottom : rAlgo.Bottom;
                overlap = (double)(xxyy[1] - xxyy[0]) * (xxyy[3] - xxyy[2]) / (double)xmlArea;
            }
            else if (rXml.X < rAlgo.X && rXml.Y < rAlgo.Y && rXml.Width > rAlgo.Width && rXml.Height > rAlgo.Height)
            {
                overlap = (double)algoArea / (double)xmlArea;
            }
            overlap *= 100.0;
            return overlap;
        }

        private Rectangle AverageValues(Point lT, Point rT, Point lB, Point rB)
        {
            int x, y, width, height;

            x = (lT.X + lB.X) / 2;
            y = (lT.Y + rT.Y) / 2;
            width = (rT.X + rB.X) / 2 - x;
            height = (lB.Y + rB.Y) / 2 - y;

            return new Rectangle(x, y, width, height);
        }
    }
}
