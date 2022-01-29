using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PickupBox : MonoBehaviour
{
    [SerializeField]
    private GameManager.World Currentworld;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("BINGUS");
            GameObject.Find("GameManager").GetComponent<GameManager>().swapPlayerWorld(Currentworld);
            other.GetComponent<RigidbodyFirstPersonController>().enabled = false;
        }
    }
}
