using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace PengLang
{
    public partial class FrmLoading : Form
    {
        public FrmLoading()
        {
            InitializeComponent();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Show(String msg)
        {
            lblTip.Text = msg;
            this.Show();
            Application.DoEvents();
        }

        private delegate void SetTextHandler(string text);

        public void SetText(string text)
        {
            if (this.lblTip.InvokeRequired)
            {
                this.Invoke(new SetTextHandler(SetText), text);
            }
            else
            {
                this.lblTip.Text = text;
            }
            
        }
    }

    public class WaitingService
    {

        public static  void BeginLoading()
        {
            Cursor.Current = Cursors.WaitCursor;
            //2015-12-12
            //WaitingService.Instance.CreateLoadingForm();
        }

        public static void BeginLoading(string tip)
        {
            Cursor.Current = Cursors.WaitCursor;
            //2015-12-12
            //WaitingService.Instance.CreateLoadingForm(tip); 
        }
        public static void EndLoading()
        {
            Cursor.Current = Cursors.Default;
            //2015-12-12
            //WaitingService.Instance.CloseLoadingForm();
        }
        
        private static WaitingService _instance;
        
        private static readonly Object syncLock = new Object();

        public static WaitingService Instance
        {
            get
            {
                if (WaitingService._instance == null)
                {
                    lock (syncLock)
                    {
                        if (WaitingService._instance == null)
                        {
                            WaitingService._instance = new WaitingService();
                        }
                    }
                }
                return WaitingService._instance;
            }
        }

        private WaitingService()
        {

        }
         
        private Thread waitThread;
       
        private FrmLoading frmLoading;

        private void CreateLoadingForm()
        {
            if (waitThread != null)
            {
                try
                {
                    waitThread.Abort();
                    waitThread.Join();
                }
                catch (Exception)
                {
                }
            }

            waitThread = new Thread(new ThreadStart(delegate()
            {
                frmLoading = new FrmLoading();
                Application.Run(frmLoading);
            }));
            waitThread.Start();
        }
        private void CreateLoadingForm(string text)
        {
            if (waitThread != null)
            {
                try
                {
                    waitThread.Abort();
                }
                catch (Exception)
                {
                }
            }

            waitThread = new Thread(new ThreadStart(delegate()
            {
                frmLoading = new FrmLoading();
                frmLoading.SetText(text);
                Application.Run(frmLoading);
            }));
            waitThread.Start();
        }

        private void CloseLoadingForm()
        {
            if (waitThread != null)
            {
                try
                {
                    waitThread.Abort(); 
                    waitThread.Join(); 
                   
                }
                catch (Exception)
                {
                }
            }
        }
        private void SetFormCaption(string text)
        {
            if (frmLoading != null)
            {
                try
                {
                    frmLoading.SetText(text);
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
