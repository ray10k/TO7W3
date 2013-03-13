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
    public partial class Form1 : Form
    {
        private List<KeyValuePair<string, NumberPlateCoordinates>> xmlData;
        private List<NumberPlateCoordinates> algoData;

        private List<VisionAlgorithm> algorithms;

        public Form1()
        {
            InitializeComponent();
            algoData = new List<NumberPlateCoordinates>();
            algorithms = new List<VisionAlgorithm>();

            // ADD ALGORITHMS HERE
            //         /\
            //        //\\
            //       //||\\
            //      // || \\
            //         ||
            //
            // example: algorithms.add(new workingAlgorithm());

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
                ShowXmlDataInGui();
            }
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            if (xmlData == null)
                xmlData = XMLReader.ReadXML();
            ShowXmlDataInGui();

            Bitmap b;
            for (int i = 0; i < xmlData.Count; i++)
            {
                b = new Bitmap(XMLReader.xmlPath.Substring(0, XMLReader.xmlPath.LastIndexOf("\\") + 1) + xmlData[i].Value.FileName);
                algoData.Add(algorithms[cbAlgo.SelectedIndex].DoAlgorithm(b));
            }
        }

        private void ShowXmlDataInGui()
        {
            cbImage.Items.Clear();
            for (int i = 0; i < xmlData.Count; i++)
                cbImage.Items.Add(xmlData[i].Value.FileName);
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
            //pbInput.Image = new Bitmap(path + xmlData[index].Value.FileName);

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
        }

        private double CalculateOverlap()
        {
            double overlap = 0.0;

            return overlap;
        }
    }
}
