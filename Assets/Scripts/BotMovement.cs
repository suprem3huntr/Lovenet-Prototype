using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMovement : MonoBehaviour
{
    public Vector3 nextPos, currPos;
    public float moveSpeed;
    public float time;
    public bool isBusy = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(time >= 1.0f) {
            transform.position = currPos+nextPos;
            nextPos = Vector3.zero;
            time = 0.0f;
            isBusy = false;
        }

        if(isBusy && transform.position != currPos+nextPos) {
            time += Time.deltaTime * moveSpeed;
            transform.position = currPos+nextPos*(1.0f - Mathf.Pow(2.0f, -10.0f * time));
        }
    }

    public IEnumerator moveBot(EnumDirection dir) {
        while (isBusy) {
            yield return null;
        }
        currPos = transform.position;
        isBusy = true;
        switch(dir) {
            case EnumDirection.UP:
                nextPos = Vector3.up;
                break;
            case EnumDirection.DOWN:
                nextPos = Vector3.down;
                break;
            case EnumDirection.LEFT:
                nextPos = Vector3.left;
                break;
            case EnumDirection.RIGHT:
                nextPos = Vector3.right;
                break;
        }
    }
}
