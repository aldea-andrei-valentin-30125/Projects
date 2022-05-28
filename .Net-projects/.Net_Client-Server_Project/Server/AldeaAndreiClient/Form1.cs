using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AldeaAndrei;

namespace AldeaAndreiClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            refresh();
        }

        AldeaAndreiClient.ServiceReference1.WebService1SoapClient service = new AldeaAndreiClient.ServiceReference1.WebService1SoapClient();

        private void refresh()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();


            for (int i = 0; i < service.getStudents().Count(); i++)
            {
                var x = new Student
                {
                    Id = service.getStudents().ElementAt(i).Id,
                    Name = service.getStudents().ElementAt(i).Name,
                    Materia = service.getStudents().ElementAt(i).Materia,
                    Nota = service.getStudents().ElementAt(i).Nota
                };
                listBox1.Items.Add(x.Name);
                listBox2.Items.Add(x.Materia);
                listBox3.Items.Add(x.Nota.ToString());
                listBox4.Items.Add(x.Id.ToString());
            }
        }

        private void refresh_btn_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            service.addStudent(Convert.ToString(nameBox.Text), Convert.ToString(materiaBox.Text), Convert.ToInt32(notaBox.Text));
            nameBox.Text = "";
            materiaBox.Text = "";
            notaBox.Text = "";
            refresh();
        }

        private void deleteBtn_Click_1(object sender, EventArgs e)
        {
            service.deleteStudent(Convert.ToInt32(selectIDBox.Text));
            refresh();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {           
            var x = new Student
            {
                Id = service.getStudent(Convert.ToInt32(selectIDBox.Text)).Id,
                Name = service.getStudent(Convert.ToInt32(selectIDBox.Text)).Name,
                Materia = service.getStudent(Convert.ToInt32(selectIDBox.Text)).Materia,
                Nota = service.getStudent(Convert.ToInt32(selectIDBox.Text)).Nota
            };
            
            nameBox.Text = x.Name;
            materiaBox.Text = x.Materia;
            notaBox.Text = x.Nota.ToString();
            refresh();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            service.editStudent(Convert.ToInt32(selectIDBox.Text), Convert.ToString(nameBox.Text), Convert.ToString(materiaBox.Text), Convert.ToInt32(notaBox.Text));
            nameBox.Text = "";
            materiaBox.Text = "";
            notaBox.Text = "";
            refresh();
        }
    }
}
