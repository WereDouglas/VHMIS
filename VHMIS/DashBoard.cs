using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace VHMIS
{
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
            Bar(); //Show bar chart
            SplineChart();

            Pie();
        }
        public void Pie()
        {
            this.chart3.Series.Clear();
            Series series = this.chart3.Series.Add("Activity Payments and Expenses");
            series.ChartType = SeriesChartType.Pie;

            try
            {
                    series.Points.AddXY("Purchases:" , 10);
            }
            catch (Exception c) { MessageBox.Show("Payment:" + c.Message.ToString()); }
            try
            {
               

                series.Points.AddXY("Expenses:" , 20);
            }
            catch (Exception c) { MessageBox.Show("Expense:" + c.Message.ToString()); }
            try
            {
              
                series.Points.AddXY("Sale:" , 60);
            }
            catch (Exception c) { MessageBox.Show("Sale:" + c.Message.ToString()); }
        }
        public void Bar()
        {
            this.chart1.Series.Clear();
            DateTime today = DateTime.Today;
            int currentDayOfWeek = (int)today.DayOfWeek;
            DateTime sunday = today.AddDays(-currentDayOfWeek);
            DateTime monday = sunday.AddDays(1);
            // If we started on Sunday, we should actually have gone *back*
            // 6 days instead of forward 1...
            if (currentDayOfWeek == 0)
            {
                monday = monday.AddDays(-7);
                Console.WriteLine(monday.ToString("dd-MM-yyyy"));

            }
            var dates = Enumerable.Range(0, 7).Select(days => monday.AddDays(days)).ToList();


            Series series = this.chart1.Series.Add("Purchases this week");
            series.ChartType = SeriesChartType.Spline;
            series.Points.AddXY("Mon",23);
            series.Points.AddXY("Tue",67);
            series.Points.AddXY("Wed", 33);
            series.Points.AddXY("Thur",67);
            series.Points.AddXY("Fri",90);
            series.Points.AddXY("Sat", 45);
            series.Points.AddXY("Sun", 78);

        }
        private void SplineChart()
        {
            this.chart2.Series.Clear();

            this.chart2.Titles.Add("Sales this week");

            DateTime today = DateTime.Today;
            int currentDayOfWeek = (int)today.DayOfWeek;
            DateTime sunday = today.AddDays(-currentDayOfWeek);
            DateTime monday = sunday.AddDays(1);
            // If we started on Sunday, we should actually have gone *back*
            // 6 days instead of forward 1...
            if (currentDayOfWeek == 0)
            {
                monday = monday.AddDays(-7);
                Console.WriteLine(monday.ToString("dd-MM-yyyy"));

            }
            var dates = Enumerable.Range(0, 7).Select(days => monday.AddDays(days)).ToList();


            Series series = this.chart2.Series.Add("Total Sales this week");
            series.ChartType = SeriesChartType.Bar;
            series.Points.AddXY("Mon", 1200);
            series.Points.AddXY("Tue", 10000);
            series.Points.AddXY("Wed", 3000);
            series.Points.AddXY("Thur", 4000);
            series.Points.AddXY("Fri", 500);
            series.Points.AddXY("Sat", 4900);
            series.Points.AddXY("Sun", 3400);
        }
        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
