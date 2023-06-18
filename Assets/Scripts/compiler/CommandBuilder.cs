using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CommandBuilder
{
    
    private ICommand pseudoCommand = null;
    
    public void MakeMoveCommand() {
        this.pseudoCommand = new MoveCommand();
    }

    public void makeLoopCommand() {
        this.pseudoCommand = new LoopCommand();
    }

    public string getCurrentCommand() {
        return pseudoCommand.getName();
    }

    public bool noCommand() {
        return pseudoCommand == null;
    }

    public bool isIncomplete() {
        return pseudoCommand.isIncomplete();
    }

    public ICommand build() {
        
        return pseudoCommand;
    }
    
    public EnumResult provideProp<T>(T prop)
    {
        return pseudoCommand.addProp(prop);
    }
    

}
