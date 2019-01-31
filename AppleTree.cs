using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]

    public GameObject applePrefab;

    //speed at which the AppleTree moves
    public float speed = 1f;

    //point where the AppleTree turns around
    public float leftanfRightEdge = 10f;

    //chance that the AppleTree will change directions
    public float chanceToChangeDirections = 0.1f;

    //rate at which the apples will be instantiated
    public float secondsBetweenAppleDrops = 1f;

    void Start(){
        //Dropping Apples every second
        Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }

    void Update(){
        //basic movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        //changing direction
        if (pos.x < -leftanfRightEdge)
        {
            //move right
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftanfRightEdge)
        {
            //move left
            speed = -Mathf.Abs(speed);
        }
    }

    private void FixedUpdate()
    {
        //this makes the changing of direction time based
        if (Random.value < chanceToChangeDirections)
        {
            //change direction
            speed *= -1;
        }
    }
}
