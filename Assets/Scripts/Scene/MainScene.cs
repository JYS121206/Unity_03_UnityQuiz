using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    void Start()
    {
        
        UIManager manager = UIManager.GetInstance();
        manager.SetEventSystem();
        manager.OpenUI("UIOptionMenu");
        OpenResult();

    }

    public void OpenResult()
    {
        if (QuizManager.GetInstance().openResult == true)
            UIManager.GetInstance().OpenUI("UIResult");
    }
}