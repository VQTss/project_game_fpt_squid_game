using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWin : MonoBehaviour
{
    private Cookies[] segments;

    public bool YouWin = false;
    public bool YouLose = false;

    public LoadScene LoadScene;

    public void Update()
    {
        if(LoadScene.t <= 0)
        {
            YouLose = true;
        }
        
        if (YouWin)
        {
            YouLose = false;
            LoadScene.startcount = false;
            StartCoroutine(winplayer());
        }

        if (YouLose)
        {
            LoadScene.startcount = false;
            StartCoroutine(dieplayer());
        }
    }

    public void CountPieces()
    {
        segments = GetComponentsInChildren<Cookies>();
        foreach (var segment in segments)
        {
            segment.Initialize(this);
        }
    }


    public void CheckForWin()
    {
        foreach (var segment in segments)
        {
            if(!segment.Done)
            {
                return;
            }  
        }
        YouWin = true;    
    }

    public IEnumerator dieplayer()
    {
        Debug.Log("GAME OVER");
        yield return new WaitForSeconds(2f);
        FindObjectOfType<LoadScene>().losepanel.SetActive(true);
    }


    public IEnumerator winplayer()
    {
        Debug.Log("You WON");
        yield return new WaitForSeconds(2f);
        FindObjectOfType<LoadScene>().winpanel.SetActive(true);
    }
}
