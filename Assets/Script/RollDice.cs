using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollDice : MonoBehaviour
{
    [SerializeField] Sprite[] spritesno;
    [SerializeField] SpriteRenderer spriteholder;
    [SerializeField] int no;
    public int outpic;
    PathObjectsPoint pathObjectParent;
    PathPoints[] pathPointToMove;
    Players[] currentPlayerPice;
    Coroutine moveplx;
    Players outPlayerpic;
    Coroutine generateCortine;
    private void Awake()
    {
        pathObjectParent = FindObjectOfType<PathObjectsPoint>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //isRoll = true;
    }
    private void OnMouseDown()
    {

        generateCortine = StartCoroutine(RollingDice());
    }
    public void MouseRoll()
    {
        Debug.Log("MouseRoll");
        generateCortine = StartCoroutine(RollingDice());

    }
    IEnumerator RollingDice()
    {

        if (GameManager.gm.isRoll)
        {
            Debug.Log("lom");
            GameManager.gm.isRoll = false;
            GameManager.gm.rollingd = this;
            no = Random.Range(0, 6);
            spriteholder.sprite = spritesno[no];
            no += 1;
            GameManager.gm.moveStep = no;
            int numberGot = GameManager.gm.moveStep;
            GameManager.gm.isableToTransfer = false;
            if (PlayerCanNotMove())
            {
                yield return new WaitForSeconds(0.5f);
                if (GameManager.gm.moveStep != 6) { GameManager.gm.isableToTransfer = true; }
                else { GameManager.gm.selfDice = true; }
            }
            else
            {
                if (GameManager.gm.rollingd == GameManager.gm.manageRollingDice[0]) { outpic = GameManager.gm.yellownoOfPlayerOut; }
                else if (GameManager.gm.rollingd == GameManager.gm.manageRollingDice[1]) { outpic = GameManager.gm.greennoOfPlayerOut; }
                else if (GameManager.gm.rollingd == GameManager.gm.manageRollingDice[2]) { outpic = GameManager.gm.rednoOfPlayerOut; }
                else if (GameManager.gm.rollingd == GameManager.gm.manageRollingDice[3]) { outpic = GameManager.gm.bluenoOfPlayerOut; }
                if (outpic == 0 && numberGot != 6)
                {

                    yield return new WaitForSeconds(1f);
                    GameManager.gm.isableToTransfer = true;
                }
                else
                {
                    if (outpic == 0 && numberGot == 6)
                    {
                        MakePlayerReadyToMove(0);
                    }
                    else if (outpic == 1 && numberGot != 6 && GameManager.gm.isPlayerabletomove)
                    {
                        GameManager.gm.isPlayerabletomove = false;
                        int playerPicePosition = Checkout();
                        if (playerPicePosition >= 0)
                        {
                            GameManager.gm.isPlayerabletomove = false;
                            moveplx = StartCoroutine(MoveObject(playerPicePosition));
                        }
                        else
                        {
                            yield return new WaitForSeconds(1f);
                            if (GameManager.gm.moveStep != 6) { GameManager.gm.isableToTransfer = true; }
                            else { GameManager.gm.selfDice = true; }
                        }

                    }
                    else if (GameManager.gm.totalplayercanplay == 1 && GameManager.gm.rollingd == GameManager.gm.manageRollingDice[2])
                    {
                        if (numberGot == 6 && outpic < 4)
                        {
                            MakePlayerReadyToMove(OutPlayerToMove());
                        }
                        else
                        {
                            int playerPicePosition = Checkout();
                            if (playerPicePosition >= 0)
                            {
                                GameManager.gm.isPlayerabletomove = false;
                                moveplx = StartCoroutine(MoveObject(playerPicePosition));
                            }
                            else
                            {
                                yield return new WaitForSeconds(1f);
                                if (GameManager.gm.moveStep != 6) { GameManager.gm.isableToTransfer = true; }
                                else { GameManager.gm.selfDice = true; }
                            }
                        }
                    }
                    //chng
                    else if((GameManager.gm.totalplayercanplay == 7 || GameManager.gm.totalplayercanplay == 8) && GameManager.gm.rollingd == GameManager.gm.manageRollingDice[1])
                    {
                        Debug.Log("ysbdx");
                        if (numberGot == 6 && outpic < 4)
                        {
                            MakePlayerReadyToMove(OutPlayerToMove1());
                        }
                        else
                        {
                            int playerPicePosition = Checkout();
                            if (playerPicePosition >= 0)
                            {
                                GameManager.gm.isPlayerabletomove = false;
                                moveplx = StartCoroutine(MoveObject(playerPicePosition));
                            }
                            else
                            {
                                yield return new WaitForSeconds(1f);
                                if (GameManager.gm.moveStep != 6) { GameManager.gm.isableToTransfer = true; }
                                else { GameManager.gm.selfDice = true; }
                            }
                        }
                    }
                    else if ((GameManager.gm.totalplayercanplay == 7 || GameManager.gm.totalplayercanplay == 8) && GameManager.gm.rollingd == GameManager.gm.manageRollingDice[2])
                    {
                        Debug.Log("hdjjfj");
                        if (numberGot == 6 && outpic < 4)
                        {
                            MakePlayerReadyToMove(OutPlayerToMove2());
                        }
                        else
                        {
                            int playerPicePosition = Checkout();
                            if (playerPicePosition >= 0)
                            {
                                GameManager.gm.isPlayerabletomove = false;
                                moveplx = StartCoroutine(MoveObject(playerPicePosition));
                            }
                            else
                            {
                                yield return new WaitForSeconds(1f);
                                if (GameManager.gm.moveStep != 6) { GameManager.gm.isableToTransfer = true; }
                                else { GameManager.gm.selfDice = true; }
                            }
                        }
                    }
                    else if ((GameManager.gm.totalplayercanplay == 7 || GameManager.gm.totalplayercanplay == 8) && GameManager.gm.rollingd == GameManager.gm.manageRollingDice[3])
                    {
                        Debug.Log("hdjjfj");
                        if (numberGot == 6 && outpic < 4)
                        {
                            MakePlayerReadyToMove(OutPlayerToMove3());
                        }
                        else
                        {
                            int playerPicePosition = Checkout();
                            if (playerPicePosition >= 0)
                            {
                                GameManager.gm.isPlayerabletomove = false;
                                moveplx = StartCoroutine(MoveObject(playerPicePosition));
                            }
                            else
                            {
                                yield return new WaitForSeconds(1f);
                                if (GameManager.gm.moveStep != 6) { GameManager.gm.isableToTransfer = true; }
                                else { GameManager.gm.selfDice = true; }
                            }
                        }
                    }
                    //chng
                    else
                    {
                        if (Checkout() < 0)
                        {
                            yield return new WaitForSeconds(1f);
                            if (GameManager.gm.moveStep != 6) { GameManager.gm.isableToTransfer = true; }
                            else { GameManager.gm.selfDice = true; }
                        }
                    }
                }
            }
            //yield return new WaitForSeconds(0.5f);
            GameManager.gm.RollingDiceManager();
            if (generateCortine != null)
            {
                StopCoroutine(RollingDice());
            }
        }
    }


        //public void NextMove()
        //{
        //    StartCoroutine(MoveObject());
        //}
        //IEnumerator MoveObject()
        //{
        //    yield return new WaitForSeconds(0.5f);
        //    GameManager.gm.RollingDiceManager();
        //}
        //public void WaitF()
        //{
        //    StartCoroutine(MoveD());
        //}
        //IEnumerator MoveD()
        //{
        //    yield return new WaitForSeconds(0.5f);
        //    if (GameManager.gm.moveStep != 6) { GameManager.gm.isableToTransfer = true; }
        //    else { GameManager.gm.selfDice = true; }

        //}
        //public void WaitX()
        //{
        //    StartCoroutine(MoveM());
        //}
        //IEnumerator MoveM()
        //{
        //    yield return new WaitForSeconds(0.5f);
        //    GameManager.gm.isableToTransfer = true;

        //}
        //chng
        int OutPlayerToMove1()
        {
            for (int i = 0; i < 4; i++)
            {
                if (!GameManager.gm.greenplayers[i].isReadyToMove)
                {
                    return i;
                }
            }
            return 0;
        }
    int OutPlayerToMove2()
    {
            for (int i = 0; i < 4; i++)
            {
                if (!GameManager.gm.redplayers[i].isReadyToMove)
                {
                    return i;
                }
            }
            return 0;
    }
    int OutPlayerToMove3()
    {
        for (int i = 0; i < 4; i++)
        {
            if (!GameManager.gm.blueplayers[i].isReadyToMove)
            {
                return i;
            }
        }
        return 0;
    }
    //chng
    int OutPlayerToMove()
       {
            for (int i = 0; i < 4; i++)
            {
                if (!GameManager.gm.redplayers[i].isReadyToMove)
                {
                    return i;
                }
            }
            return 0;
       }

       int Checkout()
        {
            if (GameManager.gm.rollingd == GameManager.gm.manageRollingDice[0]) { currentPlayerPice = GameManager.gm.yellowplayers; pathPointToMove = pathObjectParent.yellowPoints; }
            else if (GameManager.gm.rollingd == GameManager.gm.manageRollingDice[1]) { currentPlayerPice = GameManager.gm.greenplayers; pathPointToMove = pathObjectParent.greenPoints; }
            else if (GameManager.gm.rollingd == GameManager.gm.manageRollingDice[2]) { currentPlayerPice = GameManager.gm.redplayers; pathPointToMove = pathObjectParent.redPoints; }
            else if (GameManager.gm.rollingd == GameManager.gm.manageRollingDice[3]) { currentPlayerPice = GameManager.gm.blueplayers; pathPointToMove = pathObjectParent.bluePoints; }
            for (int i = 0; i < currentPlayerPice.Length; i++)
            {
                if (currentPlayerPice[i].isReadyToMove && isPathreachlimit(GameManager.gm.moveStep, currentPlayerPice[i].noofStepsAlreadyMove, pathPointToMove))
                {
                    return i;
                }
            }
            return -1;
        }
       public bool PlayerCanNotMove()
        {
            if (outpic > 0)
            {
                bool canNotMove = false;
                if (GameManager.gm.rollingd == GameManager.gm.manageRollingDice[0]) { currentPlayerPice = GameManager.gm.yellowplayers; pathPointToMove = pathObjectParent.yellowPoints; }
                else if (GameManager.gm.rollingd == GameManager.gm.manageRollingDice[1]) { currentPlayerPice = GameManager.gm.greenplayers; pathPointToMove = pathObjectParent.greenPoints; }
                else if (GameManager.gm.rollingd == GameManager.gm.manageRollingDice[2]) { currentPlayerPice = GameManager.gm.redplayers; pathPointToMove = pathObjectParent.redPoints; }
                else if (GameManager.gm.rollingd == GameManager.gm.manageRollingDice[3]) { currentPlayerPice = GameManager.gm.blueplayers; pathPointToMove = pathObjectParent.bluePoints; }
                for (int i = 0; i < currentPlayerPice.Length; i++)
                {
                    if (currentPlayerPice[i].isReadyToMove)
                    {
                        if (isPathreachlimit(GameManager.gm.moveStep, currentPlayerPice[i].noofStepsAlreadyMove, pathPointToMove))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (!canNotMove) { canNotMove = true; }
                    }
                }
                if (canNotMove)
                {
                    return true;
                }
            }
            return false;
        }
        public bool isPathreachlimit(int noStepstomove, int noStepsAlreadyMoved, PathPoints[] pathp)
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
        public void MakePlayerReadyToMove(int potion)
        {
            if (GameManager.gm.rollingd == GameManager.gm.manageRollingDice[0]) { outPlayerpic = GameManager.gm.yellowplayers[potion]; pathPointToMove = pathObjectParent.yellowPoints; GameManager.gm.yellownoOfPlayerOut += 1; }
            else if (GameManager.gm.rollingd == GameManager.gm.manageRollingDice[1]) { outPlayerpic = GameManager.gm.greenplayers[potion]; pathPointToMove = pathObjectParent.greenPoints; GameManager.gm.greennoOfPlayerOut += 1; }
            else if (GameManager.gm.rollingd == GameManager.gm.manageRollingDice[2]) { outPlayerpic = GameManager.gm.redplayers[potion]; pathPointToMove = pathObjectParent.redPoints; GameManager.gm.rednoOfPlayerOut += 1; }
            else if (GameManager.gm.rollingd == GameManager.gm.manageRollingDice[3]) { outPlayerpic = GameManager.gm.blueplayers[potion]; pathPointToMove = pathObjectParent.bluePoints; GameManager.gm.bluenoOfPlayerOut += 1; }
            outPlayerpic.isReadyToMove = true;
            outPlayerpic.transform.position = pathPointToMove[0].transform.position;
            outPlayerpic.noofStepsAlreadyMove = 1;
            outPlayerpic.previouspth = pathPointToMove[0];
            outPlayerpic.currentpth = pathPointToMove[0];
            outPlayerpic.currentpth.AddPlayers(outPlayerpic);
            GameManager.gm.AddPathpoints(outPlayerpic.currentpth);
            GameManager.gm.isRoll = true;
            GameManager.gm.selfDice = true;
            GameManager.gm.isableToTransfer = false;
            GameManager.gm.moveStep = 0;
            GameManager.gm.SelfRoll();
        }
        IEnumerator MoveObject(int movepl)
        {
            if (GameManager.gm.rollingd == GameManager.gm.manageRollingDice[0]) { outPlayerpic = GameManager.gm.yellowplayers[movepl]; pathPointToMove = pathObjectParent.yellowPoints; }
            else if (GameManager.gm.rollingd == GameManager.gm.manageRollingDice[1]) { outPlayerpic = GameManager.gm.greenplayers[movepl]; pathPointToMove = pathObjectParent.greenPoints; }
            else if (GameManager.gm.rollingd == GameManager.gm.manageRollingDice[2]) { outPlayerpic = GameManager.gm.redplayers[movepl]; pathPointToMove = pathObjectParent.redPoints; }
            else if (GameManager.gm.rollingd == GameManager.gm.manageRollingDice[3]) { outPlayerpic = GameManager.gm.blueplayers[movepl]; pathPointToMove = pathObjectParent.bluePoints; }
            GameManager.gm.isableToTransfer = false;
            int noofStepsToMove = GameManager.gm.moveStep;
            for (int i = outPlayerpic.noofStepsAlreadyMove; i < (noofStepsToMove + outPlayerpic.noofStepsAlreadyMove); i++)
            {
                if (isPathreachlimit(noofStepsToMove, outPlayerpic.noofStepsAlreadyMove, pathPointToMove))
                {
                    outPlayerpic.transform.position = pathPointToMove[i].transform.position;
                    yield return new WaitForSeconds(0.35f);
                }

            }
            //GameManager.gm.moveStep = 0;
            if (isPathreachlimit(noofStepsToMove, outPlayerpic.noofStepsAlreadyMove, pathPointToMove))
            {
                outPlayerpic.noofStepsAlreadyMove += noofStepsToMove;

                GameManager.gm.Removepathpoint(outPlayerpic.previouspth);
                outPlayerpic.previouspth.RemovePlayers(outPlayerpic);
                outPlayerpic.currentpth = pathPointToMove[outPlayerpic.noofStepsAlreadyMove - 1];

                if (outPlayerpic.currentpth.AddPlayers(outPlayerpic))
                {
                    if (outPlayerpic.noofStepsAlreadyMove == 57)
                    {
                        GameManager.gm.selfDice = true;

                    }
                    else
                    {
                        if (GameManager.gm.moveStep != 6)
                        {
                            Debug.Log("mm");
                            GameManager.gm.selfDice = false;
                            GameManager.gm.isableToTransfer = true;
                        }
                        else
                        {
                            Debug.Log("vv");
                            GameManager.gm.selfDice = true;
                            GameManager.gm.isableToTransfer = false;
                        }
                    }
                }
                else
                {
                    GameManager.gm.selfDice = true;
                }
                GameManager.gm.moveStep = 0;
                GameManager.gm.AddPathpoints(outPlayerpic.currentpth);
                outPlayerpic.previouspth = outPlayerpic.currentpth;

            }

            GameManager.gm.isPlayerabletomove = true;
            GameManager.gm.RollingDiceManager();
            if (moveplx != null)
            {
                StopCoroutine("MoveObject");
            }
        }
    
}
