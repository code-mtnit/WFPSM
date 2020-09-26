using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Threading;
using System.Runtime.InteropServices;

namespace Sbn.Windows.Forms.AdvancedControls.WaitForm
{
    public partial class WaitForm : Form
    {

        public delegate void RunFunction();
        public delegate object RunFunction2(object Arg1);

        public BackgroundWorker Bw;
        public RunFunction thisFunction;
        public RunFunction2 thisFunction2;
        LoadingForm newLoading;

        public WaitForm(RunFunction newFunction)
        {
            thisFunction = newFunction;
            Bw = new BackgroundWorker();
            Bw.DoWork += new DoWorkEventHandler(Bw_DoWork);
            Bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Bw_RunWorkerCompleted);
        }

        public WaitForm(RunFunction2 newFunction)
        {
            thisFunction2 = newFunction;
            
            Bw = new BackgroundWorker();
            Bw.DoWork += new DoWorkEventHandler(Bw_DoWork);
            Bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Bw_RunWorkerCompleted);
        }

        public void Start()
        {
            if (Bw != null && Bw.IsBusy == false )
            {
                Bw.RunWorkerAsync();
            }
            newLoading = new LoadingForm();
           
            newLoading.ShowDialog();

        }

        public void Stop()
        {
            try
            {
                newLoading.Dispose();
            }
            catch
            { 

            }
        }

        void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                newLoading.Dispose();
            }
            catch
            {

            }
           // MessageBox.Show("Complete");
        }

        void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            
            if (thisFunction != null)
                thisFunction();
        }

        public void NullFunction()
        {
            newLoading = new LoadingForm();
            newLoading.StartPosition = FormStartPosition.CenterScreen;
            newLoading.ShowInTaskbar = false;
            newLoading.ControlBox = false;
            // form.TransparencyKey = Color.White;
            newLoading.TopMost = true;
            newLoading.ShowPictureBox = true;
            newLoading.Show();
            //newLoading.BringToFront();
           
        ////    thread = new Thread(new ThreadStart(initial));
        // //   thread.Start();
            while (started)
            {
                try
                {

                    newLoading.BringToFront();
                    newLoading.Invalidate();

                    newLoading.Refresh();
                  
                  
                }
                catch
                { }
            
               // newLoading.Show();
               // newLoading.BringToFront();
            }

            try
            {
                //if (!started)
                //    return;

                //thread.Interrupt();

                //thread.Abort();
                //thread.Join();
                //thread = null;

                started = false;
            }
            catch
            { }



            newLoading.Dispose();
        }



        public WaitForm()
        {


            InitializeComponent();



            thisFunction = NullFunction;
            Bw = new BackgroundWorker();
            Bw.DoWork += new DoWorkEventHandler(Bw_DoWork);
            Bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Bw_RunWorkerCompleted);

         //   this.pictureBox1.Image = global::Sbn.Windows.Forms.AdvancedControls.WaitForm.Properties.Resources._4953578_1_;
            //this.ShowIcon = false;
           // this.ControlBox = false;
           // base.SetStyle(ControlStyles.Opaque | ControlStyles.AllPaintingInWmPaint, true);
           // this.SizeGripStyle = SizeGripStyle.Hide;
           // this.StartPosition = FormStartPosition.CenterScreen;
           // this.ShowInTaskbar = false;
          //  this.Width = this.pictureBox1.Width;
          //  this.Height = this.pictureBox1.Height + 10;
            this.BringToFront();
        }

        public void initial()
        {

            try
            {
                



                // try
                {
                    switch (imageId)
                    {
                        case 1:
                            this.pictureBox1.Image = global::Sbn.Windows.Forms.AdvancedControls.WaitForm.Properties.Resources.hourglass_sand_pouring_md_wht;
                            break;

                        case 2:
                            this.pictureBox1.Image = global::Sbn.Windows.Forms.AdvancedControls.WaitForm.Properties.Resources.sheep_stuck_on_fence_md_wht;
                            break;

                        case 3:
                            this.pictureBox1.Image = global::Sbn.Windows.Forms.AdvancedControls.WaitForm.Properties.Resources.server_on_fire_md_wht;
                            break;
                        case 4:
                            this.pictureBox1.Image = global::Sbn.Windows.Forms.AdvancedControls.WaitForm.Properties.Resources._4953578_1_;
                            break;

                        case 5:
                            this.pictureBox1.Image = global::Sbn.Windows.Forms.AdvancedControls.WaitForm.Properties.Resources._4954328_1_;
                            break;

                        case 6:
                            this.pictureBox1.Image = global::Sbn.Windows.Forms.AdvancedControls.WaitForm.Properties.Resources._4954486_1_;
                            break;

                        case 7:
                            this.pictureBox1.Image = global::Sbn.Windows.Forms.AdvancedControls.WaitForm.Properties.Resources.hourglass_sand_pouring_md_wht;
                            break;
                        case 8:
                            this.pictureBox1.Image = global::Sbn.Windows.Forms.AdvancedControls.WaitForm.Properties.Resources.LoadingMap;
                            break;

                        case 9:
                            this.pictureBox1.Image = global::Sbn.Windows.Forms.AdvancedControls.WaitForm.Properties.Resources.loader_thumb;
                            break;

                        case 10:
                            this.pictureBox1.Image = global::Sbn.Windows.Forms.AdvancedControls.WaitForm.Properties.Resources.loading_star;
                            break;
                        case 11:
                            this.pictureBox1.Image = global::Sbn.Windows.Forms.AdvancedControls.WaitForm.Properties.Resources.loading1;
                            break;

                        case 12:
                            this.pictureBox1.Image = global::Sbn.Windows.Forms.AdvancedControls.WaitForm.Properties.Resources.loadinsdg;
                            break;

                        default:
                            // this.pictureBox1.Image = global::Sbn.Windows.Forms.AdvancedControls.WaitForm.Properties.Resources.hourglass_sand_pouring_md_wht;
                            this.pictureBox1.Image = global::Sbn.Windows.Forms.AdvancedControls.WaitForm.Properties.Resources.LoadingMap;
                            break;
                    }
                    // this.StartPosition = FormStartPosition.CenterScreen;

                    this.TopMost = true;
                    this.TopLevel = true;
                    //  Control contrl = new Control();
                    //   contrl = this.TopLevelControl;
                    //  this.StartPosition = FormStartPosition.CenterScreen;
                    //  this.Location = new Point(400, 400);
                    //   this.ShowInTaskbar = false;


                    this.ShowDialog();

                    //form.Show();
                }


            }
            /*    catch (Exception ex)
                {
                    MessageBox.Show(ex.TargetSite + ex.StackTrace);
                }
                */
            catch
            { }
        }

        Thread thread;
        Boolean started = false;
        int imageId = 0;
        public void startW()
        {
            started = true;

            if (Bw != null && Bw.IsBusy == false)
            {

                Bw.RunWorkerAsync();
            }

           // this.Start();

            //try
            //{
            //    if (started) return;
            //    started = true;
                
            //    imageId = 9;
            //    thread = new Thread(new ThreadStart(initial));
            //    thread.Start();
            //}
            //catch
            //{ }
        }

        protected override void OnClosed(EventArgs e)
        {
          
            label2.Text = "";
            base.OnClosed(e);
        }
        public void startW(Image Img)
        {
            try
            {
                this.pictureBox1.Image = Img;


                started = true;

                if (Bw != null && Bw.IsBusy == false)
                {

                    Bw.RunWorkerAsync();
                }

                //if (started) return;
                //started = true;
                //thread = new Thread(new ThreadStart(initial));
                //thread.Start();
            }
            catch
            { }
        }

        public void startW(int Image)
        {
            try
            {
                imageId = Image;

                started = true;

                if (Bw != null && Bw.IsBusy == false)
                {

                    Bw.RunWorkerAsync();
                }

             

                //if (started) return;
                //started = true;
                //thread = new Thread(new ThreadStart(initial));
                //thread.Start();
            }
            catch
            { }
        }

        public void stopW()
        {
            started = false;

          
            //try
            //{
            //    if (!started)
            //        return;

            //    //thread.Interrupt();

            //    thread.Abort();
            //    thread.Join();
            //    thread = null;

            //    started = false;
            //}
            //catch
            //{ }
          
        }

        private static WaitForm form =  null;

        public static WaitForm getInstance()
        {
            
            if (form == null)
            {
                form = new WaitForm();
                form.StartPosition = FormStartPosition.CenterScreen;
                form.ShowInTaskbar = false;
                form.ControlBox = false;
               // form.TransparencyKey = Color.White;
                form.TopMost = true;
                form.BringToFront();
            }
           // form.StartPosition = FormStartPosition.CenterScreen;
            return form;
        }

        //TimeSpan timp = new TimeSpan();
        //private void timer1_Tick(object sender, EventArgs e)
        //{

        //    TimeSpan tt = new TimeSpan();

        //    tt = DateTime.Now.TimeOfDay - timp;
        //   // timp.Add(tt);
        //    this.label2.Text = tt.ToString();
        //}

        private void WaitForm_Load(object sender, EventArgs e)
        {
          //  timer1.Start();
            


        }

    }


} 