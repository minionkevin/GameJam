using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHelper : MonoBehaviour
{
    [SerializeField]
    private Sprite oldSprite;
    [SerializeField]
    private Sprite newSprite;
    [SerializeField]
    private Button[] btnArr;


    public void change(int index)
    {
        btnArr[index].GetComponent<Button>().image.sprite = newSprite;
        btnArr[index].GetComponentInChildren<Text>().color = Color.white;
    }

    public void changeBack(int index)
    {
        btnArr[index].GetComponent<Button>().image.sprite = oldSprite;
        btnArr[index].GetComponentInChildren<Text>().color = Color.black;

    }
}
