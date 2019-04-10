using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace _04042019
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            listBox1.Items.Clear();
            DriveInfo[] u = DriveInfo.GetDrives();
            foreach (DriveInfo unidad in u)

            
            try
            {
                listBox1.Items.Add(unidad.Name);

            }
            catch (Exception ex)
            {

                MessageBox.Show("ERROR DE LECTURA" + ex.Message);

            }
                 



        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            listBox2.Items.Clear();
            String unidades = listBox1.SelectedItem.ToString();
            DriveInfo d = new DriveInfo(unidades);
            listBox2.Items.Add("Disco"+ d.Name + "\n");
            if (d.IsReady)
            {
                listBox2.Items.Add("Espacio ocupado (GB): " + (d.TotalSize - d.AvailableFreeSpace) / 1024 / 1024 / 1024 + "\n");
                listBox2.Items.Add("Espacio disponible (GB): " + (d.TotalFreeSpace) / 1024 / 1024 / 1024 + "\n");
                listBox2.Items.Add("Espacio Total (GB): " + (d.TotalSize) / 1024 / 1024 / 1024 + "\n");
                
            }

            listBox2.Items.Add("Tipo de disco duro utilizado: " + d.DriveType.ToString() + "\n");

            treeView1.Nodes.Clear();
            if (d.IsReady)
            {
                DirectoryInfo dir = new DirectoryInfo(unidades);

                foreach (DirectoryInfo sub in dir.GetDirectories())
                {

                    treeView1.Nodes.Add(sub.Name);

                }

                foreach (FileInfo file in dir.GetFiles())
                {

                    TreeNode nodo = new TreeNode();
                    nodo.Text = file.Name;
                    nodo.ForeColor = Color.Blue;
                    treeView1.Nodes.Add(nodo);
                }

            }








        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String Dir = "C:/test";
            String arch = "C:/Prueba.txt";

            if(!Directory.Exists(Dir))
            {
                Directory.CreateDirectory(Dir);


            }
            else
            {
                MessageBox.Show("Existe el Directorio");

            }

            if (!File.Exists(arch))
            {
                File.Create(arch);


            }

            else
            {
                MessageBox.Show("Existe el Archivo");

            }
        }
    }
}
