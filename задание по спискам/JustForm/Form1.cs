using System;
using System.Windows.Forms;

namespace JustForm
{
    public partial class Form1 : Form
    {
        MyList<int> lst;

        public Form1()
        {
            InitializeComponent();
            lst = new MyList<int>();
        }

        //вывод в listbox
        private void rewrite()
        {
            listBox1.Items.Clear();
            int[] arr = lst.ToArray();
            for(int i = 0; i < arr.Length; i++)
            {
                listBox1.Items.Add(arr[i].ToString());
            }
        }

        //выход из приложения
        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //добавление в начало
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int k = int.Parse(textBox1.Text);
                lst.Prepend(k);
                rewrite();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //добавление в конец
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int k = int.Parse(textBox1.Text);
                lst.Append(k);
                rewrite();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //сортировка списка
        private void button7_Click(object sender, EventArgs e)
        {
            lst.Sort();
            rewrite();
        }

        //удаление элемента по значению
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int k = int.Parse(textBox1.Text);
                lst.Remove(k);
                rewrite();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //поиск элемента в списке
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                int k = int.Parse(textBox1.Text);
                if (lst.Find(k).Equals(default(int)) == false)
                {
                    MessageBox.Show("В списке есть указанный элемент");
                }
                else
                {
                    MessageBox.Show("Указанного элемента в списке нет");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //удаление элемента по индексу
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(textBox1.Text);
                lst.RemoveAt(id);
                rewrite();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
