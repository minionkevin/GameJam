using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PickupBox : MonoBehaviour
{
    [SerializeField]
    private GameManager.World Currentworld;

    private bool isAttach;
    private GameObject player;

    private void Start()
    {
        isAttach = false;
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.E) && isAttach && player!=null)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().swapPlayerWorld(Currentworld);
            player.GetComponent<RigidbodyFirstPersonController>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            isAttach = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        isAttach = false;
    }
}
