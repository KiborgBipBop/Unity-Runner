using System.Collections;
using System.Collections.Generic;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UDPConnection : MonoBehaviour
{
    public string action;
    // Start is called before the first frame update
    private static string remoteAddress = "127.0.0.1";
    private static int remotePort = 8082;
    private static int localPort = 8083;

    //public string action = "LevelComplete";

    public void Start()
    {
        SendMessage(action);
        ReceiveMessage();
    }

    private void SendMessage(string message)
    {
        UdpClient sender = new UdpClient(); // создаем UdpClient для отправки сообщений
        try
        {
            byte[] data = Encoding.Unicode.GetBytes(message);
            sender.Send(data, data.Length, remoteAddress, remotePort);
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

    private void ReceiveMessage()
    {
        UdpClient receiver = new UdpClient(localPort); // UdpClient для получения данных
        IPEndPoint remoteIp = null; // адрес входящего подключения
        try
        {
            
                byte[] data = receiver.Receive(ref remoteIp); // получаем данные
                string message = Encoding.Unicode.GetString(data);
                SceneManager.LoadScene(message);
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
        finally
        {
            receiver.Close();
        }
    }
}
