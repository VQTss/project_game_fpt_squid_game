using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameOver : MonoBehaviour
{
    public GameObject QuestionQuiz;
    public GameWin gameWin;


    void OnMouseOver()
    {
        if (Input.GetMouseButton(0) && !IsMouseOverUI())
        {
            if (!QuestionQuiz.activeSelf)
            {
                gameWin.YouLose = true;
                GetComponent<BreakFruit>().Run();
            }
        }
    }

    

    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
