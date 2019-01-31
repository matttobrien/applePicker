using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;
    // Start is called before the first frame update
    void Start()
    {
        //find a reference to the ScoreCounter GameObject
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        //get the text component of that GameObject
        scoreGT = scoreGO.GetComponent<Text>();
        //sets the starting number of points to 0
        scoreGT.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        //gets the current screen position of the mouse from input
        Vector3 mousePos2D = Input.mousePosition;
        //the cameras z position sets how far to push the mouse into 3D 
        mousePos2D.z = -Camera.main.transform.position.z;
        //convert the point from 2D screen space into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        //move the x psotion of the basket to the x postion of the mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll){
        //find out what hits the basket
        GameObject collidedWith = coll.gameObject;
        if(collidedWith.tag == "Apple"){
            //destroys the gameObject that collided
            Destroy(collidedWith);
            int score = int.Parse(scoreGT.text);
            score += 100;
            //coverts the score back to a String and displays it
            scoreGT.text = score.ToString();
            //tracks the current high score
            if(score > HighScore.score){
                HighScore.score = score;
            }
        }
    }
}
