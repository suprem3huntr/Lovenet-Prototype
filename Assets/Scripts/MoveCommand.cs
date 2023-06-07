using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand: Command
{   
    public EnumDirection dir;

    public override void run(PlayerInterface player) {
        player.MoveBot(dir);
    }
}
