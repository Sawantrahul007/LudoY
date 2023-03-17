using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlayer : Players
{
    RollDice blueHomedice;
    
    // Start is called before the first frame update
    void Start()
    {
        blueHomedice = GetComponentInParent<BlueHome>().rolld;
    }
    private void OnMouseDown()
    {
        if (GameManager.gm.rollingd != null)
        {
            if (!isReadyToMove)
            {
                if(GameManager.gm.rollingd==blueHomedice && GameManager.gm.moveStep == 6)
                {
                    GameManager.gm.bluenoOfPlayerOut++;
                    MakePlayerReadyToMove(pathspoints.bluePoints);
                    GameManager.gm.moveStep = 0;
                    return;
                }
                
            }
            if (GameManager.gm.rollingd == blueHomedice && isReadyToMove && GameManager.gm.isPlayerabletomove)
            {
                
                noofStepsToMove = GameManager.gm.moveStep;
                GameManager.gm.isPlayerabletomove = false;
                MoveSteps(pathspoints.bluePoints);
            }
            
        }
        
    }
}
