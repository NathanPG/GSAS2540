using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public AudioSource MissSound;
    public AudioSource CaughtSound;
    public GameObject mycanvas;
    public SceneController scene;

    void Start()
    {
        MissSound = GameObject.FindGameObjectWithTag("miss").GetComponent<AudioSource>();
        CaughtSound = GameObject.FindGameObjectWithTag("caught").GetComponent<AudioSource>();
        mycanvas = GameObject.FindGameObjectWithTag("UI");
        scene = mycanvas.GetComponent<SceneController>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CC")
        {
            CaughtSound.Play();
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
            MissSound.Play();
            Destroy(this.gameObject);
            scene.loselife();
            scene.updatelife();
        }
    }
}
