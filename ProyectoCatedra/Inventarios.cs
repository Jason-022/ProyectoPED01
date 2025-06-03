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

namespace ProyectoCatedra
{
    public partial class Inventarios : Form
    {

        private HistorialCortesDAL historialCortesDAL = new HistorialCortesDAL();
        public Inventarios()
        {
            InitializeComponent();
            CreateCharts();
            LoadSummaryCharts();
        }



        private Chart chartPersonnelByRole;
        private Chart chartTotalAppointments;
        private Chart chartTotalPrice;

        private void CreateCharts()
        {
            // Set form properties for better layout
            this.Size = new Size(1200, 600);
            this.Text = "Resumen de Datos";

            // Chart 1: Personnel by Role (Bar Chart)
            chartPersonnelByRole = new Chart
            {
                Size = new Size(380, 400),
                Location = new Point(10, 10),
                BackColor = Color.White
            };
            ChartArea chartArea1 = new ChartArea { Name = "ChartArea1" };
            chartArea1.AxisX.Title = "Rol";
            chartArea1.AxisY.Title = "Cantidad";
            chartPersonnelByRole.ChartAreas.Add(chartArea1);
            Series series1 = new Series
            {
                Name = "Personnel",
                ChartType = SeriesChartType.Column
            };
            chartPersonnelByRole.Series.Add(series1);
            Title title1 = new Title
            {
                Text = "Personal por Rol",
                Font = new Font("Arial", 12, FontStyle.Bold)
            };
            chartPersonnelByRole.Titles.Add(title1);
            this.Controls.Add(chartPersonnelByRole);

            // Chart 2: Total Appointments (Pie Chart)
            chartTotalAppointments = new Chart
            {
                Size = new Size(380, 400),
                Location = new Point(410, 10),
                BackColor = Color.White
            };
            ChartArea chartArea2 = new ChartArea { Name = "ChartArea2" };
            chartTotalAppointments.ChartAreas.Add(chartArea2);
            Series series2 = new Series
            {
                Name = "Appointments",
                ChartType = SeriesChartType.Pie
            };
            chartTotalAppointments.Series.Add(series2);
            Title title2 = new Title
            {
                Text = "Total de Citas",
                Font = new Font("Arial", 12, FontStyle.Bold)
            };
            chartTotalAppointments.Titles.Add(title2);
            this.Controls.Add(chartTotalAppointments);

            // Chart 3: Total Price of Cuts (Column Chart)
            chartTotalPrice = new Chart
            {
                Size = new Size(380, 400),
                Location = new Point(810, 10),
                BackColor = Color.White
            };
            ChartArea chartArea3 = new ChartArea { Name = "ChartArea3" };
            chartArea3.AxisX.Title = "Categoría";
            chartArea3.AxisY.Title = "Precio (MXN)";
            chartTotalPrice.ChartAreas.Add(chartArea3);
            Series series3 = new Series
            {
                Name = "Price",
                ChartType = SeriesChartType.Column
            };
            chartTotalPrice.Series.Add(series3);
            Title title3 = new Title
            {
                Text = "Precio Total de Cortes",
                Font = new Font("Arial", 12, FontStyle.Bold)
            };
            chartTotalPrice.Titles.Add(title3);
            this.Controls.Add(chartTotalPrice);
        }

        private void LoadSummaryCharts()
        {
            try
            {
                // Chart 1: Personnel by Role (Bar Chart)
                DataTable personnelByRole = historialCortesDAL.GetPersonnelByRole();
                chartPersonnelByRole.Series["Personnel"].Points.Clear();
                foreach (DataRow row in personnelByRole.Rows)
                {
                    string role = row["Tipo_rol"].ToString();
                    int count = Convert.ToInt32(row["TotalPersonnel"]);
                    chartPersonnelByRole.Series["Personnel"].Points.AddXY(role, count);
                }
                chartPersonnelByRole.Series["Personnel"].Color = Color.Green;

                // Chart 2: Total Appointments (Pie Chart for context)
                int totalAppointments = historialCortesDAL.GetTotalAppointments();
                int placeholderAppointments = totalAppointments > 0 ? 1000 - totalAppointments : 1; // Placeholder for context
                if (totalAppointments == 0) totalAppointments = 1; // Avoid zero for pie chart
                chartTotalAppointments.Series["Appointments"].Points.Clear();
                chartTotalAppointments.Series["Appointments"].Points.AddXY("Citas Totales", totalAppointments);
                chartTotalAppointments.Series["Appointments"].Points.AddXY("Espacio Restante", placeholderAppointments);
                chartTotalAppointments.Series["Appointments"].Points[0].Color = Color.Blue;
                chartTotalAppointments.Series["Appointments"].Points[1].Color = Color.LightGray;
                chartTotalAppointments.Titles[0].Text = $"Total de Citas: {totalAppointments}";

                // Chart 3: Total Price of Cuts (Bar Chart for context)
                decimal totalPrice = historialCortesDAL.GetTotalPriceOfCuts();
                decimal placeholderPrice = totalPrice > 0 ? 10000 - totalPrice : 1; // Placeholder for context
                if (totalPrice == 0) totalPrice = 1; // Avoid zero
                chartTotalPrice.Series["Price"].Points.Clear();
                chartTotalPrice.Series["Price"].Points.AddXY("Total Precio", totalPrice);
                chartTotalPrice.Series["Price"].Points.AddXY("Espacio Restante", placeholderPrice);
                chartTotalPrice.Series["Price"].Points[0].Color = Color.Orange;
                chartTotalPrice.Series["Price"].Points[1].Color = Color.LightGray;
                chartTotalPrice.Titles[0].Text = $"Precio Total de Cortes: {totalPrice:C2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading summary charts: " + ex.Message);
            }
        }





        private void btnBack_Click(object sender, EventArgs e)
        {
            Administracion rAdmin = new Administracion();
            rAdmin.Show();
            this.Hide();
        }
    }
}
