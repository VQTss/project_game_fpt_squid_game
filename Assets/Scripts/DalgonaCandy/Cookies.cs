using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cookies : MonoBehaviour
{
    public bool QuestionQuiz;
    private bool alreadyClick = false;

    private GameWin manager;
    public bool Done { get; private set; }

    MeshRenderer m_Renderer;

    public GameObject QuizPanel;

    void Start()
    {
        //Fetch the mesh renderer component from the GameObject
        m_Renderer = GetComponent<MeshRenderer>();
        if (!QuestionQuiz)
        {
            QuizPanel = null;
        }
    }

    public void Initialize(GameWin manager)
    {
        this.manager = manager;
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButton(0) && !IsMouseOverUI())
        {
            if (!alreadyClick)
            {
                if (!QuestionQuiz)
                {
                    m_Renderer.material.color = Color.green;
                    Done = true;
                    manager.CheckForWin();
                    SoundManager.instance.Play("candy");
                }
                else
                {
                    SoundManager.instance.Play("candy");
                    m_Renderer.material.color = Color.green;
                    Done = true;
                    manager.CheckForWin();
                    QuestionQuiz = false;
                    Time.timeScale = 0;
                    QuizPanel.SetActive(true);
                }
                alreadyClick = true;
            }
        }
    }

    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
