using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catcher : MonoBehaviour
{
    public float speed = 0.1f;
    public SceneController scene;

    // Update is called once per frame
    void Update()
    {
        if (scene.isGameStart)
        {
            Vector3 pos = transform.position;
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (pos.x < 1820f)
                {
                    pos.x += speed * Time.deltaTime;
                    transform.position = pos;
                }
                else
                {
                    pos.x = 1820f;
                }
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (pos.x > 125f)
                {
                    pos.x -= speed * Time.deltaTime;
                    transform.position = pos;
                }
                else
                {
                    pos.x = 125f;
                }
            }
        }
    }
}
