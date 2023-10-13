using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace RVIAPOON.View
{
    public partial class Start : Window
    {
        private DispatcherTimer timer;
        private int progressValue;
        public Start()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Tick += Timer_Tick;

            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            progressValue++;
            progressBar.Value = progressValue;


            if (progressValue >= progressBar.Maximum)
            {
                timer.Stop();
                MainWindow mw = new MainWindow();
                this.Close();
                mw.ShowDialog();
            }
        }
    }
}
