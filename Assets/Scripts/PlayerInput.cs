using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public void Rock()
    {
        GameDirector.Play(Hand.Rock);
    }

    public void Paper()
    {
        GameDirector.Play(Hand.Paper);
    }

    public void Scissors()
    {
        GameDirector.Play(Hand.Scissors);
    }
}
