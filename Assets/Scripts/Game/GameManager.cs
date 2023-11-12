using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private List<Player> _players = new List<Player>();
    private Player _currentPlayer;

    public void Awake()
    {
        Instance = this;
    }

    public void ConfigureTest()
    {
        _players = new List<Player>()
        {
            new Player("Player-1", 5, new Stats(3,2,1,0,2,0,0), 16),
            new Player("Player-2", 15, new Stats(2,3,1,1,2,3,2), 16),
            new Player("Player-3", 25, new Stats(1,0,2,3,2,0,1), 16),
            new Player("Player-4", 55, new Stats(0,1,3,0,2,0,3), 16)
        };
    }
}
