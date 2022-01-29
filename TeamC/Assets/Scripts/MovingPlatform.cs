using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private GameObject loc1;
    [SerializeField]
    private GameObject loc2;
    [SerializeField]
    private float moveSpeed;
    private bool returning = false;

    private void FixedUpdate()
    {
        if(returning) 
        {
            if(transform.position != loc1.transform.position)
            {
                Vector3 dir = transform.position - loc1.transform.position;
                dir = -dir.normalized;

                transform.position += dir * Time.deltaTime * moveSpeed;
            }
            else
            {
                returning = false;
            }

        }
        else
        {
            if (transform.position != loc2.transform.position)
            {
                Vector3 dir = transform.position - loc2.transform.position;
                dir = -dir.normalized;

                transform.position += dir * Time.deltaTime * moveSpeed;
            }
            else
            {
                returning = true;
            }
        }
    }
}
