using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BayesianStrategy : IStrategy
{
    readonly int size;
    readonly Queue<(Hand, bool)> history;

    public BayesianStrategy(int maxQueueSize)
    {
        size = maxQueueSize;
        history = new Queue<(Hand, bool)>();
    }

    public Hand GetNextPlay()
    {
        float winProb = WinProbability() + 0.1f;

        // probability of ai winning when playing rock
        float winGivenRock = HandWinProbability(Hand.Rock) * HandProbability(Hand.Rock) / winProb;
        Debug.Log(winGivenRock);

        return Hand.Rock;
    }

    public float HandProbability(Hand hand)
    {
        if (history.Count <= 0)
        {
            return 0;
        }

        float count = 0;
        foreach ((Hand, bool) round in history)
        {
            if (round.Item1 == hand)
            {
                count += 1;
            }
        }

        return count / history.Count;
    }

    public float HandWinProbability(Hand hand)
    {
        float winCount = 0;
        float count = 0;
        foreach ((Hand, bool) round in history)
        {
            if (round.Item1 == hand)
            {
                winCount += 1;
            }
            count += 1;
        }

        if (winCount <= 0)
        {
            return 0;
        }

        return winCount / count;
    }

    public float WinProbability()
    {
        if (history.Count <= 0)
        {
            return 0;
        }

        float count = 0;
        foreach ((Hand, bool) round in history)
        {
            if (round.Item2)
            {
                count += 1;
            }
        }

        return count / history.Count;
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
