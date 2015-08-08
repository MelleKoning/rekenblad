using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;

namespace Rekenblad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MaakTafelBlad mtb = new MaakTafelBlad();
            string filename = "HelloWorld.Pdf";
            PdfDocument doc = mtb.CreateHelloWordlPdf(filename);
            
            //Launching the Pdf file.
            PDFDocumentViewer(filename);
        }


        private void PDFDocumentViewer(string fileName)
        {
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch
            {
            }
        }

        private void btnPiramide_Click(object sender, EventArgs e)
        {
            string filename = "HelloWorld.Pdf";
            RekenPyramide rp = new RekenPyramide();
            PdfDocument doc = rp.CreateRekenPyramide(filename);
            PDFDocumentViewer(filename);
        }


    }
}
