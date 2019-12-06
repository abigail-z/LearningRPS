using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStrategy
{
    void Log(Round round);

    Hand GetNextPlay();
}

public struct Round
{
    public Hand player;
    public Hand ai;
    public Result playerResult;
}

public enum Result
{
    Win, Lose, Draw
}
