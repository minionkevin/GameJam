using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject playerLoc;

    [SerializeField]
    private Transform cubeWorldSpawn;

    [SerializeField]
    private Transform roundWorldSpawn;

    [SerializeField]
    private FadeController fader;

    public enum World
    {
        SQURARE, ROUND
    }
    public void swapPlayerWorld(World swapFrom)
    {
        fader.fadeOut(swapFrom);
    }

    public void movePlayer(World swapFrom)
    {
        playerLoc.GetComponent<RigidbodyFirstPersonController>().enabled = false;
        switch (swapFrom)
        {
            case World.SQURARE:
                playerLoc.transform.position = roundWorldSpawn.position;
                break;
            case World.ROUND:
                playerLoc.transform.position = cubeWorldSpawn.position;
                break;

        }
        playerLoc.GetComponent<RigidbodyFirstPersonController>().enabled = true;
    }
}
