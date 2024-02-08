using System;
using System.Collections.Generic;
using Microcharts;
using SkiaSharp;
using Xamarin.Forms;
using Entry = Microcharts.ChartEntry;

namespace ShopAdminApp
{
    public partial class DashboardPage : ContentPage
    {
        List<Entry> entries = new List<Entry>
        {
            new Entry(212)
                 {
                     Label = "UWP",
                     ValueLabel = "212",
                     Color = SKColor.Parse("#2c3e50")
                 },
                 new Entry(248)
                 {
                     Label = "Android",
                     ValueLabel = "248",
                     Color = SKColor.Parse("#77d065")
                 },
                 new Entry(128)
                 {
                     Label = "iOS",
                     ValueLabel = "128",
                     Color = SKColor.Parse("#b455b6")
                 },
                 new Entry(514)
                 {
                     Label = "Shared",
                     ValueLabel = "514",
                     Color = SKColor.Parse("#3498db")
            }
        };

        public DashboardPage()
        {
            InitializeComponent();

            var donutChart = new DonutChart() { Entries = entries };
            this.donutChartView.Chart = donutChart;

            var lineChart = new LineChart() { Entries = entries };
            this.lineChartView.Chart = lineChart;

            var barChart = new BarChart() { Entries = entries };
            this.barChartView.Chart = barChart;
        }
    }
}

