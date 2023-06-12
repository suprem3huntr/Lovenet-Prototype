using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveCommand: Command
{   
    public EnumDirection dir;

    public override void run(PlayerInterface player) {
        player.MoveBot(dir);
    }
    public override EnumResult addProp<T> (T prop)
    {
        switch (prop)
        {
            case EnumDirection d:
                dir=(EnumDirection)Convert.ChangeType(prop,typeof(EnumDirection));
                return EnumResult.OK;
            default:
                return EnumResult.ERR;
        }
        
    }
}
