using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopPickupObject : MonoBehaviour
{
    private bool isAttach;

    private void Start()
    {
        isAttach = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isAttach = true;
            other.transform.SetParent(this.transform, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isAttach = false;
            other.transform.SetParent(null, true);
        }
    }
}
