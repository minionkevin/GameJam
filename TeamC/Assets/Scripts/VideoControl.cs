using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoControl : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(!GetComponent<VideoPlayer>().isPlaying)
        {
            Application.Quit();
            Debug.Log("Quit");
        }
    }
}
