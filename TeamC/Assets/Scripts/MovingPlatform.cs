using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Moving Platform Script
public class MovingPlatform : MonoBehaviour
{
    //Loc1 and Loc2 cannot be children of the moving platform
    [SerializeField]
    private GameObject loc1;
    [SerializeField]
    private GameObject loc2;

    [SerializeField]
    private float moveSpeed = 2f;

    private GameObject player;

    private bool returning = false;
    private CharacterController controller;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.transform.parent = null;
        }
    }

    private void FixedUpdate()
    {
        if (returning)
        {
            transform.position = Vector3.MoveTowards(transform.position, loc1.transform.position, Time.deltaTime * moveSpeed);
            if(Vector3.Distance(transform.position, loc1.transform.position) < 0.001f)
            {
                returning = !returning;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, loc2.transform.position, Time.deltaTime * moveSpeed);
            if (Vector3.Distance(transform.position, loc2.transform.position) < 0.001f)
            {
                returning = !returning;
            }
        }
    }
}
