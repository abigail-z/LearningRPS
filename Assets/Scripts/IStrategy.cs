using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStrategy
{
    void Log(Hand lastPlay);

    Hand GetNextPlay();
}
