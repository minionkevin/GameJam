using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    [SerializeField]
    private float speed = 100.0f;
    private float rotateAngle;

    private void Start()
    {
        rotateAngle = 0;
    }
    // Update is called once per frame
    void Update()
    {
        rotateAngle += Time.deltaTime * speed;
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, rotateAngle, transform.eulerAngles.z);
    }

    public float getAngle()
    {
        return rotateAngle;
    }
}
