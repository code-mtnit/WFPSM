using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Sbn.Windows.Forms.AdvancedControls.WaitForm;

namespace Tester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WaitForm.getInstance().startW();
            Thread.Sleep(10000);
           // run(8);
            //run(5);
            //WaitForm.getInstance().startW(1); Thread.Sleep(500);
            //WaitForm.getInstance().startW(2); Thread.Sleep(500);
            //WaitForm.getInstance().startW(3); Thread.Sleep(500);
            //WaitForm.getInstance().startW(1); Thread.Sleep(500);
            //WaitForm.getInstance().startW(4); Thread.Sleep(500);
            //WaitForm.getInstance().startW(5); Thread.Sleep(500);
            //WaitForm.getInstance().startW(6); Thread.Sleep(500);
            //WaitForm.getInstance().startW(0); Thread.Sleep(500);
            //WaitForm.getInstance().stopW(); Thread.Sleep(500);
            //WaitForm.getInstance().stopW(); Thread.Sleep(500);
            //WaitForm.getInstance().stopW(); Thread.Sleep(500);
            WaitForm.getInstance().stopW(); 
        }

        public void run(int a)
        {
            if (a == 0) return;
            WaitForm.getInstance().startW(a);
            Thread.Sleep(500);
            run(a - 1);
            WaitForm.getInstance().stopW();
        }


        int Idx = 0;
        public void Counter()
        {
            for (int i = 0; i <= 100; i++)
            {
                Idx = i;
                System.Threading.Thread.Sleep(50);
            }
        }


        Sbn.Windows.Forms.AdvancedControls.WaitForm.WaitForm frm = new WaitForm();
        private void btnStart_Click(object sender, EventArgs e)
        {

            


             frm = new WaitForm(Counter);
             frm.Start();
            //frm = new WaitForm();
            //if (textBox1.Text != "")
            //{
            //    frm.Start();

            //    frm.startW(int.Parse(textBox1.Text));
            //    Counter();
            //    //  frm.Stop();
            //    frm.stopW();
            //    //frm.startW(int.Parse(textBox1.Text));
            //}
            //else
            //{


            //    frm.startW();
            //    Counter();
            //  //  frm.Stop();
            //     frm.stopW();
            //}
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            frm.stopW();
        }
    }
}