using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassWalk : MonoBehaviour
{
    public bool QuestionQuiz;
    public GameObject QuizPanel;
    public GlassGameOVer manager;
    public QuizManager QuizManager;

    private void Start()
    {
        manager = FindObjectOfType<GlassGameOVer>();
        QuizManager = FindObjectOfType<QuizManager>();

        int i = Random.Range(1, 5);
        if(i == 1 || i == 2|| i == 3)
        {
            QuestionQuiz = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 2)
        {
            if (QuestionQuiz)
            {
                QuizPanel.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    private void Update()
    {
        if (manager.YouLose == true)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.useGravity = true;
            rb.isKinematic = false;

            // Destroy the original glass object
            Destroy(gameObject);
        }
    }
}
