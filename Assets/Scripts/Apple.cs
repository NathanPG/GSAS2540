using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public AudioSource MissSound;
    public AudioSource CaughtSound;
    //public AudioController AudioController;
    public SceneController scene;

    void Start()
    {
        MissSound = GameObject.FindGameObjectWithTag("miss").GetComponent<AudioSource>();
        CaughtSound = GameObject.FindGameObjectWithTag("caught").GetComponent<AudioSource>();
        //AudioController = GameObject.FindGameObjectWithTag("UI").GetComponent<AudioController>();
        scene = GameObject.FindGameObjectWithTag("UI").GetComponent<SceneController>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CC")
        {
            if (PlayerPrefs.GetInt("isSfxOn") == 1)
            {
                CaughtSound.Play();
            }
            Destroy(this.gameObject);
            scene.addscore();
            scene.updatescore();
        }
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if (!scene.isGameStart)
        {
            Destroy(this.gameObject);
        }
        if (pos.y <= 45)
        {
            if (PlayerPrefs.GetInt("isSfxOn") == 1)
            {
                MissSound.Play();
            }
            Destroy(this.gameObject);
            scene.loselife();
            scene.updatelife();
        }
    }
}
