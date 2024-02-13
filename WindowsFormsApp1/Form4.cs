using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        Scool scool = new Scool();
        Grupp grupp = new Grupp();
        public Form4()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" &&  textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox9.Text != "")
            {
                for(int i = 0; i < grupp.len; i++)
                {
                    if(textBox9.Text == grupp[i])
                    {
                        dobavStudInGrup(i);
                        break;
                    }
                }
            }
            else
            {
                if (textBox1.Text == "")
                {
                    textBox1.BackColor = Color.Red;
                }
                if (textBox2.Text == "")
                {
                    textBox2.BackColor = Color.Red;
                }
                if (textBox3.Text == "")
                {
                    textBox3.BackColor = Color.Red;
                }
                if (textBox4.Text == "")
                {
                    textBox4.BackColor = Color.Red;
                }
                if (textBox9.Text == "")
                {
                    textBox9.BackColor = Color.Red;
                }
            }
        }

        void dobavStudInGrup(int i)
        {
            scool.dobavStud(new Student(textBox1.Text, textBox2.Text, Convert.ToInt16(textBox3.Text), textBox4.Text, textBox9.Text, grupp.predGrup(i)));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox10.Text != "")
            {
                dobavPrep();         
            }
            else
            {
                if (textBox1.Text == "")
                {
                    textBox1.BackColor = Color.Red;
                }
                if (textBox2.Text == "")
                {
                    textBox2.BackColor = Color.Red;
                }
                if (textBox3.Text == "")
                {
                    textBox3.BackColor = Color.Red;
                }
                if (textBox4.Text == "")
                {
                    textBox4.BackColor = Color.Red;
                }
                if (textBox9.Text == "")
                {
                    textBox9.BackColor = Color.Red;
                }
            }
        }

        void dobavPrep()
        {
            if(grupp.poiskPREDM(textBox10.Text))
            {
                scool.dobavPrep(new Prepodavatel(textBox8.Text, textBox5.Text, Convert.ToInt32(textBox6.Text), Convert.ToInt32(textBox7.Text), grupp.retPREDM(textBox10.Text), textBox10.Text ));
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
