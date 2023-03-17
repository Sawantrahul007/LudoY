using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject mainpanel;
    public GameObject gamepanel;
    public void Game1()
    {
        GameManager.gm.totalplayercanplay = 2;
        mainpanel.SetActive(false);
        gamepanel.SetActive(true);
        Game1Setting();
    }
    public void Game2()
    {
        GameManager.gm.totalplayercanplay = 3;
        mainpanel.SetActive(false);
        gamepanel.SetActive(true);
        Game2Setting();
    }
    public void Game3()
    {
        GameManager.gm.totalplayercanplay = 4;
        mainpanel.SetActive(false);
        gamepanel.SetActive(true);
    }
    public void Game4()
    {
        GameManager.gm.totalplayercanplay = 1;
        mainpanel.SetActive(false);
        gamepanel.SetActive(true);
        Game1Setting();
    }
    void Game1Setting()
    {
        Hideplayers(GameManager.gm.greenplayers);
        Hideplayers(GameManager.gm.blueplayers);
    }
    void Game2Setting()
    {
        Hideplayers(GameManager.gm.blueplayers);
    }
    void Hideplayers(Players[] players)
    {
        for(int i = 0; i < players.Length; i++)
        {
            players[i].gameObject.SetActive(false);
        }
    }
}
