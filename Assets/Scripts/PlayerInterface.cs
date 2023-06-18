using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using System;
using CompilerExceptions;

public class PlayerInterface : MonoBehaviour
{
    
    public BotMovement controlBot; 
    public CameraController cameraController;
    public MonoScript[] commands;

    public bool inWorld = true;
    string code;

    void Awake()
    {
        code = "";
        foreach(MonoScript script in commands) {
            Type type = script.GetClass();    
            Activator.CreateInstance(type);
        }
        Compiler.AddToSyntax();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(inWorld) {
            /* if(!controlBot.isBusy) {
                if(Input.GetKeyDown("i")) {
                    controlBot.moveBot(EnumDirection.UP);
                } else if(Input.GetKeyDown("k")) {
                    controlBot.moveBot(EnumDirection.DOWN);
                } else if (Input.GetKeyDown("j")) {
                    controlBot.moveBot(EnumDirection.LEFT);
                } else if (Input.GetKeyDown("l")) {
                    controlBot.moveBot(EnumDirection.RIGHT);
                }
            } */

            float horiz = Input.GetAxis("Horizontal");
            float vert = Input.GetAxis("Vertical");

            if(horiz != 0.0f || vert != 0.0f) {
                cameraController.move(horiz, vert);
            }
        }
    }

    public void Interpret(TMP_InputField tmp) {
        try {
            ICommand command = Compiler.interpret(tmp.text);
            command.run(this);
        } catch(GameException err) {
            Debug.LogError(err.Message);
        } 
    }

    public void AddLine(TMP_InputField tmp) {
        if (code != "") code += "\n";
        code += tmp.text;
    }

    public void compileAndRun() {
        Debug.Log("I have reacheth");
        Queue<ICommand> commandQueue = Compiler.compile(code);
        while(commandQueue.Count > 0) {
            commandQueue.Dequeue().run(this);
        }
        code = "";
    }

    public void MoveBot(EnumDirection dir) {
        StartCoroutine(controlBot.moveBot(dir));
    }

    public bool CanBotMove() {
        return controlBot.isBusy;
    }

    public void setInWorld(bool inWorld) {
        this.inWorld = inWorld;
    }
}
