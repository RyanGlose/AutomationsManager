using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AutomationsManager.Core.Processes;

namespace AutomationsManager.Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            //Thread.Sleep(10000);
            var service = new ProcessesService.ProcessesServiceClient();
            //service.Endpoint.Binding.SendTimeout = TimeSpan.FromSeconds(5);
            service.GetDataAsync(4).ContinueWith(ShowConnectionStatus);
        }

        private void ShowConnectionStatus(Task<string> checkConnectionsStatusTask)
        {
            Dispatcher.Invoke(() =>
            {
                if (checkConnectionsStatusTask.IsFaulted)
                {
                    var message = "Could not connect to the service or exception occured.";
                    message += Environment.NewLine;
                    message += "========================================";
                    message += Environment.NewLine;
                    if (checkConnectionsStatusTask.Exception != null)
                    {
                        foreach (var exceptionInnerException in checkConnectionsStatusTask.Exception.InnerExceptions)
                        {
                            message += exceptionInnerException.Message;
                            message += Environment.NewLine;
                            message += "========================================";
                            message += Environment.NewLine;
                        }
                    }
                    lSomeLabel.Text = message;
                }
                else
                {
                    lSomeLabel.Text = checkConnectionsStatusTask.Result;
                    FileOperationsHelper.CopyFile(@"\\Lenovo_Przemek\Shared\archive.7z", @"C:\\SQL\\archive.7z");
                }
            });
        }
    }
}
