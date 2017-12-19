using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Collections.Generic;

namespace Festispec.Domain
{
    public class ChartExporter : Form
    {

        public Image Test()
        {
            List<string> inspectionNames = new List<string> { "Blalaland2017", "Blalaland2016" };
            string title = "Prullenbaktevredenheid";
            List<string> x = new List<string> { "Bij de wc", "Bij de foodtrucks", "Bij de podia" };
            List<List<string>> y = new List<List<string>>{
               new List<string> {
                    "5","4"
                } , new List<string> {
                    "4","3"
                },new List<string> {
                    "4","1"
                }
            };
            return GenerateChartFromTableQuestion(inspectionNames, title, x, y);
        }

        public Image GenerateChartFromTableQuestion(List<string> series, string title, List<string> x, List<List<string>> y)
        {
            Chart chart1 = new Chart();
            chart1.Titles.Add(title);
            for (int inspectionNumber = 0; inspectionNumber < series.Count; inspectionNumber++)
            {
                chart1.Series.Add(series[inspectionNumber]);
                chart1.Series[series[inspectionNumber]].ChartType = SeriesChartType.Column;
                chart1.Series[series[inspectionNumber]].BorderWidth = 2;
                for (int labelNumber = 0; labelNumber < y.Count; labelNumber++)
                {
                    chart1.Series[series[inspectionNumber]].Points.AddXY(x[labelNumber], y[labelNumber][inspectionNumber]);
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

        public Image GenerateChartFromQuestion(string title, List<string> x, List<List<string>> y)
        {
            Chart chart1 = new Chart();
            chart1.Titles.Add(title);
            for (int inspectionNumber = 0; inspectionNumber < x.Count; inspectionNumber++)
            {
                chart1.Series.Add(x[inspectionNumber]);
                chart1.Series[x[inspectionNumber]].ChartType = SeriesChartType.Column;
                chart1.Series[x[inspectionNumber]].BorderWidth = 2;
                for (int labelNumber = 0; labelNumber < x.Count; labelNumber++)
                {
                    chart1.Series[x[inspectionNumber]].Points.AddXY(x[labelNumber], y[labelNumber][inspectionNumber]);
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