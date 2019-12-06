using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehaviour : MonoBehaviour
{
    // instance vars
    public int gramSize;
    private IStrategy strategy;
    SpriteRenderer rock, paper, scissors;

    // static vars
    private static AIBehaviour instance;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            rock = transform.Find("Rock").GetComponent<SpriteRenderer>();
            paper = transform.Find("Paper").GetComponent<SpriteRenderer>();
            scissors = transform.Find("Scissors").GetComponent<SpriteRenderer>();
        }
    }

    void Start()
    {
        strategy = new NGramStrategy(gramSize);
    }

    public static Hand GetNextPlay()
    {
        Hand hand = instance.strategy.GetNextPlay();

        instance.ShowHand(hand);

        return hand;
    }

    public static void Log(Round round)
    {
        instance.strategy.Log(round);
    }

    public void ShowHand(Hand hand)
    {
        rock.enabled = paper.enabled = scissors.enabled = false;

        switch (hand)
        {
            case Hand.Rock:
                rock.enabled = true;
                break;
            case Hand.Paper:
                paper.enabled = true;
                break;
            case Hand.Scissors:
                scissors.enabled = true;
                break;
        }
    }
}
