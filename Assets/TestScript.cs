using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public GameObject obj;
    public float speed = 10;
    public Vector3 direction = new Vector3(1f,0f,0f);

    float ranspeed = Random.Range(0f, 10f);

    public Vector3 right = Vector3.right;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            pos.x += speed;
            transform.position = pos;
        }else if (Input.GetKey(KeyCode.LeftArrow))
        {
            pos.x -= speed;
            transform.position = pos;
        }


        //transform.position += direction * speed;
    }
}
