using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObjectController : MonoBehaviour
{
    private bool isRotate;

    public static ObjectController instance = null;
    void Awake()
    {
        if (instance == null) instance = this;

        else if (instance != this) Destroy(gameObject);
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
            ObjectRotate(true);
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            ObjectRotate(false);
    }

    public void ObjectRotate(bool isRight)
    {
        if (!isRotate)
        {
            isRotate = true;
            Invoke("RotateDelay", .7f);
            transform.DOKill();
            if (isRight)
                transform.DORotate(new Vector3(0, transform.eulerAngles.y - 90, 0), .5f);
            else if (!isRight)
                transform.DORotate(new Vector3(0, transform.eulerAngles.y + 90, 0), .5f);
        }
    }

    public void RotateDelay()
    {
        isRotate = false;
    }
}
