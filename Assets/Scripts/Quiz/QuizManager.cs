using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswers> QnA;
    public GameObject[] options;
    public GameObject QuizPanel;
    public int currentQuestion;

    public TextMeshProUGUI QuestionTxt;



    public bool GreenLight, Dalgona, Glass;

    public PlayerController playerController;
    public GlassGameOVer GlassGameOVer;
    public GameWin gameWin;

    public void Start()
    {
        if (GreenLight)
        {
            GameObject nice = GameObject.FindGameObjectWithTag("Player");
            playerController = nice.GetComponent<PlayerController>();
            GlassGameOVer = null;
            gameWin = null;
        }

        if (Glass)
        {
            GlassGameOVer = FindObjectOfType<GlassGameOVer>();
            gameWin = null;
            playerController = null;
        }

        if (Dalgona)
        {
            gameWin = FindObjectOfType<GameWin>();
            GlassGameOVer = null;
            playerController = null;
        }

        generateQuestion();
    }


    public void GameOver()
    {
        Debug.Log("Game Over");
        QuizPanel.SetActive(false);
        Time.timeScale = 1;
        SoundManager.instance.Play("fail");
        if (GreenLight)
        {
            playerController.die = true;
        }
        if (Glass)
        {
            GlassGameOVer.YouLose = true;
        }
        if (Dalgona)
        {
            gameWin.YouLose = true;
        }
    }

    public void correct()
    {
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
        QuizPanel.SetActive(false);
        if (GreenLight)
        {
            SoundManager.instance.Play("enem");
        }
        SoundManager.instance.Play("correct");
        Time.timeScale = 1;
    }

    void SetAnswer()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    public void generateQuestion()
    {
        if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);
            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswer();
        }
        else
        {
            Debug.Log("Out of questions");
            QuizPanel.SetActive(false);
            Time.timeScale = 1;
            //GameOver();
        }

    }
}
