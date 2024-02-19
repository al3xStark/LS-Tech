using LS_Tech_TCPServer;
using System.Net;
using System.Net.Sockets;

bool status = false;
while (status == false)
{
    IPAddress? host;
    int port;
    Console.Write("Введите IP-адрес: ");
    while (!IPAddress.TryParse(Console.ReadLine(), out host))
    {
        Logger.PrintError("Введено некорректное значение адреса.", 1);
        Console.Write("Введите IP-адрес: ");
    }
    Console.Clear();
    Console.WriteLine($"IP-адрес: {host}");
    Console.Write("Введите порт: ");
    while (!int.TryParse(Console.ReadLine(), out port) || port < 0 || port > ushort.MaxValue)
    {
        Logger.PrintError("Введено некорректное значение порта.", 2, $"IP-адрес: {host}");
        Console.Write("Введите порт: ");
    }
    Console.Clear();
    Console.WriteLine($"IP-адрес: {host}");
    Console.WriteLine($"Порт: {port}\n");
    status = true;
    try
    {
        ServerObject server = new ServerObject(host, port);
        await server.ListenAsync();
    }
    catch (SocketException ex)
    {
        status = false;
        Logger.PrintError($"{ex.Message}\n");
        Console.WriteLine("Нажмите любую клавишу чтобы повторить попытку.");
        Console.ReadKey();
        Console.Clear();
    }
}