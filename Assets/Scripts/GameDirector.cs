using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
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

    public static void Play(Hand playerInput)
    {
        Hand AIInput = AIBehaviour.GetNextPlay();
        Debug.Log("You play " + playerInput + ", AI plays " + AIInput);
        bool aiWin = false;

        if (playerInput == AIInput)
        {
            Debug.Log("Draw");
        }
        else if (playerInput == Hand.Rock && AIInput == Hand.Paper)
        {
            Debug.Log("Lose");
            aiWin = true;
        }
        else if (playerInput == Hand.Paper && AIInput == Hand.Scissors)
        {
            Debug.Log("Lose");
            aiWin = true;
        }
        else if (playerInput == Hand.Scissors && AIInput == Hand.Rock)
        {
            Debug.Log("Lose");
            aiWin = true;
        }
        else if (playerInput == Hand.Rock && AIInput == Hand.Scissors)
        {
            Debug.Log("Win");
            aiWin = false;
        }
        else if (playerInput == Hand.Scissors && AIInput == Hand.Paper)
        {
            Debug.Log("Win");
            aiWin = false;
        }
        else if (playerInput == Hand.Paper && AIInput == Hand.Rock)
        {
            Debug.Log("Win");
            aiWin = false;
        }

        AIBehaviour.Log(new Round
        {
            player = playerInput,
            ai = AIInput,
            aiWin = aiWin
        });
    }
}
