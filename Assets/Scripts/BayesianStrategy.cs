using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BayesianStrategy : IStrategy
{
    public Hand GetNextPlay()
    {
        return Hand.Rock;
    }

    public void Log(Hand lastPlay)
    {
        // todo
    }
}
