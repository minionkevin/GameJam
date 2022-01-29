using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float downSpeed = 2f;

    private Camera camera;
    private bool isDown;
    Vector3 holder;
    private float cameraPos;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        isDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if(!isDown)
            {
                cameraPos = camera.transform.position.y / 2;
                holder = camera.transform.position;            
            }
            isDown = true;
            time = time + Time.deltaTime * downSpeed;
            float result = Mathf.Lerp(holder.y, cameraPos, time);
            camera.transform.position = new Vector3(camera.transform.position.x, result, camera.transform.position.z);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            isDown = false;
            time = 0;
        }
    }
}
