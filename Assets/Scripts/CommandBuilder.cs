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

    

    public Command build() {
        
        return pseudoCommand;
    }
    public EnumResult provideProp<T>(T prop)
    {
        return pseudoCommand.addProp(prop);
    }
    

}
