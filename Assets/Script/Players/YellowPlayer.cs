using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPlayer : Players
{
    RollDice yellowHomedice;
    // Start is called before the first frame update
    void Start()
    {
        yellowHomedice = GetComponentInParent<YellowHome>().rolld;
    }
    private void OnMouseDown()
    {
        if (GameManager.gm.rollingd != null)
        {
            if (!isReadyToMove)
            {
                if (GameManager.gm.rollingd == yellowHomedice && GameManager.gm.moveStep == 6)
                {
                    GameManager.gm.yellownoOfPlayerOut++;
                    MakePlayerReadyToMove(pathspoints.yellowPoints);
                    GameManager.gm.moveStep = 0;
                    return;
                }

            }
            if (GameManager.gm.rollingd == yellowHomedice && isReadyToMove && GameManager.gm.isPlayerabletomove)
            {
                
                noofStepsToMove = GameManager.gm.moveStep;
                GameManager.gm.isPlayerabletomove = false;
                MoveSteps(pathspoints.yellowPoints);
            }

        }

    }
    
}
