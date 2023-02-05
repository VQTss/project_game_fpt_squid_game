using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionTrigger : MonoBehaviour
{
    public GameObject QuizPanel;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            QuizPanel.SetActive(true);
            
            Time.timeScale = 0;
        }
    }
}
