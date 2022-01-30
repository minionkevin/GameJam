using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    [SerializeField]
    private Image FadeImg;
    [SerializeField]
    private float fadeSpeed = 0.5f;
    [SerializeField]
    private GameManager manager;
    private bool sceneStarting = false;
    [SerializeField]
    private AudioSource BGM;


    private void Awake()
    {
        FadeImg.rectTransform.localScale = new Vector2(Screen.width, Screen.height);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (sceneStarting)
        {
            StartScene();
        }
    }

    void StartScene()
    {
        FadeToClear();

        if (FadeImg.color.a <= 0.1f)
        {
            FadeImg.color = Color.clear;
            FadeImg.enabled = false;


            sceneStarting = false;
        }
    }

    public void fadeIn()
    {
        sceneStarting = true;
    }

    public void fadeOut(GameManager.World swapFrom)
    {
        sceneStarting = false;
        StartCoroutine(FadeOutRoutine(swapFrom));
    }

    IEnumerator FadeOutRoutine(GameManager.World swapFrom)
    {
        FadeImg.enabled = true;
        while (true)
        {
            FadeToWhite();

            if (FadeImg.color.a >= 0.90f)
            {
                //Do the teleport here!
                FadeImg.color = Color.white;
                manager.movePlayer(swapFrom);
                fadeIn();
                yield break;
            }
            else
            {
                yield return null;
            }
        }
    }
    void FadeToClear()
    {
        FadeImg.color = Color.Lerp(FadeImg.color, Color.clear, fadeSpeed * Time.deltaTime);
    }

    void FadeToWhite()
    {
        FadeImg.color = Color.Lerp(FadeImg.color, Color.white, fadeSpeed * Time.deltaTime);
        BGM.volume = Mathf.Lerp(BGM.volume, 0, fadeSpeed * Time.deltaTime);
    }
}
