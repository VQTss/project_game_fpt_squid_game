using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    public GameObject startpanel, gameplaypanel, losepanel, winpanel;
    public Text timershow;
    public TextMeshProUGUI tm;
    public float t = 65;
    public bool startcount = true;

    public bool glassBridge;

    private void Start()
    {
        if (glassBridge)
        {
            timershow = null;
        }
    }

    private void Update()
    {
        if (startcount)
        {
            if (t > 0)
            {
                t -= Time.deltaTime;
                int a = (int)t;
                if (!glassBridge)
                {
                    timershow.text = a.ToString();
                }
                else
                {
                    tm.text = a.ToString();
                }
            }
        }
    }

    public void Win()
    {
        SceneManager.LoadScene(2);
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(0);
    }
}
