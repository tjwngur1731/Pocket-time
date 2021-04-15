using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelect : MonoBehaviour
{
    private string chapter;
    private int stage;

   
    public GameObject _model;

    public static StageSelect instance = null;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }


    public void SelectChapter(string _chapter)
    {
        chapter = _chapter;
    }

    public void SelectStage(int _stage)
    {
        stage = _stage;
    }

    public void StartStage()
    {
        _model = Resources.Load("Prefaps/" + chapter + "/" + chapter + "_" + stage + "_" + "Model") as GameObject;

        Debug.Log("Prefaps/" + chapter + "/" + chapter + "_" + stage + "_" + "Model");

        GameObject model = Instantiate(_model);

        _model = model;

        Debug.Log(_model.name);
    }

    public GameObject ReturnModel()
    {
        return _model;
    }


}
