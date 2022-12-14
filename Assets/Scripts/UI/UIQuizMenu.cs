using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIQuizMenu : MonoBehaviour
{
    public Button btnBack;
    void Start()
    {
        btnBack.onClick.AddListener(MoveToMain);
    }

    void MoveToMain()
    {
        ScenesManager.GetInstance().ChangeScene(Scene.Main);
    }
}