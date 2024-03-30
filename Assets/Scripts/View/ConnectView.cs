using Assets.Scripts.Shared.Tools;
using System;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

[Serializable]
public class ConnectView : ViewPanel
{
    public Action OnConnectionAttempt;

    [SerializeField] 
    TextMeshProUGUI StatusText;

    public void TryConnect()
    {
        UpdateStatus($"Connecting...");
        OnConnectionAttempt?.Invoke();
    }

    public void UpdateStatus(string message)
    {
        try
        {
            StatusText.text = message;
        }
        catch (Exception e) 
        {
            ConsoleLogger.LogException("CONNECT_VIEW", e);
            StatusText.text = $"Err... {e.Message}";
        }
    }
}
