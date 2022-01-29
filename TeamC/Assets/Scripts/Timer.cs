using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private Text timerText;

    private float timeCount = 0;
    private float currTime;

    // Start is called before the first frame update
    void Start()
    {
        currTime = timeCount;
    }

    // Update is called once per frame
    void Update()
    {
        currTime += Time.deltaTime;
        displayTime();
    }

    private void displayTime()
    {
        float minutes = Mathf.FloorToInt(currTime / 60);
        float seconds = Mathf.FloorToInt(currTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void resetTimer()
    {
        currTime = timeCount;
    }
}
