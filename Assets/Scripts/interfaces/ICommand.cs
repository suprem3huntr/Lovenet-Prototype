using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;

public interface ICommand
{
    public void run(PlayerInterface player);

    public bool isIncomplete();
    public EnumResult addProp<T>(T prop);

    public string getName();

}
