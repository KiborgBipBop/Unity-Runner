using System.Collections;
using System.Collections.Generic;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string action;

    private void OnEnable()
    {
        Loader.LoadOnAction(action);
    }

    private void OnApplicationQuit()
    {
        Loader.CloseSockets();
    }
}
