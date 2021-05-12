using Microsoft.Msagl.Drawing;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly MyTree<int> tree;

        public Form1()
        {
            InitializeComponent();
            tree = new MyTree<int>();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                int value = Convert.ToInt32(textBox1.Text);
                tree.Add(value);
            }
            catch { }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            textBox4.Text = tree.CLR();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            textBox4.Text = tree.LCR();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            textBox4.Text = tree.RCL();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                int value = Convert.ToInt32(textBox2.Text);
                TreeNode<int> node = tree.Find(value);
                if (node == null)
                {
                    label2.Text = "Не найдено!";
                }
                else
                {
                    label2.Text = "Найдено!";
                }
            }
            catch { }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            bool first = true;
            string text = string.Empty;
            foreach (int item in tree)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    text += " ";
                }
                text += item.ToString();
            }
            textBox4.Text = text;
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            textBox4.Text = tree.Across();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            Graph graph = tree.Show();
            using (ViewForm form = new ViewForm(graph))
            {
                form.ShowDialog();
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                int value = Convert.ToInt32(textBox3.Text);
                tree.Delete(value);
            }
            catch { }
        }
    }
}
