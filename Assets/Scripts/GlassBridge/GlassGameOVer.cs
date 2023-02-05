using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GlassGameOVer : MonoBehaviour
{
    public bool YouWin = false;
    public bool YouLose = false;
    public LoadScene LoadScene;

    private void Update()
    {
        if (LoadScene.t < 0)
        {
            YouLose = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 2)
        {
            FindObjectOfType<LoadScene>().losepanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

}
