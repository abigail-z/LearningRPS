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

        if (playerInput == AIInput)
        {
            Debug.Log("Draw");
        }
        else if (playerInput == Hand.Rock && AIInput == Hand.Paper)
        {
            Debug.Log("Lose");
        }
        else if (playerInput == Hand.Paper && AIInput == Hand.Scissors)
        {
            Debug.Log("Lose");
        }
        else if (playerInput == Hand.Scissors && AIInput == Hand.Rock)
        {
            Debug.Log("Lose");
        }
        else if (playerInput == Hand.Rock && AIInput == Hand.Scissors)
        {
            Debug.Log("Win");
        }
        else if (playerInput == Hand.Scissors && AIInput == Hand.Paper)
        {
            Debug.Log("Win");
        }
        else if (playerInput == Hand.Paper && AIInput == Hand.Rock)
        {
            Debug.Log("Win");
        }

        AIBehaviour.Log(playerInput);
    }
}
