using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Server
{
    class Program
    {
        private static string remoteAddress = "127.0.0.1";
        private static int clientPort = 9001;
        private static int localPort = 9000;

        public static void Main(string[] args)
        {
            try
            {
                Thread receiveThread = new Thread(new ThreadStart(ReceiveMessage));
                receiveThread.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void ReceiveMessage()
        {
            UdpClient receiver = new UdpClient(localPort);
            IPEndPoint remoteIp = null;
            try
            {
                while (true)
                {
                    byte[] data = receiver.Receive(ref remoteIp);
                    string message = Encoding.Unicode.GetString(data);
                    Console.WriteLine("Сообщение от клиента: " + message);
                    SendMessage(DetermineSceneName(message));
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                receiver.Close();
            }
        }

        private static void SendMessage(string message)
        {
            UdpClient sender = new UdpClient();
            try
            {
                byte[] data = Encoding.Unicode.GetBytes(message);
                sender.Send(data, data.Length, remoteAddress, clientPort);
                Console.WriteLine("Ответ сервера: " + message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sender.Close();
            }
        }

        private static string DetermineSceneName(string clientRequest)
        {
            switch (clientRequest)
            {
                case "StartButtonPressed":
                    return "BeginCutscene";
                case "LoadLevel":
                case "Failed":
                    return "Level";
                case "LevelComplete":
                    return "EndCutscene";
                case "StartGame":
                case "GameFinished":
                    return "MainMenu";
            }
            return null;
        }
    }
}

