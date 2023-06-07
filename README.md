# Instructions
## Moving the camera
Use W,A,S and D to move the camera around
## Moving the character
Until typing the commands has been implemented, use I,J,K and L to move the bot

# TODO
## Commands
Make an interface for commands that can easily be interpreted by CyberController or PlayerInterface

## Parser
Make a parser to convert statement into commands like `move up` to `CommandMove(EnumDirection.UP)`

## Stack
Make a Command stack that pops and pushes the more layers of command that you go into.