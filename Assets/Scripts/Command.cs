using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    public bool isIncomplete;
    public abstract void run(PlayerInterface player);
}
