using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizScene : MonoBehaviour
{
    void Start()
    {
        UIManager manager = UIManager.GetInstance();
        manager.SetEventSystem();
        manager.OpenUI("UIQuizMenu");
    }

    public void SetResult()
    {
        UIManager manager = UIManager.GetInstance();
        manager.OpenUI("UIResult");
    }
}