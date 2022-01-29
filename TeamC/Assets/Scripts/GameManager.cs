using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject playerLoc;

    [SerializeField]
    private Transform cubeWorldSpawn;

    [SerializeField]
    private Transform roundWorldSpawn;

    public enum World
    {
        SQURARE, ROUND
    }
    public void swapPlayerWorld(World swapFrom)
    {
        playerLoc.GetComponent<CharacterController>().enabled = false;
        switch (swapFrom)
        {
            case World.SQURARE:
                playerLoc.transform.position = roundWorldSpawn.position;
                break;
            case World.ROUND:
                playerLoc.transform.position = cubeWorldSpawn.position;
                break;

        }
        playerLoc.GetComponent<CharacterController>().enabled = true;
    }
}
