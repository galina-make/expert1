using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class Server
    {
        private static ManualResetEvent allDone = new ManualResetEvent(false);
        private UdpClient udpClient_S;
        private int port;

        public Server (int _port)
        {
            udpClient_S = new UdpClient(_port);
            this.port = _port;
            Console.WriteLine("Сервер работает");
        }

        public void StartListenAsync()
        {
            while(true)
            {
                allDone.Reset();
                udpClient_S.BeginReceive(RequestCallback, udpClient_S);
                allDone.WaitOne();
            }
        }

        private void RequestCallback(IAsyncResult ar)
        {
            allDone.Set();
            var listener = (UdpClient)ar.AsyncState;
            var ep = (IPEndPoint)udpClient_S.Client.LocalEndPoint;
            var res = listener.EndReceive(ar, ref ep);
            string data = Encoding.Unicode.GetString(res);
            Console.WriteLine("Сообщение от клиента: {0}", data);
            byte[] z = Encoding.Unicode.GetBytes("Ваше сообщение получено");
            udpClient_S.SendAsync(z, z.Length, ep);
        }
    }
    class Program
    {
        //private static void SendMessage()
        //{
        //    try
        //    {
        //        Console.WriteLine("Введите ответ на сообщение:  \"{0}\" ", Program.message);
        //        string message = Console.ReadLine(); // сообщение для отправки
        //        byte[] data = Encoding.Unicode.GetBytes(message);
        //        udpServer.Send(data, data.Length, "127.0.0.1", 8002); // отправка
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}

        //private static void ReceiveMessage()
        //{
        //    IPEndPoint remoteIp = (IPEndPoint)udpServer.Client.LocalEndPoint;//адрес входящего подключения
        //    try
        //    {
        //        byte[] data = udpServer.Receive(ref remoteIp);
        //        message = Encoding.Unicode.GetString(data);
        //        Console.WriteLine("Сообщение от клиента: {0}", message);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}

        //static string message = " ";
        //public static UdpClient udpServer;


        static void Main(string[] args)
        {
            //udpServer = new UdpClient(8001);
            //try
            //{
            //    Console.WriteLine("Сервер работает");
            //    ReceiveMessage();
            //    SendMessage();
            //    Console.ReadKey();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            Logger logger = LogManager.GetCurrentClassLogger(); // логирование

            logger.Trace("trace message");
            logger.Debug("debug message");
            logger.Info("info message");
            logger.Warn("warn message");
            logger.Error("error message");
            logger.Fatal("fatal message");

            Server server = new Server(8001);
            server.StartListenAsync();

        }
    }
}
