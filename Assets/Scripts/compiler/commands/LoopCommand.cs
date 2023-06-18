using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;

public class LoopCommand : ICommand {

    static string name = "loop";

    static LoopCommand() {
        Compiler.onSyntaxAdd += addSyntax;
    }

    public int times;
    public ICommand command;

    public LoopCommand() {
        times = -1;
        command = null;
    }

    public string getName() {
        return name;
    }

    private static void addSyntax(Dictionary<string, (Action<CommandBuilder>, Regex)> syntax) {
        syntax.Add(name, (builder => builder.makeLoopCommand(), new Regex(@"loop (?:\s*[\w\d|]+)+")));
    }

    public EnumResult addProp<T>(T prop) {
        switch(prop) {
            case int i:
                times = i;
                break;
            case ICommand cmd:
                command = cmd;
                break;
            default:
                return EnumResult.CERR;
        }
        return EnumResult.OK;
    }

    public bool isIncomplete() {
        return times == -1 || command == null;
    }

    public void run(PlayerInterface player) {
        for(int i=0;i<times;i++) {
            command.run(player);
        }
    }
}