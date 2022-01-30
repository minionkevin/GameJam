using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class stepSFX : MonoBehaviour
{
    private RigidbodyFirstPersonController controller;
    [SerializeField]
    private AudioClip[] footsteps;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<RigidbodyFirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        AudioSource a = GetComponent<AudioSource>();
        if (controller.Grounded == true && controller.Velocity.magnitude > 2f && a.isPlaying == false)
        {
            if (controller.Running)
            {

            }
            // pick & play a random footstep sound from the array,
            // excluding sound at index 0
            int n = Random.Range(1, footsteps.Length);
            a.clip = footsteps[n];
            a.PlayOneShot(a.clip);
            // move picked sound to index 0 so it's not picked next time
            footsteps[n] = footsteps[0];
            footsteps[0] = a.clip;
        }
    }
}
