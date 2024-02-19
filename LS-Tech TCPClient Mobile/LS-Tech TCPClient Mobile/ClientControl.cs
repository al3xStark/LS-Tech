using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LS_Tech_TCPClient
{
    public delegate void UpdateLogs();
    internal class ClientControl
    {
        Client client;
        public string Host { get; set; }
        public string Port { get; set; }
        public string HelloMessage { get; set; }
        public string Logs { get; private set; }
        readonly UpdateLogs UpdateLogs;
        public ClientControl(UpdateLogs updateLogs)
        {
            UpdateLogs = updateLogs;
            client = new Client();
        }
        public async void ConnectToServerAsync()
        {
            try
            {
                if (!IPAddress.TryParse(Host, out IPAddress host)) throw new Exception(message: "IP-адрес введен некорректно.");
                if (!int.TryParse(Port, out int port)) throw new Exception(message: "Порт введен некорректно.");
                if (port < 0 || port > ushort.MaxValue) throw new Exception(message: "Значение порта вне допустимого диапазона.");

                await client.ConnectToServerAsync(host, port, HelloMessage);
                Logs += client.Response + "\n";
                UpdateLogs?.Invoke();
            }
            catch (Exception ex)
            {
                Logs += ex.Message + "\n";
                UpdateLogs?.Invoke();
            }
        }
        public void Disconnect()
        {
            client.Disconnect();
        }
    }
}
