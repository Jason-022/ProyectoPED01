using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        private Chart chartPersonnelByRole;
        private Chart chartTotalPriceCompleted;
        private Chart chartTipoReservacionCounts;
        private TreeView treeViewPersonnelByRole;
        private TreeView treeViewTotalPriceCompleted;
        private TreeView treeViewTipoReservacionCounts;
        private Button btnShowAVL;

        public Inventarios()
        {
            InitializeComponent();
            CreateChartsAndAVLs();
            LoadSummaryCharts();
        }

        private void CreateChartsAndAVLs()
        {
            this.Size = new Size(1200, 800); // Adjusted height to fit charts and AVL trees
            this.Text = "Resumen de Datos";

            // Chart 1: Personnel by Role (Bar Chart)
            chartPersonnelByRole = new Chart
            {
                Size = new Size(380, 300),
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

            // AVL Tree for Personnel by Role
            treeViewPersonnelByRole = new TreeView
            {
                Size = new Size(380, 150),
                Location = new Point(10, 320), // Below Chart 1
                BackColor = Color.White
            };
            this.Controls.Add(treeViewPersonnelByRole);

            // Chart 2: Total Price of Completed Cuts (Bar Chart)
            chartTotalPriceCompleted = new Chart
            {
                Size = new Size(380, 300),
                Location = new Point(410, 10), // Side by side with Chart 1
                BackColor = Color.White
            };
            ChartArea chartArea2 = new ChartArea { Name = "ChartArea2" };
            chartArea2.AxisX.Title = "Estado";
            chartArea2.AxisY.Title = "Precio Total (MXN)";
            chartTotalPriceCompleted.ChartAreas.Add(chartArea2);
            Series series2 = new Series
            {
                Name = "Price",
                ChartType = SeriesChartType.Column
            };
            chartTotalPriceCompleted.Series.Add(series2);
            Title title2 = new Title
            {
                Text = "Precio Total de Cortes Completados",
                Font = new Font("Arial", 12, FontStyle.Bold)
            };
            chartTotalPriceCompleted.Titles.Add(title2);
            this.Controls.Add(chartTotalPriceCompleted);

            // AVL Tree for Total Price of Completed Cuts
            treeViewTotalPriceCompleted = new TreeView
            {
                Size = new Size(380, 150),
                Location = new Point(410, 320), // Below Chart 2
                BackColor = Color.White
            };
            this.Controls.Add(treeViewTotalPriceCompleted);

            // Chart 3: Tipo Reservacion Counts (Pie Chart)
            chartTipoReservacionCounts = new Chart
            {
                Size = new Size(380, 300),
                Location = new Point(810, 10), // Side by side with Chart 2
                BackColor = Color.White
            };
            ChartArea chartArea3 = new ChartArea { Name = "ChartArea3" };
            chartTipoReservacionCounts.ChartAreas.Add(chartArea3);
            Series series3 = new Series
            {
                Name = "Reservations",
                ChartType = SeriesChartType.Pie
            };
            chartTipoReservacionCounts.Series.Add(series3);
            Title title3 = new Title
            {
                Text = "Distribución de Tipos de Reservación",
                Font = new Font("Arial", 12, FontStyle.Bold)
            };
            chartTipoReservacionCounts.Titles.Add(title3);
            this.Controls.Add(chartTipoReservacionCounts);

            // AVL Tree for Tipo Reservacion Counts
            treeViewTipoReservacionCounts = new TreeView
            {
                Size = new Size(380, 150),
                Location = new Point(810, 320), // Below Chart 3
                BackColor = Color.White
            };
            this.Controls.Add(treeViewTipoReservacionCounts);

            // Button to Show AVL Data
            btnShowAVL = new Button
            {
                Text = "Mostrar Datos en Árboles AVL",
                Size = new Size(200, 40),
                Location = new Point(10, 480), // Positioned below all charts
                BackColor = Color.LightBlue
            };
            btnShowAVL.Click += BtnShowAVL_Click;
            this.Controls.Add(btnShowAVL);
        }

        private void LoadSummaryCharts()
        {
            try
            {
                // Chart 1: Personnel by Role (Administrador, Barbero, Limpieza)
                DataTable personnelByRole = historialCortesDAL.GetPersonnelByRole();
                chartPersonnelByRole.Series["Personnel"].Points.Clear();
                foreach (DataRow row in personnelByRole.Rows)
                {
                    string role = row["Tipo_rol"].ToString();
                    int count = Convert.ToInt32(row["TotalPersonnel"]);
                    chartPersonnelByRole.Series["Personnel"].Points.AddXY(role, count);
                }
                chartPersonnelByRole.Series["Personnel"].Color = Color.Green;

                // Chart 2: Total Price of Completed Cuts
                decimal totalPriceCompleted = historialCortesDAL.GetTotalPriceOfCompletedCuts();
                decimal placeholderPrice = totalPriceCompleted > 0 ? 10000 - totalPriceCompleted : 1;
                if (totalPriceCompleted == 0) totalPriceCompleted = 0;
                chartTotalPriceCompleted.Series["Price"].Points.Clear();
                chartTotalPriceCompleted.Series["Price"].Points.AddXY("Completado", totalPriceCompleted);
                chartTotalPriceCompleted.Series["Price"].Points.AddXY("Espacio Restante", placeholderPrice);
                chartTotalPriceCompleted.Series["Price"].Points[0].Color = Color.Blue;
                chartTotalPriceCompleted.Series["Price"].Points[1].Color = Color.LightGray;
                chartTotalPriceCompleted.Titles[0].Text = $"Precio Total de Cortes Completados: {totalPriceCompleted:C2}";

                // Chart 3: Tipo Reservacion Counts (Sin Cita, Con Cita)
                DataTable tipoReservacionCounts = historialCortesDAL.GetTipoReservacionCounts();
                chartTipoReservacionCounts.Series["Reservations"].Points.Clear();
                foreach (DataRow row in tipoReservacionCounts.Rows)
                {
                    string tipo = row["Tipo_reservacion"].ToString();
                    int count = Convert.ToInt32(row["Total"]);
                    chartTipoReservacionCounts.Series["Reservations"].Points.AddXY(tipo, count);
                }
                chartTipoReservacionCounts.Series["Reservations"].Points[0].Color = Color.Orange;
                if (chartTipoReservacionCounts.Series["Reservations"].Points.Count > 1)
                    chartTipoReservacionCounts.Series["Reservations"].Points[1].Color = Color.Purple;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading summary charts: " + ex.Message);
            }
        }

        private class AVLNode
        {
            public int Value { get; set; }
            public string Label { get; set; }
            public AVLNode Left { get; set; }
            public AVLNode Right { get; set; }
            public int Height { get; set; }

            public AVLNode(int value, string label)
            {
                Value = value;
                Label = label;
                Height = 1;
            }
        }

        private class AVLTree
        {
            private AVLNode root;

            private int Height(AVLNode node) => node == null ? 0 : node.Height;

            private int BalanceFactor(AVLNode node) => node == null ? 0 : Height(node.Left) - Height(node.Right);

            private void UpdateHeight(AVLNode node)
            {
                if (node != null)
                    node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));
            }

            private AVLNode RotateRight(AVLNode y)
            {
                AVLNode x = y.Left;
                AVLNode T2 = x.Right;
                x.Right = y;
                y.Left = T2;
                UpdateHeight(y);
                UpdateHeight(x);
                return x;
            }

            private AVLNode RotateLeft(AVLNode x)
            {
                AVLNode y = x.Right;
                AVLNode T2 = y.Left;
                y.Left = x;
                x.Right = T2;
                UpdateHeight(x);
                UpdateHeight(y);
                return y;
            }

            private AVLNode Insert(AVLNode node, int value, string label)
            {
                if (node == null)
                    return new AVLNode(value, label);

                if (value < node.Value)
                    node.Left = Insert(node.Left, value, label);
                else if (value > node.Value)
                    node.Right = Insert(node.Right, value, label);
                else
                    return node; // Duplicate values not allowed

                UpdateHeight(node);

                int balance = BalanceFactor(node);

                // Left Left
                if (balance > 1 && value < node.Left.Value)
                    return RotateRight(node);

                // Right Right
                if (balance < -1 && value > node.Right.Value)
                    return RotateLeft(node);

                // Left Right
                if (balance > 1 && value > node.Left.Value)
                {
                    node.Left = RotateLeft(node.Left);
                    return RotateRight(node);
                }

                // Right Left
                if (balance < -1 && value < node.Right.Value)
                {
                    node.Right = RotateRight(node.Right);
                    return RotateLeft(node);
                }

                return node;
            }

            public void Insert(int value, string label)
            {
                root = Insert(root, value, label);
            }

            public void PopulateTreeView(TreeView treeView)
            {
                treeView.Nodes.Clear();
                if (root != null)
                    PopulateTreeViewRecursive(treeView.Nodes, root);
            }

            private void PopulateTreeViewRecursive(TreeNodeCollection nodes, AVLNode node)
            {
                if (node != null)
                {
                    TreeNode treeNode = new TreeNode($"{node.Label}: {node.Value}");
                    nodes.Add(treeNode);
                    PopulateTreeViewRecursive(treeNode.Nodes, node.Left);
                    PopulateTreeViewRecursive(treeNode.Nodes, node.Right);
                }
            }
        }

        private void BtnShowAVL_Click(object sender, EventArgs e)
        {
            try
            {
                // AVL Tree for Personnel by Role
                AVLTree avlPersonnel = new AVLTree();
                DataTable personnelByRole = historialCortesDAL.GetPersonnelByRole();
                foreach (DataRow row in personnelByRole.Rows)
                {
                    string role = row["Tipo_rol"].ToString();
                    int count = Convert.ToInt32(row["TotalPersonnel"]);
                    avlPersonnel.Insert(count, $"Personal - {role}");
                }
                avlPersonnel.PopulateTreeView(treeViewPersonnelByRole);
                treeViewPersonnelByRole.ExpandAll();

                // AVL Tree for Total Price of Completed Cuts
                AVLTree avlPrice = new AVLTree();
                decimal totalPriceCompleted = historialCortesDAL.GetTotalPriceOfCompletedCuts();
                avlPrice.Insert((int)totalPriceCompleted, "Historial Cortes - Completado");
                avlPrice.PopulateTreeView(treeViewTotalPriceCompleted);
                treeViewTotalPriceCompleted.ExpandAll();

                // AVL Tree for Tipo Reservacion Counts
                AVLTree avlTipoReservacion = new AVLTree();
                DataTable tipoReservacionCounts = historialCortesDAL.GetTipoReservacionCounts();
                foreach (DataRow row in tipoReservacionCounts.Rows)
                {
                    string tipo = row["Tipo_reservacion"].ToString();
                    int count = Convert.ToInt32(row["Total"]);
                    avlTipoReservacion.Insert(count, $"Historial Cortes - {tipo}");
                }
                avlTipoReservacion.PopulateTreeView(treeViewTipoReservacionCounts);
                treeViewTipoReservacionCounts.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error displaying AVL trees: " + ex.Message);
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

