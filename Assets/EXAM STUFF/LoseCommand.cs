using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCommand : LevelCommand
{
    public void Execute()
    {
        GameManagement.winLose--;
    }

    public void Undo()
    {
        GameManagement.winLose = 0;
    }


}
