using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerMovement : MonoBehaviour
{
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
    [SerializeField]
    private RigidbodyFirstPersonController controller;
    [SerializeField]
    private CapsuleCollider collider;

    private Camera camera;
    private float crouchHeight = 0.2f;
    bool tester = false;
    float targetHeight;
    float targetHeightLeft;
    float targetHeightRight;
    [SerializeField]
    private Transform originalCamera;
    private bool isGround;
    private float colliderHolder;


    private bool test;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        isGround = true;
        colliderHolder = collider.height; 
    }

    private void Update()
    {
        Debug.Log(test);
        leftHand.transform.rotation = camera.transform.rotation;
        rightHand.transform.rotation = camera.transform.rotation;

        if (controller.Grounded) isGround = true;
        else isGround = false;

        if (!isGround||tester)
        {
            resetPosition();
        }

        //Debug.Log(isGround);

        if (Input.GetKey(KeyCode.LeftControl))
        { 
            if (!tester)
            {
                targetHeight = camera.transform.position.y - crouchHeight;
                targetHeightLeft = leftHand.transform.position.y - crouchHeight;
                targetHeightRight = rightHand.transform.position.y - crouchHeight;
                collider.height /= 1.1f;
                tester = true;
            }

                camera.transform.position = new Vector3(camera.transform.position.x, targetHeight, camera.transform.position.z);
                leftHand.transform.position = new Vector3(leftHand.transform.position.x, targetHeightLeft, leftHand.transform.position.z);
                rightHand.transform.position = new Vector3(rightHand.transform.position.x, targetHeightRight, rightHand.transform.position.z);
        }


        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            if (tester)
            {
                resetPosition();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        test = false;
    }

    private void OnTriggerStay(Collider other)
    {
        test = true;
    }

    private void resetPosition()
    {
        camera.transform.position = new Vector3(camera.transform.position.x, originalCamera.position.y, camera.transform.position.z);
        leftHand.transform.position = new Vector3(leftHand.transform.position.x, leftNote.transform.position.y + crouchHeight, leftHand.transform.position.z);
        rightHand.transform.position = new Vector3(rightHand.transform.position.x, rightNote.transform.position.y + crouchHeight, rightHand.transform.position.z);
        collider.height = colliderHolder;
        tester = false;
    }
}
