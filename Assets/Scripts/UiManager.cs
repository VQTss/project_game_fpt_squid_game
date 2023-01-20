
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    public Text LevelText,secondmessage;
    public bool skinEnter;
    public GameObject red, green;
    public GameObject ingamepanel;
    public GameObject playerSelectionPanel;
    public GameObject startpanel,gameplaypanel,losepanel,winpanel;
    public GameObject wineffet;
    public Text timershow;
    public float t = 65;
    public bool startcount;
    public GameObject bloodeefect;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.Play("start");
        Advertisements.Instance.Initialize();
        Advertisements.Instance.ShowBanner(BannerPosition.BOTTOM);
        //LevelText.text = "Level " + (gamemanager.instance.getLevel() + 1);
    }

    private void Update()
    {
        if(startcount)
        {
            t -= Time.deltaTime;
            int a = (int)t;
            timershow.text = a.ToString();
        }
    }

    //public void skinmenu()
    //{
    //    // sound
    //    SoundManager.instance.Play("click");
    //    skinEnter = true;
    //    playerSelectionPanel.SetActive(true);
    //    ingamepanel.SetActive(false);
    //}

    public void btn_retry()
    {
        SoundManager.instance.stop("enem");
        SoundManager.instance.stop("search");
        // sound
        //SoundManager.instance.Play("click");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //public void nextlvl()
    //{
    //    gamemanager.instance.setLevel(gamemanager.instance.getLevel() + 1);
    //    if (gamemanager.instance.LevelsContenu.Length <= gamemanager.instance.getLevel())
    //        return;
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //}

    public void btnstart()
    {
        
        SoundManager.instance.stop("start");
        SoundManager.instance.Play("click");
        FindObjectOfType<PlayerController>().GmRun = true;
        startpanel.SetActive(false);
        gameplaypanel.SetActive(true);
        startcount = true;
    }
}
