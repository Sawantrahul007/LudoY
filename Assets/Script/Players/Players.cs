using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{
    public bool isMove;
    public bool isReadyToMove;
    public int noofStepsToMove;
    public int noofStepsAlreadyMove;
    public PathObjectsPoint pathspoints;
    Coroutine movepl;
    public PathPoints previouspth;
    public PathPoints currentpth;
    private void Awake()
    {
        pathspoints = FindObjectOfType<PathObjectsPoint>();
    }
    public void MoveSteps(PathPoints[] pathp)
    {
       movepl= StartCoroutine(MoveObject(pathp));
    }
    public void MakePlayerReadyToMove(PathPoints[] pathp)
    {
        isReadyToMove = true;
        transform.position = pathp[0].transform.position;
        noofStepsAlreadyMove = 1;
        previouspth = pathp[0];
        currentpth = pathp[0];
        currentpth.AddPlayers(this);
        GameManager.gm.AddPathpoints(currentpth);
        GameManager.gm.isRoll = true;
        GameManager.gm.selfDice = true;
        GameManager.gm.isableToTransfer = false;
    }
    // Start is called before the first frame update
    IEnumerator MoveObject(PathPoints[] pathp)
    {
        GameManager.gm.isableToTransfer = false;
        for (int i = noofStepsAlreadyMove; i < (noofStepsToMove + noofStepsAlreadyMove); i++)
        {
            if (isPathreachlimit(noofStepsToMove, noofStepsAlreadyMove, pathp))
            {
                transform.position = pathp[i].transform.position;
                yield return new WaitForSeconds(0.35f);
            }
            
        }
        if (isPathreachlimit(noofStepsToMove, noofStepsAlreadyMove, pathp))
        {
            noofStepsAlreadyMove += noofStepsToMove;
            
            GameManager.gm.Removepathpoint(previouspth);
            previouspth.RemovePlayers(this);
            currentpth = pathp[noofStepsAlreadyMove - 1];
            
            if (currentpth.AddPlayers(this))
            {
                if (noofStepsAlreadyMove == 57)
                {
                    GameManager.gm.selfDice = true;
                    
                }
                else
                {
                    if (GameManager.gm.moveStep == 6)
                    {
                        Debug.Log("mm");
                        GameManager.gm.selfDice = true;
                        GameManager.gm.isableToTransfer = false;
                    }
                    else
                    {
                        Debug.Log("vv");
                        GameManager.gm.selfDice = false;
                        GameManager.gm.isableToTransfer = true;
                    }
                }
            }
            else
            {
                GameManager.gm.selfDice = true;
            }
            GameManager.gm.moveStep = 0;
            GameManager.gm.AddPathpoints(currentpth);
            previouspth = currentpth;

        }

        GameManager.gm.isPlayerabletomove = true;
        GameManager.gm.RollingDiceManager();
        if (movepl != null)
        {
            StopCoroutine("MoveObject");
        }
    }
    bool isPathreachlimit(int noStepstomove,int noStepsAlreadyMoved,PathPoints[] pathp)
    {
        if (noStepstomove == 0)
        {
            return false;
        }
        if ((pathp.Length - noStepsAlreadyMoved) >= noStepstomove)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
