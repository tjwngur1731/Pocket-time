using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool _mouseState;
    public GameObject Target;
    public Vector3 screenSpace;
    public Vector3 offset;
    public float limt;
    private bool check;

    // Use this for initialization
    void Start()
    {
        Target = null;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(_mouseState);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, LayerMask.NameToLayer("Model")))
            {
                Debug.Log("ASD");
                Target = hit.collider.gameObject;
                _mouseState = true;
                screenSpace = Camera.main.WorldToScreenPoint(Target.transform.position);
                offset = Target.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
            }

        }
        if (Input.GetMouseButtonUp(0))
        {
            if (check)
            {
                Target.transform.localPosition = new Vector3(0, 0, 0);
                Target.layer = 8;
            }
            _mouseState = false;

        }
        if (_mouseState)
        {
            var curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);

            var curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;

            Target.transform.position = curPosition;

            if (Vector3.Distance(Target.transform.position, Vector3.zero) <= limt) check = true;
        }



    }
}
