using Assets.Scripts.Shared.Tools;
using Assets.Scripts.Shared.View;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private NetManager netManager;
    
    [SerializeField]
    private ClientViewManager ViewManager;

    [SerializeField]
    private List<SimpleViewConsole> LogEndpoints;

    public void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        ConsoleLogger.OnLogInformation += LogInformation;
        ConsoleLogger.OnLogWarning += LogWarning;
        ConsoleLogger.OnLogError += LogError;
        ConsoleLogger.OnLogException += LogException;

        netManager = new NetManager();

        ViewManager.OnConnectionAttempt += ConnectToServer;

        netManager.OnConnectedToServer += new Action<string>((msg)=>
        {
            ConsoleLogger.LogInformation("NetManager", msg);
            ViewManager.ShowView(typeof(MenuView));
        });
        
        netManager.OnDisconnectedFromServer += new Action<string>((msg) =>
        {
            ConsoleLogger.LogInformation("NetManager", msg);
            ViewManager.ShowView(typeof(ConnectView));
        });
    }

    public void LogInformation(string source, string message)
    {
        Debug.Log($"[{source}][INF] {message}");
        if (LogEndpoints != null && LogEndpoints.Count > 0)
        { 
            foreach (var console in LogEndpoints) 
            { 
                console.LogInformation(source, message);
            }
        }
    }

    public void LogWarning(string source, string message)
    {
        Debug.LogWarning($"[{source}][WRN] {message}");

        if (LogEndpoints != null && LogEndpoints.Count > 0)
        {
            foreach (var console in LogEndpoints)
            {
                console.LogWarning(source, message);
            }
        }
    }

    public void LogError(string source, string message)
    {
        Debug.LogWarning($"[{source}][INF] {message}");
        if (LogEndpoints != null && LogEndpoints.Count > 0)
        {
            foreach (var console in LogEndpoints)
            {
                console.LogError(source, message);
            }
        }
    }

    public void LogException(string source,Exception ex)
    {
        Debug.LogWarning(ex.Message);
        if (LogEndpoints != null && LogEndpoints.Count > 0)
        {
            foreach (var console in LogEndpoints)
            {
                console.LogException(source, ex);
            }
        }
    }

    public void ConnectToServer()
    {
        netManager.Connect();
    }

    public void OnDestroy()
    {
        netManager?.Disconnect();
    }
}