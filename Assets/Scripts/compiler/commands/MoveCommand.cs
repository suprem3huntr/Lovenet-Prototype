using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;

public class MoveCommand: ICommand {   

    static string name = "move";

    static MoveCommand(){
        Compiler.onSyntaxAdd += addToSyntax;   
    }

    public MoveCommand() {
        dir = EnumDirection.NONE;
    }

    public EnumDirection dir;

    public void run(PlayerInterface player) {
        player.MoveBot(dir);
    }

    public string getName() {
        return name;
    }

    private static void addToSyntax(Dictionary<string,(Action<CommandBuilder>, Regex)> syntax) {
        syntax.Add(name, (builder => builder.MakeMoveCommand(), new Regex(@"move [a-zA-Z]+\b")));
    }

    public EnumResult addProp<T> (T prop)
    {
        switch (prop)
        {
            case EnumDirection d:
                dir=d;
                return EnumResult.OK;
            default:
                return EnumResult.CERR;
        }
        
    }

    public bool isIncomplete()
    {
        return dir == EnumDirection.NONE;
    }
}
