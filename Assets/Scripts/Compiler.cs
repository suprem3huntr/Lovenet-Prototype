using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compiler 
{
    public static Command[] compile(string code) {
        code.Split('\n');
        return null;
    }

    public static EnumResult interpret(string code, PlayerInterface player) {
        code = code.Trim();
        string[] tokens = code.Split(' ');
        CommandBuilder currentCommand = new CommandBuilder();
        for(int i=0;i<tokens.Length;i++) {
            string token = tokens[i];
            Debug.Log("Handling " + token);
            if(currentCommand.noCommand()) {
                if(token.CompareTo("move") == 0)
                    currentCommand.MakeMoveCommand();
                else {
                    Debug.Log("This error right here, officer");
                    return EnumResult.ERR;
                }
            } else {
                bool isHandled = false;
                EnumResult res;
                switch(token) {
                    case "up":
                        res = currentCommand.provideDir(EnumDirection.UP);
                        isHandled = true;
                        break;
                    case "down":
                        res = currentCommand.provideDir(EnumDirection.DOWN);
                        isHandled = true;
                        break;
                    case "left":
                        res = currentCommand.provideDir(EnumDirection.LEFT);
                        isHandled = true;
                        break;
                    case "right":
                        res = currentCommand.provideDir(EnumDirection.RIGHT);
                        isHandled = true;
                        break;
                    default:
                        res = EnumResult.OK;
                        break;
                }
                if(res == EnumResult.ERR) return EnumResult.ERR;
                if(!isHandled) return EnumResult.ERR;
            }
        }
        currentCommand.build().run(player);
        Debug.Log("Done!");
        return EnumResult.OK;
    }

}
