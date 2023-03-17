using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPlayer : Players
{
    RollDice greenHomedice;
    // Start is called before the first frame update
    void Start()
    {
        greenHomedice = GetComponentInParent<GreenHome>().rolld;
    }
    private void OnMouseDown()
    {
        if (GameManager.gm.rollingd != null)
        {
            if (!isReadyToMove)
            {
                if (GameManager.gm.rollingd == greenHomedice && GameManager.gm.moveStep == 6)
                {
                    GameManager.gm.greennoOfPlayerOut++;
                    MakePlayerReadyToMove(pathspoints.greenPoints);
                    GameManager.gm.moveStep = 0;
                    return;
                }

            }
            if (GameManager.gm.rollingd == greenHomedice && isReadyToMove && GameManager.gm.isPlayerabletomove)
            {
                
                noofStepsToMove = GameManager.gm.moveStep;
                GameManager.gm.isPlayerabletomove = false;
                MoveSteps(pathspoints.greenPoints);
            }

        }

    }
    
}
