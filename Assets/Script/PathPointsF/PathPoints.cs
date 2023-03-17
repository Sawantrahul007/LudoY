using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPoints : MonoBehaviour
{
    public PathObjectsPoint parentPath;
    public List<Players> playerslist = new List<Players>();
    // Start is called before the first frame update
    void Start()
    {
        parentPath = GetComponentInParent<PathObjectsPoint>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool AddPlayers(Players ply)
    {
        if(this.name== "CenterPath") { Completed(ply); }
        if (this.name!= "PathPoints"&& this.name != "PathPoints (8)" && this.name != "PathPoints (13)" && this.name != "PathPoints (21)" && this.name != "PathPoints (26)" && this.name != "PathPoints (34)" && this.name != "PathPoints (39)" && this.name != "PathPoints (47)"&&this.name!= "CenterPath")
        {
            if (playerslist.Count == 1)
            {
                string playerAlredyP = playerslist[0].name;
                string curretP = ply.name;
                curretP = curretP.Substring(0, curretP.Length - 4);
                if (!playerAlredyP.Contains(curretP))
                {
                    playerslist[0].isReadyToMove = false;
                    RevertOnStart(playerslist[0]);
                    playerslist[0].noofStepsAlreadyMove = 0;
                    RemovePlayers(playerslist[0]);
                    playerslist.Add(ply);
                    return false;
                }
            }
        }
        
        addPlayerp(ply);
        return true;
    }
    void RevertOnStart(Players ply)
    {
        playerslist[0].transform.position = parentPath.basePoints[BasePointPosition(ply.name)].transform.position;
    }
    int BasePointPosition(string name)
    {
        if (name.Contains("Blue")) { GameManager.gm.bluenoOfPlayerOut -= 1; }
        else if (name.Contains("Red")) { GameManager.gm.rednoOfPlayerOut -= 1; }
        else if (name.Contains("Green")) { GameManager.gm.greennoOfPlayerOut -= 1; }
        else if (name.Contains("Yellow")) { GameManager.gm.yellownoOfPlayerOut -= 1; }
        for(int i = 0; i < parentPath.basePoints.Length; i++)
        {
            if (parentPath.basePoints[i].name == name)
            {
                return i;
            }
        }
        return -1;
    }
    public void addPlayerp(Players ply)
    {
        playerslist.Add(ply);
    }
    public void RemovePlayers(Players ply)
    {
        if (playerslist.Contains(ply))
        {
            playerslist.Remove(ply);
        }
    }
    private void Completed(Players ply)
    {
        if (name.Contains("Blue")) { GameManager.gm.bluenoOfPlayerComplete += 1; GameManager.gm.bluenoOfPlayerOut -= 1;if (GameManager.gm.bluenoOfPlayerComplete == 4) { ShowCelebration(); } }
        else if (name.Contains("Red")) { GameManager.gm.rednoOfPlayerComplete += 1; GameManager.gm.rednoOfPlayerOut -= 1; if (GameManager.gm.rednoOfPlayerComplete == 4) { ShowCelebration(); } }
        else if (name.Contains("Green")) { GameManager.gm.greennoOfPlayerComplete += 1; GameManager.gm.greennoOfPlayerOut -= 1; if (GameManager.gm.greennoOfPlayerComplete == 4) { ShowCelebration(); } }
        else if (name.Contains("Yellow")) { GameManager.gm.yellownoOfPlayerComplete += 1; GameManager.gm.yellownoOfPlayerOut -= 1; if (GameManager.gm.yellownoOfPlayerComplete == 4) { ShowCelebration(); } }

    }
    public void ShowCelebration()
    {

    }
}
