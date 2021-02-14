using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    
    List<GameObject> Players;

    void Start()
    {
        Players = GameObject.FindGameObjectsWithTag("Player").ToList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerDead(GameObject player, bool isUser)
    {
        if(isUser)
        {
            //PlayerLose
            ShowEndGame(false);
            //restart
            Invoke(nameof(LoadNext), 3f);
        }

        if(Players.Contains(player))
        {
            Players.Remove(player);
        }

        if(Players.Count == 1)
        {
            //PlayerWin
            ShowEndGame(true);
            //restart
            Invoke(nameof(LoadNext), 3f);
        }

    }

    private void ShowEndGame(bool isSuccess)
    {
        if(isSuccess)
        {
            //win state
        }
        else
        {
            //lose state
        }
    }

    private void LoadNext()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
