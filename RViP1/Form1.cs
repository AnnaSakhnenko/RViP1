using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;



namespace RViP1
{
    public partial class Form1 : Form
    {
        private static System.Timers.Timer aTimer;
        SMTP S = new SMTP();
        InfoList IL = new InfoList();
        InfoList ILS = new InfoList();
        InfoList ILS2 = new InfoList();
        Random r = new Random();

        public Form1()
        {
            InitializeComponent();
            IL.list = new List<Info>();
            ILS.list = new List<Info>();
            ILS2.list = new List<Info>();
            TimeOfUserCreation();
            timer2.Enabled = true;
            timer2.Interval = 500;
            timer2.Tick += new EventHandler(timer2_Tick);
            timer2.Start();
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
            timer3.Enabled = true;
            timer3.Interval = 1000;
            timer3.Tick += new EventHandler(timer1_Tick);
            timer3.Start(); 
        }

        public void TimeOfUserCreation()
        {
            aTimer = new System.Timers.Timer(3000);
            aTimer.Elapsed += UserCreation;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        public void UserCreation(Object source, ElapsedEventArgs e)
        {            
            for (int i = 0; i < 3; i++)
            {
                System.Threading.Thread newThread = new System.Threading.Thread(UserList);
                newThread.Start();
            }
        }

        public void UserList()
        {
            Info I = new Info();
            I.email = "User@test.ru";
            I.where = "User@test.ru";
            I.text = "Сообщение";
            IL.list.Add(I);
            S.Smtp(checkBox1.Checked, checkBox2.Checked, IL.list, ILS.list, ILS2.list);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < ILS.list.Count; i++)
            {
                listBox2.Items.Add(ILS.list[i].text + r.Next(9).ToString() + " " + ILS.list[i].email + " " + ILS.list[i].where);
            }
            ILS.list.Clear();
            for (int i = 0; i < ILS2.list.Count; i++)
            {
                listBox3.Items.Add(ILS2.list[i].text + r.Next(9).ToString() + " " + ILS2.list[i].email + " " + ILS2.list[i].where);
            }
            ILS2.list.Clear();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Form1_Load(null, null);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (listBox2.Items.Count != 0)
            {                
                string[] text = listBox2.Items[0].ToString().Split(' ');
                textBox1.Text = text[0] + Environment.NewLine + text[1] + Environment.NewLine + text[2];
                listBox2.Items.RemoveAt(0);
                timer1.Stop();
            }
            if (listBox3.Items.Count != 0)
            {
                string[] text = listBox3.Items[0].ToString().Split(' ');
                textBox2.Text = text[0] + Environment.NewLine + text[1] + Environment.NewLine + text[2];
                listBox3.Items.RemoveAt(0);
                timer1.Stop();
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
