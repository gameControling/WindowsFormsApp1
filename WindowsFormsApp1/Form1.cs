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


    public partial class Form1 : Form
    {
        static Grupp grupp;
        Random rend = new Random();
        string[] admin = { "admin", "admin" };
        string[] teacher = { "teac", "teac1", "333", "222" };
        string[] student = { "123", "222", "444", "444" };
        Student stud = new Student("Олег", "Петров", 20, grupp[0], "11101010", grupp.predGrup(0));
        bool login = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < admin.Length && !login; i += 2)
            {
                if (admin[i] == textBox1.Text)
                {
                    if (admin[i + 1] == textBox2.Text)
                    {
                        Visible = false;
                        label1.Text = "";
                        login = true;
                        Form4 form4 = new Form4();
                        form4.ShowDialog();
                        Visible = true;
                        break;
                    }
                }
            }
            for (int i = 0; i < teacher.Length && !login; i += 2)
            {
                if (teacher[i] == textBox1.Text)
                {
                    if (teacher[i + 1] == textBox2.Text)
                    {
                        Visible = false;
                        label1.Text = "";
                        login = true;
                        Form3 form3 = new Form3();
                        form3.ShowDialog();
                        Visible = true;
                        break;
                    }
                }
            }
            for (int i = 0; i < student.Length && !login; i += 2)
            {
                if (student[i] == textBox1.Text)
                {
                    if (student[i + 1] == textBox2.Text)
                    {
                        Visible = false;
                        label1.Text = "";
                        login = true;
                        Form2 form2 = new Form2(stud);
                        form2.ShowDialog();
                        Visible = true;
                        break;
                    }
                }
            }
            if (!login)
            {
                label1.Text = "Неверный логин или пароль!";
            }
            else
                login = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
    
    class Scool
    {
        static Student[] masStud;
        static Prepodavatel[] masPrep;

        public Scool()
        {
            masStud = new Student[1];
            masPrep = new Prepodavatel[1];
        }

        public void dobavStud(Student a)
        {
            masStud[masStud.Length - 1] = a;
            Array.Resize(ref masStud, masStud.Length + 1);
        }

        public void dobavPrep(Prepodavatel a)
        {
            masPrep[masPrep.Length - 1] = a;
            Array.Resize(ref masPrep, masPrep.Length + 1);
        }
    }

    public class Grupp
    {
        static string[] masGrup;
        static string[,] masPredGrup;

        public Grupp()
        {
            string[] mas1 = { "ВЯ-133", "СТ-44", "ГЛ-189"};
            string[,] mas2 = { {"Русский", "Математика", "Литература"}, {"Физика", "География", "Биология"}, { "Химия", "История", "Обществознание" } };
            masGrup = mas1;
            masPredGrup = mas2;
        }

        public int len
        {
            get { return masGrup.Length; }
        }

        public string this[int i]
        {
            get { return masGrup[i]; }
        }

        public string[] predGrup(int i)
        {
            string[] mas = new string[3];
            for(int j = 0; j < 3; j++)
            {
                mas[j] = masPredGrup[i, j];
            }
            return mas;
        }

        public bool poiskPREDM(string predm)
        {
            for (int i = 0; i < masPredGrup.GetLength(0); i++)
            {
                for(int j = 0; j < masPredGrup.GetLength(1); j++)
                {
                    if(predm != masPredGrup[i,j])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public string retPREDM(string predm)
        {
            int k = 0;
            for (int i = 0; i < masPredGrup.GetLength(0); i++)
            {
                for (int j = 0; j < masPredGrup.GetLength(1); j++)
                {
                    if (predm != masPredGrup[i, j])
                    {
                        k = i; break;
                    }
                }
            }
            return masGrup[k];
        }
    }

    public class Student
    {
        string name;
        string surname;
        int age;
        string group;
        string numstudent;
        int[,] massOcen;
        string[] massPred;
        public string Name
        {
            get { return name; }
            set { name = value; }

        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public string Group
        {
            get { return group; }
            set { group = value; }
        }
        public string Numstudent
        {
            get { return numstudent; }
            set { numstudent = value; }
        }
        public string MassOcen()
        {
            string str = "";
            for (int i = 0; i < massOcen.GetLength(0); i++)
            {
                str += massPred[i];
                str += ": ";
                for (int j = 0; j < massOcen.GetLength(1); j++)
                {
                    str += massOcen[i, j];
                    str += ' ';
                }
                str += "\n";
            }
            return str;
        }
        public Student(string iname, string isurname, int iage, string igroup, string inumstudent, string[] masPred, int[,] masOcen)
        {
            name = iname;
            surname = isurname;
            age = iage;
            group = igroup;
            numstudent = inumstudent;
            massOcen = masOcen;
            massPred = masPred;
        }

        public Student(string iname, string isurname, int iage, string igroup, string inumstudent, string[] masPred)
        {
            name = iname;
            surname = isurname;
            age = iage;
            group = igroup;
            numstudent = inumstudent;
            massPred = masPred;
        }
    }
    public class Prepodavatel
    {
        string Group;
        string Predm;
        string name;
        string surname;
        int age;
        int salary;
        public string MassGroup
        {
            get { return Group; } set { Group = value; }
        }
        public string MassPred
        {
            get { return Predm; } set {  Predm = value; }
        }

        public string Age
        {
            get { return Convert.ToString(age); }
            set { age = Convert.ToInt32(value); }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public string Salary
        {
            get { return Convert.ToString(salary); }
            set { salary = Convert.ToInt32(value); }
        }

        public Prepodavatel(string iname, string isurname, int iage, int isalary, string Grup, string Pred)
        {
            name = iname;
            surname = isurname;
            age = iage;
            salary = isalary;
            Group = Grup;
            Predm = Pred;
        }
    }
}
