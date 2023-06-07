using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandBuilder
{
    private Command pseudoCommand = null;
    public void MakeMoveCommand() {
        this.pseudoCommand = new MoveCommand();
    }

    public bool noCommand() {
        return pseudoCommand == null;
    }

    public EnumResult provideDir(EnumDirection dir) {
        try{
            MoveCommand temp = (MoveCommand) pseudoCommand;
            temp.dir = dir;
            pseudoCommand = temp;
        } catch {
            return EnumResult.ERR;
        }
        return EnumResult.OK;
    }

    public Command build() {
        return pseudoCommand;
    }

}
