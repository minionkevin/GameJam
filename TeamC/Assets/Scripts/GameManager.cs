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

    [SerializeField]
    private Material roundWorldSky;

    [SerializeField]
    private Material squareWorldSky;

    private int totalPickups = 0;
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
        //playerLoc.GetComponent<RigidbodyFirstPersonController>().enabled = false;
        switch (swapFrom)
        {
            case World.SQURARE:
                playerLoc.transform.position = roundWorldSpawn.position;
                RenderSettings.skybox = roundWorldSky;
                break;
            case World.ROUND:
                playerLoc.transform.position = cubeWorldSpawn.position;
                RenderSettings.skybox = squareWorldSky;
                break;

        }
        totalPickups++;
        Debug.Log(totalPickups);
        if(totalPickups == 6)
        {
            gameOver();
        }
        playerLoc.GetComponent<RigidbodyFirstPersonController>().enabled = true;
    }

    void gameOver()
    {
        Debug.Log("WINNER");
    }
}
