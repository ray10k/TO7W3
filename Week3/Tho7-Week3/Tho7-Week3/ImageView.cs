using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tho7_Week3
{
    /// <author>
    /// Erwim Bonnet
    /// </author>
    public partial class ImageView : UserControl
    {
        private Form1 parent;

        public ImageView()
        {
            InitializeComponent();
        }

        public void SetParent(Form1 form)
        {
            parent = form;
        }

        public string BoxName
        {
            set { groupBox1.Text = value; }
        }

        public Bitmap Image
        {
            get
            {
                return pictureBox1.Image as Bitmap;
            }
            set
            {
                pictureBox1.Image = value;
            }
        }

        private void DoOpenFile(object sender, EventArgs e)
        {
            if (parent != null)
                parent.OpenImage();
        }
    }
}
