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
    private bool sceneStarting = true;

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

        if(FadeImg.color.a <= 0.05f)
        {
            FadeImg.color = Color.clear;
            FadeImg.enabled = false;

            sceneStarting = false;
        }
    }

    public void fadeOut()
    {
        sceneStarting = false;
        StartCoroutine(FadeOutRoutine());
    }

    IEnumerator FadeOutRoutine()
    {
        FadeImg.enabled = true;
        while (true)
        {
            FadeToWhite();

            if(FadeImg.color.a >= 0.95f)
            {
                //Do the teleport here!
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
    }
}
