using LS_Tech_TCPClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LS_Tech_TCPClient_Mobile
{
    public partial class MainPage : ContentPage
    {
        ClientControl clientControl;
        UpdateLogs updateLogs;
        public MainPage()
        {
            InitializeComponent();
            updateLogs = new UpdateLogs(UpdateLogsRichTextBox);
            clientControl = new ClientControl(updateLogs);
            BindingContext = clientControl;
            connectButton.Clicked += connectButton_Click;
            helloMessageEntry.Text = "Hello, server";
            //helloMessageEntry.DataBindings.Add(new Binding("Text", clientControl, "HelloMessage", false, DataSourceUpdateMode.OnPropertyChanged));
            //hostEntry.DataBindings.Add(new Binding("Text", clientControl, "Host"));
            //portEntry.DataBindings.Add(new Binding("Text", clientControl, "Port"));
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            clientControl.ConnectToServerAsync();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            helloMessageEntry.Text = "Hello, server";
        }

        public void UpdateLogsRichTextBox()
        {
            logsEditor.Text = clientControl.Logs;
        }
    }
}
