using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    SpriteRenderer rock, paper, scissors;

    void Awake()
    {
        rock = transform.Find("Rock").GetComponent<SpriteRenderer>();
        paper = transform.Find("Paper").GetComponent<SpriteRenderer>();
        scissors = transform.Find("Scissors").GetComponent<SpriteRenderer>();
    }

    public void Rock()
    {
        DisableAll();
        rock.enabled = true;
        GameDirector.Play(Hand.Rock);
    }

    public void Paper()
    {
        DisableAll();
        paper.enabled = true;
        GameDirector.Play(Hand.Paper);
    }

    public void Scissors()
    {
        DisableAll();
        scissors.enabled = true;
        GameDirector.Play(Hand.Scissors);
    }

    void DisableAll()
    {
        rock.enabled = paper.enabled = scissors.enabled = false;
    }
}
