using UnityEngine;
using System.Collections;

public class LevelBlock_NoObstacle : LevelBlock
{
    public Transform row;
    public Transform jump;
    public Transform doublejump;

    public override void Init()
    {
        CreateLoinRow();
        CreateLoinJump();
    }


    void CreateLoinRow()
    {
        int i = Random.Range(1, 2);
        if (i == 1)
        {
            LoinSpawner.Instance.CreateRow(row.position, 1, Random.Range(5, 8));
        }
        else { }
    }

    void CreateLoinJump()
    {
        bool isDouble = CreateLoinDoubleJump();
        CreateLoinSingleJump(isDouble);
    }


    bool CreateLoinDoubleJump()
    {
        int i = Random.Range(1, 3);

        if (i == 1)
        {
            LoinSpawner.Instance.CreateRow(doublejump.position);
            return true;
        }
        else { }

        return false;
    }

    void CreateLoinSingleJump(bool isDouble)
    {
        int i;
        if (isDouble)
            i = Random.Range(1, 2);
        else
            i = Random.Range(1, 3);

        if (i == 1) { }
        else if (i == 2)
        {
            LoinSpawner.Instance.CreateRow(jump.position);
        }
        else if (i == 3)
        {
            LoinSpawner.Instance.CreateArc(jump.position, true);
        }
        else if (i == 4)
        {
            LoinSpawner.Instance.CreateArc(jump.position, false);
        }

    }
}
