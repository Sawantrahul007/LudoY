using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlayer : Players
{
    RollDice redHomedice;
    // Start is called before the first frame update
    void Start()
    {
        redHomedice = GetComponentInParent<RedHome>().rolld;
    }
    private void OnMouseDown()
    {
        if (GameManager.gm.rollingd != null)
        {
            if (!isReadyToMove)
            {
                if (GameManager.gm.rollingd == redHomedice && GameManager.gm.moveStep == 6)
                {
                    GameManager.gm.rednoOfPlayerOut++;
                    MakePlayerReadyToMove(pathspoints.redPoints);
                    GameManager.gm.moveStep = 0;
                    return;
                }

            }
            if (GameManager.gm.rollingd == redHomedice && isReadyToMove && GameManager.gm.isPlayerabletomove)
            {
                
                noofStepsToMove = GameManager.gm.moveStep;
                GameManager.gm.isPlayerabletomove = false;
                MoveSteps(pathspoints.redPoints);
            }

        }

    }
}
