using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float maxSpeed;
    public Collider2D gameBox;
    Vector2 minPos, maxPos;
    Vector2 vel;

    // Start is called before the first frame update
    void Start() {
        if (gameBox != null) {
            Vector2 cameraHalfSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
            Bounds bounds = gameBox.bounds;

            minPos = (Vector2)bounds.min + cameraHalfSize;
            maxPos = (Vector2)bounds.max - cameraHalfSize;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void move(float horiz, float vert) {
        Vector3 newPos = transform.position + (Vector3)new Vector2(horiz, vert) * Time.deltaTime * maxSpeed;
        newPos.x = Mathf.Clamp(newPos.x, minPos.x, maxPos.x);
        newPos.y = Mathf.Clamp(newPos.y, minPos.y, maxPos.y);

        transform.position = newPos;
    }
}
