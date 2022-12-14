using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOptionMenu : MonoBehaviour
{
    public Button btnOption1;
    public Button btnOption2;

    void Start()
    {
        btnOption1.onClick.AddListener(() => { OnSelectOption(1); });
        btnOption2.onClick.AddListener(() => { OnSelectOption(2); });
    }

    //void MoveToQuiz()
    //{
    //    ScenesManager.GetInstance().ChangeScene(Scene.Quiz);
    //}

    void OnSelectOption(int option)
    {
        QuizManager.GetInstance().SetQuizList(option);
        ScenesManager.GetInstance().ChangeScene(Scene.Quiz);
    }
}