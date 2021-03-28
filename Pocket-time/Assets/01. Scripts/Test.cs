using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject ob;

    public Vector3[] pos;

    // Start is called before the first frame update
    void Start()
    {
        pos = new Vector3[ob.transform.childCount];
        for (int i = 0; i < ob.transform.childCount; i++)
        {
            pos[i] = Camera.main.WorldToScreenPoint(ob.transform.GetChild(i).localPosition);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //ob.transform.GetChild(1).gameObject.SetActive(true);
    }
}
