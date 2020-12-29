using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public static class Loader
{
    static string remoteAddress = "127.0.0.1";
    static int remotePort = 9000;
    static int localPort = 9001;

    static UdpClient sender = new UdpClient();
    static UdpClient receiver = new UdpClient(localPort);

    public static void LoadOnAction(string action)
    {
        SendMessage(action);
        ReceiveMessage();
    }
    
    private static void SendMessage(string message)
    {
        try
        {
            byte[] data = Encoding.Unicode.GetBytes(message);
            sender.Send(data, data.Length, remoteAddress, remotePort);
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
            CloseSockets();
        }
    }

    private static void ReceiveMessage()
    {
        IPEndPoint remoteIp = null; 
        try
        {
            byte[] data = receiver.Receive(ref remoteIp);
            string message = Encoding.Unicode.GetString(data);
            SceneManager.LoadScene(message);
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
            CloseSockets();
        }
    }

    public static void CloseSockets()
    {
        sender.Close();
        receiver.Close();
    }
}
