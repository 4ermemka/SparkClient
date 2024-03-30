using Assets.Scripts.Shared.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class ClientViewManager : MonoBehaviour
{
    public Action OnConnectionAttempt;

    public List<ViewPanel> Views;
    private ConnectView ConnectView;

    public void Start()
    {
        DontDestroyOnLoad(this);

        foreach(var view in Views) 
        { 
            view.Start();
        }

        ConnectView = Views.FirstOrDefault(x => x is ConnectView) as ConnectView;
        ConnectView.OnConnectionAttempt += new Action(() => { 
            OnConnectionAttempt?.Invoke();
        });
    }

    public void ShowView(Type type)
    {
        ViewPanel selectedView = null;

        try
        {
            selectedView = Views.FirstOrDefault(x => x.GetType() == type);

            if (selectedView != null)
            {
                ConsoleLogger.LogInformation("VeiwManager", $"selectedView != null");

                foreach (var view in Views)
                {
                    ConsoleLogger.LogInformation("VeiwManager", $"Hiding {view.GetType()}");
                    view.Hide();
                    ConsoleLogger.LogInformation("VeiwManager", $"Hidden! {view.GetType()}");
                }

                selectedView.Show();
                ConsoleLogger.LogInformation("VeiwManager", $"Showing {type}");
            }

            else
            {
                ConsoleLogger.LogError("VeiwManager", $"No view found with name {type}");
            }
        }
        catch (Exception ex)
        {
            ConsoleLogger.LogInformation("ViewManager", $"EXCEPTION: {ex.Message}. \n{ex.Source}. \n{ex.StackTrace}");
        }
    }

    public void UpdateConnectionStatus(string status)
    {
        ConnectView.UpdateStatus("<color=#ff0014>" + status + "</color>");
    }
}
