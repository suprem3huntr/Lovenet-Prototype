# Instructions
## Moving the camera
Use W,A,S and D to move the camera around
## Moving the character
Until typing the commands has been implemented, use I,J,K and L to move the bot

# Documentation
## Registering `Commands`
1. Add a static function accepting `Dictionary<string, Action<CommandBuilder>, Regex>` to the `Command` extended class that will add an entry to the dictionary (it's regex syntax checker and command maker function from `CommandBuilder`) 
2. Statically add the function to `Compiler.onSyntaxAdd` event using `static <Class>() { ... }`
3. Add the script to `PlayerInterface` under `CyberController`
### Example
MoveCommand.cs:
```cs
class MoveCommand: ICommand {
    static MoveCommand() {
        Compiler.onSyntaxAdd += addSyntax;
    }

    private syntax void addSyntax(Dictionary<string, (Action, Regex)> syntax) {
        ...
    }

    ...
}
```

# TODO
## Commands
Make an interface for commands that can easily be interpreted by CyberController or PlayerInterface

## Parser
Make a parser to convert statement into commands like `move up` to `CommandMove(EnumDirection.UP)`

## Stack
Make a Command stack that pops and pushes the more layers of command that you go into.