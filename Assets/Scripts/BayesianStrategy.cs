using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BayesianStrategy : IStrategy
{
    readonly int size;
    Queue<(Hand, bool)> history;

    public BayesianStrategy(int maxQueueSize)
    {
        size = maxQueueSize;
        history = new Queue<(Hand, bool)>();
    }

    public Hand GetNextPlay()
    {
        // probability of ai winning when playing rock
        float rockWin;

        return Hand.Rock;
    }

    public void Log(Round round)
    {
        history.Enqueue((round.ai, round.aiWin));
        while (history.Count > size)
        {
            history.Dequeue();
        }
    }
}
