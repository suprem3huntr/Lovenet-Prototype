using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class Compiler 
{
    static Dictionary <string,Regex> Syntax;
    public static Command[] compile(string code) {
        code.Split('\n');
        return null;
    }

    public static EnumResult interpret(string code, PlayerInterface player) {
        if (Syntax==null)
        {
            Syntax= new Dictionary<string, Regex>();
            Syntax.Add("move",new Regex(@"^move [a-zA-Z]+$"));
        }
        code = code.Trim();
        string[] tokens = code.Split(' ');
        CommandBuilder currentCommand = new CommandBuilder();
        for(int i=0;i<tokens.Length;i++) {
            string token = tokens[i];
            Debug.Log("Handling " + token);
            if(currentCommand.noCommand()) {
                if(token.CompareTo("move") == 0 &&  Syntax["move"].IsMatch(code))
                {
                    currentCommand.MakeMoveCommand();
                }
                else {
                    Debug.Log("This error right here, officer");
                    return EnumResult.ERR;
                }
            } else {
                bool isHandled = false;
                
                EnumResult res;
                switch(token) {
                    case "up":
                        res = currentCommand.provideProp(EnumDirection.UP);
                        isHandled = true;
                        break;
                    case "down":
                        res = currentCommand.provideProp(EnumDirection.DOWN);
                        isHandled = true;
                        break;
                    case "left":
                        res = currentCommand.provideProp(EnumDirection.LEFT);
                        isHandled = true;
                        break;
                    case "right":
                        res = currentCommand.provideProp(EnumDirection.RIGHT);
                        isHandled = true;
                        break;
                    default:
                        res = EnumResult.ERR;
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
