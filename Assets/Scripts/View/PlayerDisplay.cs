using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDisplay : MonoBehaviour
{
    private Player _currentPlayer;

    public void SetPlayer(Player player)
    { 
        _currentPlayer = player;
    }
}
