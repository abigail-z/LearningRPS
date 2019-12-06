using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIStrategy
{
    public abstract void Log(Hand lastPlay);

    public abstract Hand GetNextPlay();
}
