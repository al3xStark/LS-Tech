using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LS_Tech_TCPClient
{
    public partial class Form : System.Windows.Forms.Form
    {
        ClientControl clientControl;
        UpdateLogs updateLogs;
        public Form()
        {
            InitializeComponent();
            updateLogs = new UpdateLogs(UpdateLogsRichTextBox);
            clientControl = new ClientControl(updateLogs);
            helloMessageTextBox.DataBindings.Add(new Binding("Text", clientControl, "HelloMessage", false, DataSourceUpdateMode.OnPropertyChanged));
            hostMaskedTextBox.DataBindings.Add(new Binding("Text", clientControl, "Host"));
            portTextBox.DataBindings.Add(new Binding("Text", clientControl, "Port"));
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            clientControl.ConnectToServerAsync();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            helloMessageTextBox.Text = "Hello, server";
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            clientControl.Disconnect();
        }

        public void UpdateLogsRichTextBox()
        {
            logsRichTextBox.Text = clientControl.Logs;
        }
    }
}
