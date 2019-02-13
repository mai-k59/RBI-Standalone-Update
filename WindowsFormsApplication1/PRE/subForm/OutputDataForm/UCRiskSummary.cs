using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RBI.BUS.BUSMSSQL;
namespace RBI.PRE.subForm.OutputDataForm
{
    public partial class UCRiskSummary : UserControl
    {
        public UCRiskSummary()
        {
            InitializeComponent();
            //DrawRiskMatrix();
        }
        public UCRiskSummary(int ID)
        {
            InitializeComponent();
            DrawRiskMatrix(ID);
        }
        Graphics g;
        private void DrawRiskMatrix(int ID)
        {
            RW_FULL_POF_BUS busPoF = new RW_FULL_POF_BUS();
            float[] DF = busPoF.getDF(ID);
            RW_FULL_FCOF_BUS busCoF = new RW_FULL_FCOF_BUS();
            float CoF = busCoF.getFCoFValue(ID);
            int width = picRiskSummary.Width - 16;
            int height = picRiskSummary.Height - 16;
            int x = width / 5;
            int y = height / 5;
            picRiskSummary.Image = new Bitmap(width, height);
            g = Graphics.FromImage(this.picRiskSummary.Image);
            //tô màu
            SolidBrush red = new SolidBrush(Color.Red);
            Rectangle recRed1 = new Rectangle(x * 3 + 2, 8, x * 2 - 4, y);
            Rectangle recRed2 = new Rectangle(x * 4, y, x - 2, y * 2 + 2);
            g.FillRectangle(red, recRed1);
            g.FillRectangle(red, recRed2);
            SolidBrush orange = new SolidBrush(Color.Orange);
            Rectangle recOrange1 = new Rectangle(8, 8, x * 3 - 6, y - 2);
            Rectangle recOrange2 = new Rectangle(x * 2 + 2, y + 6, x * 2 - 2, y - 2);
            Rectangle recOrange3 = new Rectangle(x * 3, y * 2, x, y + 2);
            Rectangle recOrange4 = new Rectangle(x * 4, y * 3 + 2, x - 2, y * 2 - 4);
            g.FillRectangle(orange, recOrange1);
            g.FillRectangle(orange, recOrange2);
            g.FillRectangle(orange, recOrange3);
            g.FillRectangle(orange, recOrange4);
            SolidBrush green = new SolidBrush(Color.Green);
            Rectangle recGreen = new Rectangle(8, y * 2 + 5, x * 2 - 5, y * 3 - 8);
            g.FillRectangle(green, recGreen);
            SolidBrush yellow = new SolidBrush(Color.Yellow);
            Rectangle recYellow1 = new Rectangle(8, y + 6, x * 2 - 4, y - 2);
            Rectangle recYellow2 = new Rectangle(x * 2 + 4, y * 2 + 4, x - 2, y * 3 - 6);
            Rectangle recYellow3 = new Rectangle(x * 3, y * 3 + 2, x, y * 2 - 4);
            g.FillRectangle(yellow, recYellow1);
            g.FillRectangle(yellow, recYellow2);
            g.FillRectangle(yellow, recYellow3);
            Pen gridPen = new Pen(Color.Black, 2);
            //vẽ cột đứng
            for (int i = 8; i < width; i += x - 2)
            {
                g.DrawLine(gridPen, i, 8, i, height - 2);
            }
            //vẽ dòng ngang
            for (int i = 8; i < height; i += y - 2)
            {
                g.DrawLine(gridPen, 8, i, width - 2, i);
            }
            float[] coordinatesPoF = { 0, 0, 0 };
            float coordinatesCoF = 0;
            //float[] DF = { 1, 500, 5000 };
            for (int i = 0; i < 3; i++)
            {
                if (DF[i] <= 2)
                {
                    coordinatesPoF[i] = 4 * y + (y - DF[i] * y / 2) - 8;
                }
                else if (DF[i] <= 20)
                {
                    coordinatesPoF[i] = 3 * y + (y - y * DF[i] / 20) - 8;
                }
                else if (DF[i] <= 100)
                {
                    coordinatesPoF[i] = 2 * y + (y - y * DF[i] / 100) - 8;
                }
                else if (DF[i] <= 1000)
                {
                    coordinatesPoF[i] = y + (y - y * DF[i] / 1000) - 8;
                }
                else
                {
                    int df = (int)DF[i];
                    string a = df.ToString();
                    coordinatesPoF[i] = y - y * DF[i] / (float)Math.Pow(10,a.Length);
                }
            }
            if (CoF <= 10000)
            {
                coordinatesCoF = x * CoF / 10000;
            }
            else if (CoF <= 100000)
            {
                float FC = CoF / 10;
                coordinatesCoF = x + FC * x / 10000;
            }
            else if (CoF <= 1000000)
            {
                float FC = CoF / 100;
                coordinatesCoF = 2 * x + FC * x / 10000;
            }
            else if (CoF <= 10000000)
            {
                float FC = CoF / 1000;
                coordinatesCoF = 3 * x + FC * x / 10000;
            }
            else
            {
                float FC = CoF / 10000;
                coordinatesCoF = 4 * x + FC * x / 10000 - 16;
            }
            
            Image[] image = { Resource1.Triangle_icon, Resource1.Square_icon, Resource1.Circle_icon };
            for (int i = 0; i < 3; i++)
            {
                g.DrawImage(image[i], coordinatesCoF, coordinatesPoF[i]);
            }
        }
    }
}
