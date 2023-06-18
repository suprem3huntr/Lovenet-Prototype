using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using CompilerExceptions;

public static class Compiler 
{

    public delegate void addSyntaxDelegate(Dictionary <string,(Action<CommandBuilder>, Regex)> syntax);
    public static event addSyntaxDelegate onSyntaxAdd;

    static Dictionary <string,(Action<CommandBuilder>, Regex)> syntax = new Dictionary<string, (Action<CommandBuilder>, Regex)>();
    
    public static void AddToSyntax() {
        onSyntaxAdd?.Invoke(syntax);
    }
    
    public static Queue<ICommand> compile(string code) {
        string[] delims = {"\n", ";"};
        List<string> lines = code.Split(delims, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
        Queue<ICommand> queue = new Queue<ICommand>();
        foreach(string line in lines) {
            queue.Enqueue(interpret(line));
        }
        return queue;
    }

    public static ICommand interpret(string code) {
        code = code.Trim();
        string[] tokens = code.Split(' ');

        CommandBuilder currentCommand = new CommandBuilder();
        Stack<CommandBuilder> commandStack = new Stack<CommandBuilder>();
        
        for(int i=0;i<tokens.Length;i++) {  
            string token = tokens[i];


            if(currentCommand.noCommand()) {
                foreach (KeyValuePair<string, (Action<CommandBuilder>, Regex)> entry in syntax) {
                    if(token.CompareTo(entry.Key) == 0 && entry.Value.Item2.IsMatch(code)) { 
                        entry.Value.Item1.Invoke(currentCommand);
                        break;
                    }
                }
                if(currentCommand.noCommand()){
                    throw new SyntaxException($"No command known as {token}");
                }
            } else {
                // Command ender
                if (token.CompareTo("|") == 0) {
                    if(commandStack.Peek() != null) {
                        if (currentCommand.isIncomplete()) throw new SyntaxException($"Command {currentCommand.getCurrentCommand()} ended prematurely");
                        ICommand argument = currentCommand.build();
                        currentCommand = commandStack.Pop();
                        currentCommand.provideProp(argument);
                        continue;
                    } else throw new SyntaxException("Unknown |"); 
                }

                // Numeric literals
                if (token.All(char.IsDigit)) {
                    currentCommand.provideProp(int.Parse(token));
                    continue;
                }

                // Command beginners
                bool done = false;
                foreach (KeyValuePair<string, (Action<CommandBuilder>, Regex)> entry in syntax) {
                    if(token.CompareTo(entry.Key) == 0 &&  entry.Value.Item2.IsMatch(code)) {
                        commandStack.Push(currentCommand);
                        commandStack.Peek();
                        currentCommand = new CommandBuilder();
                        entry.Value.Item1.Invoke(currentCommand);
                        done = true;
                        break;
                    }
                }
                if(done) continue;

                //Keywords
                switch(token) {
                    case "up":
                        currentCommand.provideProp(EnumDirection.UP);
                        done = true;
                        break;
                    case "down":
                        currentCommand.provideProp(EnumDirection.DOWN);
                        done = true;
                        break;
                    case "left":
                        currentCommand.provideProp(EnumDirection.LEFT);
                        done = true;
                        break;
                    case "right":
                        currentCommand.provideProp(EnumDirection.RIGHT);
                        done = true;
                        break;
                }
                if (done) continue;
                throw new SyntaxException("Unknown keyword or variable");
            }
        }
        return currentCommand.build();
    }

}
