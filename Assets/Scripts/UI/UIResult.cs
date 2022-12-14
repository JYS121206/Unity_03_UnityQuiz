using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIResult : MonoBehaviour
{
    public TMP_Text txtScore;
    public TMP_Text txtCorrectCount;

    public Button btnEnd;

    void Start()
    {
        QuizManager manager = QuizManager.GetInstance();
        txtScore.text = $"{manager.score}Á¡";
        txtCorrectCount.text = $"{manager.correctCount}°³";
        btnEnd.onClick.AddListener(CloseResult);
    }

    public void CloseResult()
    {
        QuizManager.GetInstance().openResult = false;
        UIManager.GetInstance().CloseUI("UIResult");

        QuizManager.GetInstance().SetScore();
    }
}