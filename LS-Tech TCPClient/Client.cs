using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LS_Tech_TCPClient
{
    public delegate void GetResponse();
    internal class Client
    {
        TcpClient client;
        StreamReader Reader;
        StreamWriter Writer;
        IPEndPoint RemoteEndPoint;
        public string Response { get; private set; }
        public async Task ConnectToServerAsync(IPAddress host, int port, string request)
        {
            try
            {
                await TryToConnectAsync(host, port);
                await SendMessageAsync(Writer, request);
                await ReceiveMessageAsync(Reader);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        async Task TryToConnectAsync(IPAddress host, int port)
        {
            try
            {
                if (client is null || client.Client is null || !client.Client.Connected) client = new TcpClient();

                if (client.Connected && (RemoteEndPoint?.AddressFamily != host.AddressFamily || RemoteEndPoint?.Port != port))
                {
                    Disconnect();
                    client = new TcpClient();
                }
                if (!client.Connected)
                {
                    RemoteEndPoint = new IPEndPoint(host, port);
                    await client.ConnectAsync(RemoteEndPoint.Address, RemoteEndPoint.Port);
                    Reader = new StreamReader(client.GetStream());
                    Writer = new StreamWriter(client.GetStream());
                }
                if (Writer is null || Reader is null) throw new Exception(message: "Не удалось получить поток для обмена данных.");
            }
            catch (Exception ex)
            {
                Disconnect();
                throw ex;
            }
        }
        public void Disconnect()
        {
            Writer?.Close();
            Reader?.Close();
            client?.Close();
        }
        async Task SendMessageAsync(StreamWriter writer, string request)
        {
            await writer.WriteLineAsync(request);
            await writer.FlushAsync();
        }
        async Task ReceiveMessageAsync(StreamReader reader)
        {
            try
            {
                string message = await reader.ReadLineAsync();
                if (string.IsNullOrEmpty(message)) return;
                Response = message;
            }
            catch
            {
                throw;
            }
        }
    }
}
