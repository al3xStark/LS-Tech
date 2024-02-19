using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LS_Tech_TCPServer
{
    internal class ClientObject
    {
        const string HELLOMESSAGE = "Hello, server";
        const string HELLORESPONSE = "Hello, client";
        const string REJECTRESPONSE = "Client Rejected";
        protected internal string Id { get; } = Guid.NewGuid().ToString();
        protected internal StreamWriter Writer { get; }
        protected internal StreamReader Reader { get; }

        TcpClient client;
        ServerObject server;
        public EndPoint? RemoteEndPoint { get => client.Client.RemoteEndPoint; }

        public ClientObject(TcpClient tcpClient, ServerObject serverObject)
        {
            client = tcpClient;
            server = serverObject;
            var stream = client.GetStream();
            Reader = new StreamReader(stream);
            Writer = new StreamWriter(stream);
        }
        public async Task ProcessAsync()
        {
            try
            {
                string? message;
                while (true)
                {
                    try
                    {
                        message = await Reader.ReadLineAsync();
                        if (message == null) continue;
                        Logger.PrintNotification($"{RemoteEndPoint}: \"{message}\"");
                        await server.MessageAsync(HelloResponse(message), Id);
                        Logger.PrintNotification($"Ответ отправлен {RemoteEndPoint}");
                    }
                    catch
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.PrintError(ex.Message);
            }
            finally
            {
                server.RemoveConnection(Id);
            }
        }
        string HelloResponse(string message)
        {
            //message = message.Trim();
            if (message == HELLOMESSAGE) return HELLORESPONSE;
            else return REJECTRESPONSE;
        }
        protected internal void Close()
        {
            Writer.Close();
            Reader.Close();
            client.Close();
        }
    }
}
