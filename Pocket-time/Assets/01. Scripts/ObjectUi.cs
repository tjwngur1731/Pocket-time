using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ObjectUi : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private GameObject object_Drag;
    private GameObject ob;
    private Image image;
    private GameObject 씨발련아;
    bool check;
    [SerializeField]
    private float limt;

    private Vector3 mOffset;

    private float mZCoord;

    void Start()
    {

        check = false;
    }

    void Update()
    {
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;

        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }


    public void OnDrag(PointerEventData eventData)
    {
        object_Drag.transform.position = GetMouseWorldPos() + mOffset;
       
        if (Vector3.Distance(object_Drag.transform.position, Vector3.zero) <= limt) check = true;
        else check = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        mOffset = gameObject.transform.position - GetMouseWorldPos();

        object_Drag.SetActive(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (check)
        {
            object_Drag.transform.position = new Vector3(0, 0, 0);
            this.gameObject.SetActive(false);
        }
        else
            object_Drag.SetActive(false);
    }
}
