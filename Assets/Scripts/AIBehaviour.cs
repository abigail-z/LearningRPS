using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehaviour : MonoBehaviour
{
    // instance vars
    public int gramSize;
    private IStrategy strategy;

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
        }
    }

    void Start()
    {
        strategy = new NGramStrategy(gramSize);
    }

    public static Hand GetNextPlay()
    {
        return instance.strategy.GetNextPlay();
    }

    public static void Log(Hand playerInput)
    {
        instance.strategy.Log(playerInput);
    }
}
