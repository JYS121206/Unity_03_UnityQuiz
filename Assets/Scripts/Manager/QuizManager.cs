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

        //Dictionary 안에 있는 Quiz 호출 테스트
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
                new Quiz("1. 다음 중 뜨거운 커피를 담으면 안 되는 컵은?", 25, 3, new string[]{ "나무컵","머그컵","유리컵","플라스틱컵"}),
                new Quiz("2. 강사님의 성별은?", 25, 1, new string[]{ "여자다", "남자다"}),
                new Quiz("3. 밀크 초콜릿엔 탄수화물이", 25, 0, new string[]{ "있다","없다"}),
                new Quiz("4. 피카츄는", 25, 2, new string[]{ "새다","고양이다","쥐다","사슴이다"})
            });
        quizList.Add(2, new Quiz[]
            {
                new Quiz("1. 양피지의 재료는", 25, 0, new string[]{ "가죽이다","나무다","풀이다"}),
                new Quiz("2. 다음 중 퇴실이 가능한 시간은?", 25, 1, new string[]{ "오전 11시 30분", "오후 5시 41분"}),
                new Quiz("3. 다음 중 203호의 교육과정이 아닌 것은?", 25, 1, new string[]{ "360 VR 영상 제작", "360 VR 3D 종이접기", "블렌더 3D 모델링","유니티 C#"}),
                new Quiz("4. 찻잎은 차나무에서 자란다.", 25, 0, new string[]{ "그렇다", "아니다"})
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