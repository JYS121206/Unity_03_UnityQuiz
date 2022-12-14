using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz
{
    public string question;
    public int point;
    public string[] answerList;
    public int correctAnswer;

    public Quiz(string question, int point, int correctAnswer, string[] answerList)
    {
        this.question = question;
        this.point = point;
        this.correctAnswer = correctAnswer;
        this.answerList = answerList;
    }
}

public class QuizManager : MonoBehaviour
{
    #region Singletone
    private static QuizManager instance;

    public static QuizManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@QuizManager");
            instance = go.AddComponent<QuizManager>();

            DontDestroyOnLoad(go);
        }

        return instance;
    }
    #endregion

    public Dictionary<int, Quiz[]> quizList;

    public int quizListIdx = 0;

    public int score;
    public int correctCount;
    public bool openResult = false;

    private void Awake()
    {
        ChooseQuizList();

        //Dictionary �ȿ� �ִ� Quiz ȣ�� �׽�Ʈ
        //Quiz[] qList1 = quizList[1];
        //Debug.Log(qList1[1].question);

        //Quiz[] qList2 = quizList[2];
        //for (int i = 0; i < qList2.Length; i++)
        //{
        //    Debug.Log(qList2[i].question);
        //}
    }

    public void ChooseQuizList()
    {
        quizList = new Dictionary<int, Quiz[]>();
        quizList.Add(1, new Quiz[]
            {
                new Quiz("1. ���� �� �߰ſ� Ŀ�Ǹ� ������ �� �Ǵ� ����?", 25, 3, new string[]{ "������","�ӱ���","������","�ö�ƽ��"}),
                new Quiz("2. ������� ������?", 25, 1, new string[]{ "���ڴ�", "���ڴ�"}),
                new Quiz("3. ��ũ ���ݸ��� ź��ȭ����", 25, 0, new string[]{ "�ִ�","����"}),
                new Quiz("4. ��ī���", 25, 2, new string[]{ "����","����̴�","���","�罿�̴�"})
            });
        quizList.Add(2, new Quiz[]
            {
                new Quiz("1. �������� ����", 25, 0, new string[]{ "�����̴�","������","Ǯ�̴�"}),
                new Quiz("2. ���� �� ����� ������ �ð���?", 25, 1, new string[]{ "���� 11�� 30��", "���� 5�� 41��"}),
                new Quiz("3. ���� �� 203ȣ�� ���������� �ƴ� ����?", 25, 1, new string[]{ "360 VR ���� ����", "360 VR 3D ��������", "���� 3D �𵨸�","����Ƽ C#"}),
                new Quiz("4. ������ ���������� �ڶ���.", 25, 0, new string[]{ "�׷���", "�ƴϴ�"})
            });
    }

    public void SetQuizList(int option)
    {
        quizListIdx= option;
    }

    public Quiz[] GetQuizList()
    {
        return quizList[quizListIdx];
    }

    public void SetScore()
    {
        QuizManager.GetInstance().correctCount = 0;
        QuizManager.GetInstance().score = 0;
    }
}