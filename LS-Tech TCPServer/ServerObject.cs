using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LS_Tech_TCPServer
{
    internal class ServerObject
    {
        TcpListener tcpListener;
        List<ClientObject> clients = new List<ClientObject>();

        public ServerObject(IPAddress ip, int port)
        {
            tcpListener = new TcpListener(ip, port);
        }
        protected internal void RemoveConnection(string id)
        {
            try
            {
                ClientObject? client = clients.FirstOrDefault(c => c.Id == id);
                if (client != null) clients.Remove(client);
                EndPoint? closedClient = client?.RemoteEndPoint;
                client?.Close();
                if (closedClient != null)
                    Logger.PrintNotification($"Подключение разорвано: {closedClient}");
            }
            catch (Exception ex)
            {
                Logger.PrintError(ex.Message);
            }
        }
        protected internal async Task ListenAsync()
        {
            try
            {
                tcpListener.Start();
                Console.WriteLine("Сервер запущен. Ожидание подключений...");

                while (true)
                {
                    TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync();
                    Logger.PrintNotification($"Входящее подключение: {tcpClient.Client.RemoteEndPoint}");
                    ClientObject clientObject = new ClientObject(tcpClient, this);
                    clients.Add(clientObject);
                    Task.Run(clientObject.ProcessAsync);
                    Logger.PrintNotification($"Подключение установлено: {clientObject.RemoteEndPoint}");
                }
            }
            catch (SocketException) { throw; }
            catch (Exception ex)
            {
                Logger.PrintError(ex.Message);
            }
            finally
            {
                Disconnect();
            }
        }
        protected internal async Task MessageAsync(string message, string id)
        {
            ClientObject? client = clients.FirstOrDefault(c => c.Id == id);
            if (client != null)
            {
                await client.Writer.WriteLineAsync(message);
                await client.Writer.FlushAsync();
            }
        }
        protected internal void Disconnect()
        {
            foreach (var client in clients)
            {
                client.Close();
            }
            tcpListener.Stop();
        }
    }
}
