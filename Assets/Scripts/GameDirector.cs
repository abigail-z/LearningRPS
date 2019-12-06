using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    public Text scoreBox;
    private int score;
    private static GameDirector instance;

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
        score = 0;
    }

    public static void Play(Hand playerInput)
    {
        Hand AIInput = AIBehaviour.GetNextPlay();
        Result playerResult;

        if (playerInput == Hand.Rock && AIInput == Hand.Paper)
        {
            instance.score -= 1;
            playerResult = Result.Lose;
        }
        else if (playerInput == Hand.Paper && AIInput == Hand.Scissors)
        {
            instance.score -= 1;
            playerResult = Result.Lose;
        }
        else if (playerInput == Hand.Scissors && AIInput == Hand.Rock)
        {
            instance.score -= 1;
            playerResult = Result.Lose;
        }
        else if (playerInput == Hand.Rock && AIInput == Hand.Scissors)
        {
            instance.score += 1;
            playerResult = Result.Win;
        }
        else if (playerInput == Hand.Scissors && AIInput == Hand.Paper)
        {
            instance.score += 1;
            playerResult = Result.Win;
        }
        else if (playerInput == Hand.Paper && AIInput == Hand.Rock)
        {
            instance.score += 1;
            playerResult = Result.Win;
        }
        else
        {
            playerResult = Result.Draw;
        }

        instance.scoreBox.text = "Score: " + instance.score;

        AIBehaviour.Log(new Round
        {
            player = playerInput,
            ai = AIInput,
            playerResult = playerResult
        });
    }
}
