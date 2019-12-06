using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BayesianStrategy : IStrategy
{
    readonly int size;
    Queue<Hand> history;

    public BayesianStrategy(int maxQueueSize)
    {
        size = maxQueueSize;
        history = new Queue<Hand>();
    }

    public Hand GetNextPlay()
    {
        return Hand.Rock;
    }

    public void Log(Hand lastPlay)
    {
        history.Enqueue(lastPlay);
        while (history.Count > size)
        {
            history.Dequeue();
        }
    }
}
