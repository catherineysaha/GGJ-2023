using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public Transform body;
    public Rigidbody2D rigid;
    public float topRange;
    public float bottomRange;
    public float leftRange;
    public float rightRange;
    public Vector2 speed;
    // Start is called before the first frame update

    private Vector2 startPos;
    
    private Vector3 movement;
    void Start()
    {
        body = GetComponentInParent<Transform>();
        rigid = GetComponentInParent<Rigidbody2D>();
        startPos = body.position;
        movement = speed;
    }

    // Vector3 movement = new Vector3(0,0,0);
    
    // Update is called once per frame
    void Update()
    {
        
        if (body.position.x < startPos.x - leftRange){
            movement += new Vector3(speed.x,0,0);
        } else if (body.position.x > startPos.x + rightRange){
            movement -= new Vector3(speed.x,0,0);
        }

        if (body.position.y > startPos.y + topRange){
            movement -= new Vector3(0,speed.y,0);
        } else if (body.position.y < startPos.y - bottomRange){
            movement += new Vector3(0,speed.y,0);
        } 
        print(body.position);
        print(movement);
        body.position += movement;
    }

}
