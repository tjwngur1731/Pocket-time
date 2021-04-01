using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObjectController : MonoBehaviour
{
    private bool isRotate;

    private Vector3 rotate;

    void Start()
    {
        for(int i=1;i<transform.childCount;i++)
        {
            transform.GetChild(i).transform.position = new Vector3(Random.Range(-2,2),Random.Range(1,5));
        }
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
        if (isRight) rotate.y = transform.rotation.eulerAngles.y - 90;
        else rotate.y = transform.rotation.eulerAngles.y + 90;

        Debug.Log(rotate.y);

        if (!isRotate)
        {
            isRotate = true;
            Invoke("RotateDelay", .7f);
            transform.DOKill();
            transform.DORotate(rotate, .5f);
        }
    }

    public void RotateDelay()
    {
        isRotate = false;
    }
}
