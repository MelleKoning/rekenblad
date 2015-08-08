using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spire.Pdf;
using Spire.Pdf.Graphics;

namespace Rekenblad
{
    public class MaakTafelBlad
    {
        public PdfDocument CreateHelloWordlPdf(string filename)
        {
            //Create a pdf document.
            PdfDocument doc = new PdfDocument();

            // Create one page
            PdfPageBase page = doc.Pages.Add();

            int vanlinks = 0;
            for (int aantal = 76; aantal <= 82; aantal++)
            {
                string inhoud = Tafeltje(aantal);


                MaakHetPdfDocument(page, inhoud, vanlinks);
                vanlinks += 70;
            }

            //Save pdf file.
            doc.SaveToFile(filename);
            doc.Close();

            return doc;

        }

        public string Tafeltje(int tafeltjevan)
        {
            StringBuilder tafelresultaat = new StringBuilder();

            // int tafelvan = 1;

            for (int n = 1; n <= 10; n++)
            {
                tafelresultaat.AppendLine(string.Format("{0} x {1} = {2}", n, tafeltjevan, n * tafeltjevan));
            }

            return tafelresultaat.ToString();
        }


        public void MaakHetPdfDocument(PdfPageBase page, string inhoud, int linksrechtspositie)
        {

            //Draw the text
            page.Canvas.DrawString(inhoud,
                new PdfFont(PdfFontFamily.Helvetica, 10f),
                new PdfSolidBrush(Color.Black), linksrechtspositie
                , 10);


        }



    }
}

