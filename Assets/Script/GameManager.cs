using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public RollDice rollingd;
    public int moveStep;
    public bool isPlayerabletomove;
    public bool isRoll;
    public bool isableToTransfer;
    public bool selfDice;
    public int bluenoOfPlayerOut;
    public int rednoOfPlayerOut;
    public int greennoOfPlayerOut;
    public int yellownoOfPlayerOut;
    public int bluenoOfPlayerComplete;
    public int rednoOfPlayerComplete;
    public int greennoOfPlayerComplete;
    public int yellownoOfPlayerComplete;
    public RollDice[] manageRollingDice;
    List<PathPoints> playerOnPathpoint = new List<PathPoints>();
    public Players[] blueplayers;
    public Players[] redplayers;
    public Players[] greenplayers;
    public Players[] yellowplayers;
    public int totalplayercanplay;
    private void Awake()
    {
        
        selfDice = false;
        isPlayerabletomove = true;
        gm = this;
        isRoll = true;
        isableToTransfer = false;
    }
    public void RollingDiceManager()
    {
        
        if (GameManager.gm.isableToTransfer)
        {
            GameManager.gm.isRoll = true;
            if (GameManager.gm.moveStep != 6)
            {
                ShiftPos();
            }
            
        }
        else
        {
            if (GameManager.gm.selfDice)
            {
                GameManager.gm.selfDice = false;
                GameManager.gm.isRoll = true;
                GameManager.gm.SelfRoll();
            }
        }
    }
    public void AddPathpoints(PathPoints pathp)
    {
        playerOnPathpoint.Add(pathp);
    }
    public void Removepathpoint(PathPoints pathp)
    {
        if (playerOnPathpoint.Contains(pathp))
        {
            playerOnPathpoint.Remove(pathp);
        }
        else
        {
            Debug.Log("gg");
        }
    }
    public void SelfRoll()
    {//chng
        if((GameManager.gm.totalplayercanplay == 7 || GameManager.gm.totalplayercanplay == 8) && GameManager.gm.rollingd == GameManager.gm.manageRollingDice[1])
        {
            Invoke("rolledx1", 0.6f);
        }
        else if((GameManager.gm.totalplayercanplay == 7 || GameManager.gm.totalplayercanplay == 8) && GameManager.gm.rollingd == GameManager.gm.manageRollingDice[2])
        {
            Invoke("rolledx2", 0.6f);
        }
        else if ((GameManager.gm.totalplayercanplay == 7 || GameManager.gm.totalplayercanplay == 8) && GameManager.gm.rollingd == GameManager.gm.manageRollingDice[3])
        {
            Invoke("rolledx3", 0.6f);
        }
        //chng
        if (GameManager.gm.totalplayercanplay==1 && GameManager.gm.rollingd == GameManager.gm.manageRollingDice[2])
        {
            Invoke("rolled", 0.6f);
        }
    }
    void rolled()
    {
        //Debug.Log("ll");
        GameManager.gm.manageRollingDice[2].MouseRoll();
    }
    //chng
    void rolledx1()
    {
        Debug.Log("ll");
        GameManager.gm.manageRollingDice[1].MouseRoll();

    }
    void rolledx2()
    {
        Debug.Log("rr");
        GameManager.gm.manageRollingDice[2].MouseRoll();
    }
    void rolledx3()
    {
        Debug.Log("rr");
        GameManager.gm.manageRollingDice[3].MouseRoll();
    }
    //chng
    void ShiftPos()
    {
        int nextdice;
        if (totalplayercanplay == 1)
        {
            if (GameManager.gm.rollingd == GameManager.gm.manageRollingDice[0])
            {
                GameManager.gm.manageRollingDice[0].gameObject.SetActive(false);
                GameManager.gm.manageRollingDice[2].gameObject.SetActive(true);
                PassOut(0);
                Debug.Log("bb");
                GameManager.gm.manageRollingDice[2].MouseRoll();
            }
            else
            {
                GameManager.gm.manageRollingDice[0].gameObject.SetActive(true);
                GameManager.gm.manageRollingDice[2].gameObject.SetActive(false);
                PassOut(2);
            }
        }
        else if (totalplayercanplay == 2)
        {
            if (GameManager.gm.rollingd == GameManager.gm.manageRollingDice[0])
            {
                GameManager.gm.manageRollingDice[0].gameObject.SetActive(false);
                GameManager.gm.manageRollingDice[2].gameObject.SetActive(true);
                PassOut(0);
            }
            else
            {
                GameManager.gm.manageRollingDice[0].gameObject.SetActive(true);
                GameManager.gm.manageRollingDice[2].gameObject.SetActive(false);
                PassOut(2);
            }
        }
        else if (totalplayercanplay == 3)
        {
            for (int i = 0; i < 3; i++)
            {
                if (i == 2)
                {
                    nextdice = 0;
                }
                else
                {
                    nextdice = i + 1;
                }
                i = PassOut(i);
                if (GameManager.gm.rollingd == GameManager.gm.manageRollingDice[i])
                {
                    GameManager.gm.manageRollingDice[i].gameObject.SetActive(false);
                    GameManager.gm.manageRollingDice[nextdice].gameObject.SetActive(true);
                }
            }
        }else if (totalplayercanplay == 7)
        {
            
            if (GameManager.gm.rollingd == GameManager.gm.manageRollingDice[0])
            {
                Debug.Log("RRR");
                GameManager.gm.manageRollingDice[0].gameObject.SetActive(false);
                GameManager.gm.manageRollingDice[1].gameObject.SetActive(true);
                GameManager.gm.manageRollingDice[1].MouseRoll();
            }
            
            else if (GameManager.gm.rollingd == GameManager.gm.manageRollingDice[1])
            {
                Debug.Log("RRR");
                GameManager.gm.manageRollingDice[1].gameObject.SetActive(false);
                GameManager.gm.manageRollingDice[2].gameObject.SetActive(true);
                GameManager.gm.manageRollingDice[2].MouseRoll();
            }
            else if (GameManager.gm.rollingd == GameManager.gm.manageRollingDice[2])
            {
                Debug.Log("RRR");
                GameManager.gm.manageRollingDice[2].gameObject.SetActive(false);
                GameManager.gm.manageRollingDice[0].gameObject.SetActive(true);
                //GameManager.gm.manageRollingDice[2].MouseRoll();
            }

        }
        else if (totalplayercanplay == 8)
        {

            if (GameManager.gm.rollingd == GameManager.gm.manageRollingDice[0])
            {
                Debug.Log("RRR");
                GameManager.gm.manageRollingDice[0].gameObject.SetActive(false);
                GameManager.gm.manageRollingDice[1].gameObject.SetActive(true);
                GameManager.gm.manageRollingDice[1].MouseRoll();
            }

            else if (GameManager.gm.rollingd == GameManager.gm.manageRollingDice[1])
            {
                Debug.Log("RRR");
                GameManager.gm.manageRollingDice[1].gameObject.SetActive(false);
                GameManager.gm.manageRollingDice[2].gameObject.SetActive(true);
                GameManager.gm.manageRollingDice[2].MouseRoll();
            }
            else if (GameManager.gm.rollingd == GameManager.gm.manageRollingDice[2])
            {
                Debug.Log("RRR");
                GameManager.gm.manageRollingDice[2].gameObject.SetActive(false);
                GameManager.gm.manageRollingDice[3].gameObject.SetActive(true);
                GameManager.gm.manageRollingDice[3].MouseRoll();
            }
            else if (GameManager.gm.rollingd == GameManager.gm.manageRollingDice[3])
            {
                Debug.Log("RRR");
                GameManager.gm.manageRollingDice[3].gameObject.SetActive(false);
                GameManager.gm.manageRollingDice[0].gameObject.SetActive(true);
                //GameManager.gm.manageRollingDice[0].MouseRoll();
            }

        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                if (i == 3)
                {
                    nextdice = 0;
                }
                else
                {
                    nextdice = i + 1;
                }
                i = PassOut(i);
                if (GameManager.gm.rollingd == GameManager.gm.manageRollingDice[i])
                {
                    GameManager.gm.manageRollingDice[i].gameObject.SetActive(false);
                    GameManager.gm.manageRollingDice[nextdice].gameObject.SetActive(true);
                }
            }
        }
    }
    int PassOut(int i)
    {
        if (i == 0) { if (GameManager.gm.yellownoOfPlayerComplete == 4) { return i + 1; } }
        else if (i == 1) { if (GameManager.gm.yellownoOfPlayerComplete == 4) { return i + 1; } }
        else if (i == 2) { if (GameManager.gm.yellownoOfPlayerComplete == 4) { return i + 1; } }
        else if (i == 3) { if (GameManager.gm.yellownoOfPlayerComplete == 4) { return i + 1; } }
        return i;
    }
    public void Qut()
    {
        Application.Quit();
    }
}
