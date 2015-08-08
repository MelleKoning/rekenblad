using System;
using System.Drawing;
using Spire.Pdf;
using Spire.Pdf.Graphics;

namespace Rekenblad
{
    internal class RekenPyramide
    {
        internal int[,] pyrArray; 

        public PdfDocument CreateRekenPyramide(string filename)
        {

            //Create a pdf document.
            PdfDocument doc = new PdfDocument();

            // Create one page
            PdfPageBase page = doc.Pages.Add();

            Random rnd = new Random();
            for (int pyramide = 1; pyramide <= 3; pyramide++)
            {
                int basislengte = 8;
                int maxbasisgetal = 14;
                pyrArray = new int[basislengte + 2, basislengte + 2];
                for (int aantal = 1; aantal <= basislengte; aantal++)
                {
                    pyrArray[1, aantal] = rnd.Next(1, maxbasisgetal + 1);
                }

                for (int rij = 2; rij <= basislengte; rij++)
                {
                    for (int aantal = 1; aantal <= basislengte; aantal ++)
                    {
                        pyrArray[rij, aantal] = pyrArray[rij - 1, aantal] + pyrArray[rij - 1, aantal + 1];
                    }

                }
             
                int papierhoogte = ((int) page.Canvas.Size.Height/3 - 40) * pyramide;

                TekenHelePyramideOpPapier(page, pyrArray, basislengte, papierhoogte);
            }
            //Save pdf file.
            doc.SaveToFile(filename);
            doc.Close();

            return doc;

        }

        private void TekenHelePyramideOpPapier(PdfPageBase page, int[,] pyramide, int basislengte, int papierhoogte)
        {
            PdfSolidBrush blackBrush = new PdfSolidBrush(Color.Black);
            PdfFont helv = new PdfFont(PdfFontFamily.Helvetica, 15f);
            Random rnd = new Random();
            
            for (int rij = 1; rij <= basislengte; rij++)
            {
                for (int aantal = 1; aantal <= (basislengte-rij)+1; aantal++)
                {
                    Console.Write(pyramide[rij,aantal].ToString()+ " ");
                    int x = aantal*50 + 25*rij;
                    int y = papierhoogte - rij*25;
                    int rechthook = 50;
                    RectangleF rectangleF = new RectangleF(x-5,y-5,rechthook,25);
                    PdfLinearGradientBrush  gradBrush = new PdfLinearGradientBrush(rectangleF,new PdfRGBColor(200,200,200),new PdfRGBColor(255,255,255),PdfLinearGradientMode.Horizontal);
                    
                    page.Canvas.DrawRectangle(gradBrush, x - 5, y - 5, rechthook, 25);
                    if (DezeCelTekenen(basislengte, rnd, rij, aantal))
                    {
                        page.Canvas.DrawString(pyramide[rij, aantal].ToString(),
                            helv,
                            blackBrush, x,
                            y);
                    }

                }
                Console.WriteLine();

            }

        }

        private static bool DezeCelTekenen(int basislengte, Random rnd, int rij, int aantal)
        {
            if (rij == 1)
            {
                if ((aantal == 3) || (aantal == 5))
                {
                    return false;
                }
                return true;
            }
            if (rij == 2)
            {
                if ((aantal == 3) || aantal==4)
                {
                    return true;
                }
            }
            return ((rnd.Next(1,4) == 1) || rij==basislengte);
        }
    }
}