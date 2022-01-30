using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityStandardAssets.Characters.FirstPerson;

public class PickupBox : MonoBehaviour
{
    [SerializeField]
    public GameManager.World Currentworld;
    [SerializeField]
    private ParticleSystem particle;
    [SerializeField]
    private VisualEffect effect;

    private bool isAttach;
    private GameObject player;

    private bool activated = false;

    private void Start()
    {
        isAttach = false;
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.E) && isAttach && player!=null && activated == false)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().swapPlayerWorld(Currentworld);
            player.GetComponent<RigidbodyFirstPersonController>().enabled = false;
            activated = true;
            effect.Stop();
            particle.Stop();
            Destroy(gameObject);
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
