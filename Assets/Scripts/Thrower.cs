using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour
{
    public SceneController scene;
    public GameObject mineralprefab;
    public float speed = 0.1f;
    private float cdirection;
    public bool spawnstart = false;

    private void insmineral()
    {
        Vector3 pos = transform.position;
        Instantiate(mineralprefab, pos, Quaternion.identity);
    }
    
    private void spawnmineral()
    {
        InvokeRepeating("insmineral", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (scene.isGameStart)
        {
            if (!spawnstart)
            {
                spawnmineral();
                spawnstart = true;
            }
            cdirection = Random.Range(0f, 1f);
            Vector3 pos = transform.position;
            if (pos.x < 150f || pos.x > 1750f || cdirection < 0.01f)
            {
                speed *= -1;
                pos.x += speed * Time.deltaTime;
                transform.position = pos;
            }
            else
            {
                pos.x += speed * Time.deltaTime;
                transform.position = pos;
            }
        }
        else
        {
            if (spawnstart)
            {
                spawnstart = false;
            }
            CancelInvoke();
        }
    }
}
