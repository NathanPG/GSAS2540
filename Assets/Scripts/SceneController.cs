using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public bool isGameStart = false;
    public bool isFirstScene = true;
    public bool isGameend = false;
    public Text scoredisplay;
    public Text lifedisplay;
    public AudioSource bgm;
    public GameObject SCV;
    public GameObject CC;
    public int score = 0;
    public int life = 3;
    public void addscore()
    {
        score += 10;
    }

    public void loselife()
    {
        life -= 1;
    }

    public void updatescore()
    {
        scoredisplay.text = string.Format("scores:{0,4}/100", score);
    }

    public void updatelife()
    {
        lifedisplay.text = string.Format("life:{0,4}/3", life);
    }

   

    /*
    private void Awake()
    {
        scoredisplay = GameObject.FindGameObjectWithTag("score").GetComponent<Text>();
        lifedisplay = GameObject.FindGameObjectWithTag("lives").GetComponent<Text>();
        SCV = GameObject.FindGameObjectWithTag("SCV");
        CC = GameObject.FindGameObjectWithTag("CC");
        //bgm = GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>();
    }
    */


    // Start is called before the first frame update
    void Start()
    {
        //bgm.Play();
        isGameStart = false;
        score = 0;
        life = 3;
        updatescore();
        updatelife();
        SCV.transform.position = new Vector3(960f, 950f, -10f);
        CC.transform.position = new Vector3(982f, 164f, -10f);
    }

    // Update is called once per frame
    void Update()
    {
        //win
        if (score == 100 && isGameStart)
        {
            SceneManager.LoadScene("WinScene");
            isGameStart = false;
        }
        //gg
        else if (life == 0 && isGameStart)
        {
            SceneManager.LoadScene("GGScene");
            isGameStart = false;
        }
        //first start
        else if (Input.GetMouseButton(0) && isFirstScene)
        {
            SceneManager.LoadScene("PlayingScene");
            isFirstScene = false;
            isGameStart = true;
        }
        //restart
        else if (!isGameStart)
        {
            if (Input.GetMouseButton(0))
            {
                SCV.transform.position = new Vector3(960f, 950f, -10f);
                CC.transform.position = new Vector3(982f, 164f, -10f);
                score = 0;
                life = 3;
                updatescore();
                updatelife();
                isFirstScene = true;

                SceneManager.LoadScene("StartScene");
            }
        }
    }
}
