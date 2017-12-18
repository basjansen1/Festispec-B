using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace Festispec.Domain
{
    public class ChartExporter : Form
    {
        public Image Test()
        {
            return Export();
        }

        public Image Export()
        {
            string[] inspectionNames = { "Blalaland2017", "Blalaland2016" };
            string title = "Prullenbaktevredenheid";
            string[] x = { "Bij de wc", "Bij de foodtrucks", "Bij de podia" };
            string[][] y = {
               new string[] {
                    "5","4"
                } , new string[] {
                    "4","3"
                }, new string[] {
                    "4","1"
                }
            };
           return GenerateChart(inspectionNames, title, x, y);
        }

        public Image GenerateChart(string[] inspectionNames, string title, string[] label, string[][] answer)
        {
            Chart chart1 = new Chart();
            chart1.Titles.Add(title);
            for (int inspectionNumber = 0; inspectionNumber < inspectionNames.Length; inspectionNumber++)
            {
                chart1.Series.Add(inspectionNames[inspectionNumber]);
                chart1.Series[inspectionNames[inspectionNumber]].ChartType = SeriesChartType.Column;
                chart1.Series[inspectionNames[inspectionNumber]].BorderWidth = 2;
                    for (int labelNumber = 0; labelNumber < answer.Length; labelNumber++)
                    {
                        chart1.Series[inspectionNames[inspectionNumber]].Points.AddXY(label[labelNumber], answer[labelNumber][inspectionNumber]);
                    }
            }
            chart1.ChartAreas.Add(new ChartArea("Area")
            {
                BackColor = Color.WhiteSmoke,
                Area3DStyle = { Enable3D = false },
            });
            chart1.Enabled = true;
            chart1.DataBind();
            MemoryStream memoryStream = new MemoryStream();
            chart1.SaveImage(memoryStream, ChartImageFormat.Png);
            memoryStream.Seek(0, SeekOrigin.Begin);
            return Image.FromStream(memoryStream);
        }
    }
}