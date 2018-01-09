using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Collections.Generic;

namespace Festispec.Domain
{
    public class ChartExporter : Form
    {

        public Image GenerateChartFromTableQuestion(List<string> group, string title, List<string> x, List<List<int>> y)
        {
            Chart chart1 = new Chart();
            chart1.Titles.Add(title);
            chart1.ChartAreas.Add(new ChartArea("Area")
            {
                BackColor = Color.WhiteSmoke,
                Area3DStyle = { Enable3D = false },
            });
            for (int groupNumber = 0; groupNumber < group.Count; groupNumber++)
            {
                chart1.Series.Add(group[groupNumber]);
                chart1.Series[group[groupNumber]].ChartType = SeriesChartType.Column;
                chart1.Series[group[groupNumber]].BorderWidth = 1;
                chart1.Legends.Add(new Legend(group[groupNumber]));
                chart1.Legends[group[groupNumber]].DockedToChartArea = "Area";
                chart1.Legends[group[groupNumber]].IsDockedInsideChartArea = false;
                chart1.Legends[group[groupNumber]].LegendStyle = LegendStyle.Column;
                chart1.Legends[group[groupNumber]].Docking = Docking.Right;
                chart1.Series[group[groupNumber]].Legend = group[groupNumber];
                chart1.Series[group[groupNumber]].IsVisibleInLegend = true;
                for (int yxNumber = 0; yxNumber < x.Count; yxNumber++)
                {
                    for (int yNumber = 0; yNumber < y[yxNumber].Count; yNumber++)
                    {
                        chart1.Series[group[groupNumber]].Points.AddXY(x[yxNumber], y[yxNumber][yNumber]);
                    }
                }

            }
            chart1.Size = new Size(300, 700);
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
            chart1.ChartAreas.Add(new ChartArea("Area")
            {
                BackColor = Color.WhiteSmoke,
                Area3DStyle = { Enable3D = false },
            });
            for (int inspectionNumber = 0; inspectionNumber < x.Count; inspectionNumber++)
            {
                chart1.Series.Add(x[inspectionNumber]);
                chart1.Series[x[inspectionNumber]].ChartType = SeriesChartType.Column;
                chart1.Series[x[inspectionNumber]].BorderWidth = 1;
                chart1.Series[x[inspectionNumber]].BorderColor = Color.White;
                chart1.Legends.Add(new Legend(x[inspectionNumber]));
                chart1.Legends[x[inspectionNumber]].DockedToChartArea = "Area";
                chart1.Legends[x[inspectionNumber]].IsDockedInsideChartArea = false;
                chart1.Legends[x[inspectionNumber]].Docking = Docking.Right;
                chart1.Legends[x[inspectionNumber]].LegendStyle = LegendStyle.Column;
                chart1.Series[x[inspectionNumber]].Legend = x[inspectionNumber];
                chart1.Series[x[inspectionNumber]].IsVisibleInLegend = true;
                for (int dataNumber = 0; dataNumber < y[inspectionNumber].Count; dataNumber++)
                {
                    chart1.Series[x[inspectionNumber]].Points.AddXY(1, y[inspectionNumber][dataNumber]);
                }
            }
            chart1.Size = new Size(300, 700);
            chart1.Enabled = true;
            chart1.DataBind();
            MemoryStream memoryStream = new MemoryStream();
            chart1.SaveImage(memoryStream, ChartImageFormat.Png);
            memoryStream.Seek(0, SeekOrigin.Begin);
            return Image.FromStream(memoryStream);
        }

    }
}