using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInterface : MonoBehaviour
{
    public BotMovement controlBot; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}
