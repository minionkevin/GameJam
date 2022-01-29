using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float downSpeed = 2f;
    [SerializeField]
    private GameObject leftHand;
    [SerializeField]
    private GameObject rightHand;
    [SerializeField]
    private GameObject leftNote;
    [SerializeField]
    private GameObject rightNote;
    [SerializeField]
    private float height = 0.8f;


    private Camera camera;
    private bool isDown;
    Vector3 holder;
    Vector3 holderRight;
    Vector3 holderLeft;
    private float cameraPos;
    private float time;
    private float leftH;
    private float rightH;


    
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
                cameraPos = camera.transform.position.y * height;
                holder = camera.transform.position;
                holderRight = rightHand.transform.position;
                holderLeft = leftHand.transform.position;

                leftH = leftHand.transform.position.y * height;
                rightH = rightHand.transform.position.y * height;
            }

            isDown = true;
            time = time + Time.deltaTime * downSpeed;
            float result = Mathf.Lerp(holder.y, cameraPos, time);
            float leftHandResult = Mathf.Lerp(holderLeft.y, leftH, time);
            float rightHandResult = Mathf.Lerp(holderRight.y, rightH, time);
            camera.transform.position = new Vector3(camera.transform.position.x, result, camera.transform.position.z);
            leftHand.transform.position = new Vector3(leftHand.transform.position.x, leftHandResult, leftHand.transform.position.z);
            rightHand.transform.position = new Vector3(rightHand.transform.position.x, rightHandResult, rightHand.transform.position.z);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            isDown = false;
            time = 0;
            leftHand.transform.position = new Vector3(leftHand.transform.position.x, leftNote.transform.position.y, leftHand.transform.position.z);
            rightHand.transform.position = new Vector3(rightHand.transform.position.x, rightNote.transform.position.y, rightHand.transform.position.z);

        }
    }
}
