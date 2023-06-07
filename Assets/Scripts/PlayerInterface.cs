using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInterface : MonoBehaviour
{
    public BotMovement controlBot; 
    public CameraController cameraController;

    public bool inWorld = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inWorld) {
            if(!controlBot.isBusy) {
                if(Input.GetKeyDown("i")) {
                    controlBot.moveBot(EnumDirection.UP);
                } else if(Input.GetKeyDown("k")) {
                    controlBot.moveBot(EnumDirection.DOWN);
                } else if (Input.GetKeyDown("j")) {
                    controlBot.moveBot(EnumDirection.LEFT);
                } else if (Input.GetKeyDown("l")) {
                    controlBot.moveBot(EnumDirection.RIGHT);
                }
            }

            float horiz = Input.GetAxis("Horizontal");
            float vert = Input.GetAxis("Vertical");

            if(horiz != 0.0f || vert != 0.0f) {
                cameraController.move(horiz, vert);
            }
        }
    }

    public void Interpret(TMP_InputField tmp) {
        Compiler.interpret(tmp.text, this);
    }

    public void MoveBot(EnumDirection dir) {
        controlBot.moveBot(dir);
    }

    public void setInWorld(bool inWorld) {
        this.inWorld = inWorld;
    }
}
