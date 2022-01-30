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

    [SerializeField]
    private List<Transform> roundWorldPickupSpawns;
    [SerializeField]
    private List<Transform> squareWorldPickupSpawns;

    [SerializeField]
    private GameObject pickupPrefab;

    [SerializeField]
    private AudioSource BGM;

    [SerializeField]
    private AudioClip squareBGM;

    [SerializeField]
    private AudioClip roundBGM;

    private int totalPickups = 0;
    public enum World
    {
        SQURARE, ROUND
    }

    private void Start()
    {
        BGM.volume = 0.15f;
        for(int i = 0; i < 3; i++)
        {
            int rand = Random.Range(0, roundWorldPickupSpawns.Count);

            GameObject pickupGO = Instantiate(pickupPrefab, roundWorldPickupSpawns[rand]);
            pickupGO.GetComponent<PickupBox>().Currentworld = World.ROUND;
            roundWorldPickupSpawns.RemoveAt(rand);

            pickupGO = Instantiate(pickupPrefab, squareWorldPickupSpawns[rand]);
            pickupGO.GetComponent<PickupBox>().Currentworld = World.SQURARE;
            squareWorldPickupSpawns.RemoveAt(rand);
        }
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
                BGM.Stop();
                BGM.volume = 0.15f;
                BGM.clip = roundBGM;
                BGM.Play();
                break;
            case World.ROUND:
                playerLoc.transform.position = cubeWorldSpawn.position;
                RenderSettings.skybox = squareWorldSky;
                BGM.Stop();
                BGM.volume = 1.0f;
                BGM.clip = squareBGM;
                BGM.Play();
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
