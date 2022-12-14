using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIQuiz : MonoBehaviour
{
    public Button btnBack;

    public TMP_Text txtQuestion;
    public Button[] btnAnswers = new Button[4];
    public TMP_Text[] txtAnswers = new TMP_Text[4];

    Quiz[] quizList = QuizManager.GetInstance().GetQuizList();
    public int quizNum;

    void Start()
    {
        btnBack.onClick.AddListener(MoveToMain);
        quizNum = 0;

        SetQuizUI();
        for (int i = 0; i < btnAnswers.Length; i++)
        {
            if (i < quizList[quizNum].answerList.Length)
            {
                int idx = i;
                btnAnswers[i].onClick.AddListener(() => { OnAnswer(idx); });
            }
        }
    }

    void MoveToMain()
    {
        ScenesManager.GetInstance().ChangeScene(Scene.Main);

        QuizManager.GetInstance().SetScore();
    }


    void SetQuizUI()
    {
        txtQuestion.text = quizList[quizNum].question;

        for (int i = 0; i < btnAnswers.Length; i++)
        {
            if (i < quizList[quizNum].answerList.Length)
            {
                btnAnswers[i].gameObject.SetActive(true);
                txtAnswers[i].text = quizList[quizNum].answerList[i];
            }
            else
                btnAnswers[i].gameObject.SetActive(false);
        }
    }

    void NextQuiz()
    {
        quizNum++;

        if (quizNum < quizList.Length)
        {
            SetQuizUI();
            Debug.Log($"다음 퀴즈입니다.");
        }

        else
        {
            ScenesManager.GetInstance().ChangeScene(Scene.Main);
            QuizManager.GetInstance().openResult = true;
        }
    }

    public void OnAnswer(int answer)
    {
        Debug.Log($"내가 고른 답: {answer}");
        Debug.Log($"정답: {quizList[quizNum].correctAnswer}");

        if (answer == quizList[quizNum].correctAnswer)
        {
            QuizManager manager = QuizManager.GetInstance();
            manager.correctCount++;
            manager.score += quizList[quizNum].point;
            Debug.Log($"정답입니다.");
        }
        else
            Debug.Log($"오답입니다.");

        NextQuiz();
    }
}