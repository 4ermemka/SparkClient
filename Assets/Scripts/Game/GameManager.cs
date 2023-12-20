using System;
using System.Net;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private Client _client;

    public void Awake()
    {
        Instance = this;
    }


    public void Start()
    {
        _client = new Client();
        _client.OnLog += LogInfo;
    }

    private void LogInfo(string message)
    {
        Debug.Log(message);
    }

    public void Connect()
    {
        try 
        {
            try
            {
                _client.Connect("127.0.0.1", 3535);
            }
            catch (Exception ex)
            { 
                Debug.Log($"{ex.Message} : { ex.StackTrace}");
            }
        }
        catch (Exception ex)
        { 
            Debug.LogException(ex);
        }
    }

    public void OnDestroy()
    {
        _client?.Stop();
    }
}
