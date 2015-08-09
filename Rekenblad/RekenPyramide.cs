using System;
using System.Drawing;
using Spire.Pdf;
using Spire.Pdf.ColorSpace;
using Spire.Pdf.Graphics;

namespace Rekenblad
{
    public class RekenPyramide
    {
        internal int[,] pyrArray;

        public PdfDocument CreateRekenPyramide(string filename)
        {

            //Create a pdf document.
            PdfDocument doc = new PdfDocument();

            // Create one page
            PdfPageBase page = doc.Pages.Add();
            int basislengte = 8;
            int maxbasisgetal = 14;


            Random rnd = new Random();
            for (int pyramide = 1; pyramide <= 3; pyramide++)
            {
                GeneratePyramid(basislengte, rnd, maxbasisgetal);

                int papierhoogte = ((int)page.Canvas.Size.Height / 3 - 40) * pyramide;

                TekenHelePyramideOpPapier(page, pyrArray, basislengte, papierhoogte);
            }
            //Save pdf file.
            doc.SaveToFile(filename);
            doc.Close();

            return doc;

        }

        public int[,] GeneratePyramid(int basislengte, Random rnd, int maxbasisgetal)
        {
            pyrArray = new int[basislengte, basislengte];

            // Eerst de basis getallen geven.
            for (int aantal = 0; aantal <= basislengte - 1; aantal++)
            {
                pyrArray[0, aantal] = rnd.Next(0, maxbasisgetal + 1);
            }

            // Rest van pyramide invullen
            for (int rij = 1; rij <= basislengte; rij++)
            {
                for (int aantal = 0; aantal <= basislengte - 1 - rij; aantal++)
                {
                    pyrArray[rij, aantal] = pyrArray[rij - 1, aantal] + pyrArray[rij - 1, aantal + 1];
                }
            }
            return pyrArray;
        }

        private void TekenHelePyramideOpPapier(PdfPageBase page, int[,] pyramide, int basislengte, int papierhoogte)
        {
            PdfSolidBrush blackBrush = new PdfSolidBrush(Color.Black);
            PdfFont helv = new PdfFont(PdfFontFamily.Helvetica, 15f);
            Random rnd = new Random();
            int xOffset = 50;
            // draw the rectangles 
            for (int rij = 0; rij <= basislengte - 1; rij++)
            {
                for (int aantal = 0; aantal <= (basislengte - 1 - rij); aantal++)
                {
                    int x = aantal * 50 + 25 * rij+xOffset;
                    int y = papierhoogte - rij * 25;
                    int rechthook = 50;

                    RectangleF rectangleFLine = new RectangleF(x - 6, y - 6, rechthook + 3, 25);
                    page.Canvas.DrawRectangle(blackBrush, rectangleFLine);

                    RectangleF rectangleF = new RectangleF(x - 4, y - 4, rechthook - 1, 22);
                    PdfLinearGradientBrush gradBrush = new PdfLinearGradientBrush(rectangleF, new PdfRGBColor(200, 200, 200), new PdfRGBColor(200, 200, 200), PdfLinearGradientMode.Horizontal);
                    page.Canvas.DrawRectangle(gradBrush, rectangleF);

                }
            }

            // draw all the numbers on the paper
            for (int rij = 0; rij <= basislengte - 1; rij++)
            {
                for (int aantal = 0; aantal <= (basislengte - rij - 1); aantal++)
                {
                    Console.Write(pyramide[rij, aantal].ToString() + " ");
                    int x = aantal * 50 + 25 * rij + 5 +xOffset;
                    int y = papierhoogte - rij * 25;

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
            if (rij == 0)
            {
                if ((aantal == 2) || (aantal == 4))
                {
                    return false;
                }
                return true;
            }
            if (rij == 1)
            {
                if ((aantal == 2) || aantal == 3)
                {
                    return true;
                }
            }
            return ((rnd.Next(1, 4) == 1) || rij == basislengte - 1);
        }
    }
}