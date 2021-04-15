using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool _mouseState;
    private GameObject Target;
    private Vector3 screenSpace;
    private Vector3 offset;
    [SerializeField]
    private float limt;
    [SerializeField]
    GameObject model;
    private bool check;
    private  int ObjectChildNum;

    // Use this for initialization
    void Start()
    {
        Target = null;
        
    }

    // Update is called once per frame
    void Update()
    {
        model = StageSelect.instance.ReturnModel();
        // Debug.Log(_mouseState);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            int layerMask = (1 << LayerMask.NameToLayer("Model"));
            layerMask = ~layerMask;

            if (Physics.Raycast(ray, out hit, 1000f,layerMask))
            {
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
                if (!Target.GetComponent<ObjectChild>().isTlqkf)
                {
                    Target.transform.localPosition = new Vector3(0, 0, 0);
                    Target.layer = 8;
                    check = false;
                }else
                {
                    for (int i = 0; i < model.transform.GetChildCount(); i++)
                    {
                        if (model.transform.GetChild(i) == model.transform.FindChild(Target.name))
                        {
                            ObjectChildNum = i;
                            break;
                        }
                    }
                    if (model.transform.GetChild(ObjectChildNum - 1).gameObject.layer == 8)
                    {
                        Target.transform.localPosition = new Vector3(0, 0, 0);
                        Target.layer = 8;
                        check = false;
                    }
           
                }
              
            }
            _mouseState = false;

        }
        if (_mouseState)
        {
            var curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);

            var curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;

            Target.transform.position = curPosition;

            if (Vector3.Distance(Target.transform.localPosition, Vector3.zero) <= limt) check = true;
        }



    }
}
