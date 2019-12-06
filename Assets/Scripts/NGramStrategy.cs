using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NGramStrategy : IStrategy
{
    private string history;
    private readonly int size;

    public NGramStrategy(int gramSize)
    {
        size = gramSize;
        history = "";
    }

    // store the player's input in the history string
    public void Log(Hand lastPlay)
    {
        switch (lastPlay)
        {
            case Hand.Rock:
                history += "r";
                break;
            case Hand.Paper:
                history += "p";
                break;
            case Hand.Scissors:
                history += "s";
                break;
        }
    }

    // predict the best next play using n-grams
    public Hand GetNextPlay()
    {
        // get history string from instance
        string history = this.history;
        // if there's not enough data, pick completely randomly
        if (history.Length < size)
        {

            return ChooseRandomFromSelection(new Hand[] { Hand.Rock, Hand.Paper, Hand.Scissors });
        }

        // get last inputs from end of history - this is the n-gram
        string gram = history.Substring(history.Length - size);
        // remove the gram from the history
        history = history.Remove(history.Length - size);

        // counts of each occurence
        int rockCount = 0;
        int papeCount = 0;
        int scisCount = 0;

        // find every instance of the gram in history
        int index = history.IndexOf(gram);
        while (index != -1)
        {
            // delete history up until after next occurence of the gram
            history = history.Remove(0, index + size);

            // if there is no character after the gram, quit
            if (history.Length == 0)
            {
                break;
            }

            // get the next character after the gram and update how many times it has occurred
            char nextChar = history[0];
            switch (nextChar)
            {
                case 'r':
                    rockCount += 1;
                    break;
                case 'p':
                    papeCount += 1;
                    break;
                case 's':
                    scisCount += 1;
                    break;
            }

            // prepare condition for next loop
            index = history.IndexOf(gram);
        }

        // now to calculate which hand to play
        return ChooseHandGivenOccurences(rockCount, papeCount, scisCount);
    }

    // return the best hand given the predicted frequency
    static Hand ChooseHandGivenOccurences(int rockCount, int papeCount, int scisCount)
    {
        // if one hand clearly wins, play its counter
        if (rockCount > papeCount && rockCount > scisCount)
        {
            // played rock
            return Hand.Paper;
        }

        if (papeCount > rockCount && papeCount > scisCount)
        {
            // played paper
            return Hand.Scissors;
        }

        if (scisCount > rockCount && scisCount > papeCount)
        {
            // played scissors
            return Hand.Rock;
        }

        // if two hands tie, choose randomly between the two counters
        if (rockCount == papeCount && rockCount > scisCount)
        {
            // played rock & paper
            return ChooseRandomFromSelection(new Hand[] { Hand.Paper, Hand.Scissors });
        }

        if (papeCount == scisCount && papeCount > rockCount)
        {
            // played paper & scissors
            return ChooseRandomFromSelection(new Hand[] { Hand.Scissors, Hand.Rock });
        }

        if (scisCount == rockCount && scisCount > papeCount)
        {
            // played scissors & rock
            return ChooseRandomFromSelection(new Hand[] { Hand.Rock, Hand.Paper });
        }

        // if all counts are the same, pick completely randomly
        return ChooseRandomFromSelection(new Hand[] { Hand.Rock, Hand.Paper, Hand.Scissors });
    }

    // return a random hand from the given selection
    static Hand ChooseRandomFromSelection(Hand[] choices)
    {
        return choices[Random.Range(0, choices.Length)];
    }
}
