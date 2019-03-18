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
    public GameObject regularui;
    public GameObject SCV;
    public GameObject CC;
    public GameObject pauseemenu;
    public GameObject mainmenu;
    public GameObject smsgobject;
    public GameObject fmsgobject;
    public GameObject wmsgobject;
    public GameObject EndMenu;
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

    //click start button
    public void GameStart()
    {
        isFirstScene = true;
        SceneManager.LoadScene("PlayingScene");
        regularui.SetActive(true);
        mainmenu.SetActive(false);
        score = 0;
        life = 3;
        updatescore();
        updatelife();
    }
    //click quit button
    public void GameQuit()
    {
        Application.Quit();
    }

    //click high score button
    public void DisplayHighScore()
    {

    }

    //click pause button
    public void PauseMenu()
    {
        Time.timeScale = 0;
        pauseemenu.SetActive(true);
    }
    //click cross button
    public void resumegame()
    {
        Time.timeScale = 1;
        pauseemenu.SetActive(false);
    }
    //click restart button
    public void Restart()
    {
        EndMenu.SetActive(false);
        fmsgobject.SetActive(false);
        wmsgobject.SetActive(false);
        smsgobject.SetActive(true);
        regularui.SetActive(true);
        SceneManager.LoadScene("PlayingScene");
        score = 0;
        life = 3;
        updatescore();
        updatelife();
        isFirstScene = true;
    }
    //click menu button
    public void BacktoMenu()
    {
        SceneManager.LoadScene("TempMenu");
        EndMenu.SetActive(false);
        fmsgobject.SetActive(false);
        wmsgobject.SetActive(false);
        mainmenu.SetActive(true);
        regularui.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        EndMenu.SetActive(false);
        pauseemenu.SetActive(false);
        regularui.SetActive(false);
        fmsgobject.SetActive(false);
        wmsgobject.SetActive(false);
        smsgobject.SetActive(false);
        isGameStart = false;
        isFirstScene = false;
    }

    // Update is called once per frame
    void Update()
    {
        //win
        if ((score == 100 | life == 0) && isGameStart)
        {
            if(score == 100)
            {
                wmsgobject.SetActive(true);
            }else if(life == 0)
            {
                fmsgobject.SetActive(true);
            }
            EndMenu.SetActive(true);
            regularui.SetActive(false);
            SceneManager.LoadScene("EndScene");
            isGameStart = false;
        }
        //first start
        else if (isFirstScene)
        {
            smsgobject.SetActive(true);
            fmsgobject.SetActive(false);
            wmsgobject.SetActive(false);
            if (Input.GetMouseButton(0))
            {
                SCV = GameObject.FindGameObjectWithTag("SCV");
                CC = GameObject.FindGameObjectWithTag("CC");
                SCV.transform.position = new Vector3(960f, 950f, -10f);
                CC.transform.position = new Vector3(982f, 164f, -10f);
                isGameStart = true;
                isFirstScene = false;
                smsgobject.SetActive(false);
            }
        }
    }
}
