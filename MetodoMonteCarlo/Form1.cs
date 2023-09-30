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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace MetodoMonteCarlo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int xClick = 0, yClick = 0;
        public int cant_num = 0;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiar();
            generar_puntos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            limpiar();
            numericUpDown1.Value = 100;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void generar_puntos()
        {
            cant_num = (int)numericUpDown1.Value;
            double x1, x2, y1, y2;
            string[] fila;
            double contador = 0;
            Random rand = new Random();
            for (int i = 0; i < cant_num; i++)
            {
                x1 = (rand.NextDouble()*2)-1;
                y1 = (rand.NextDouble()*2)-1;

                if (((x1*x1)+(y1*y1))<=1)
                {
                    x2 = x1;
                    y2 = y1;
                    contador++;
                }
                else
                {
                    x2 = 0;
                    y2 = 0;
                }
                fila = new string[5] { (i+1).ToString(), x1.ToString(), y1.ToString(), x2.ToString(), y2.ToString() };
                dataGridView1.Rows.Add(fila);
                chart1.Series[0].Points.AddXY(x1, y1);
                chart1.Series[1].Points.AddXY(x2, y2);
            }
            textBox1.Text = contador.ToString();
            textBox2.Text = ((contador/cant_num)*4).ToString();
        }
        private void limpiar()
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            dataGridView1.Rows.Clear();
        }
    }
}
