using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottonY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>();
        for(int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottonY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AppleDestroyed(){
        //destroys all of the falling apples
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach(GameObject tGo in tAppleArray){
            Destroy(tGo);
        }
        //destroys one of the baskets
        //get the index of the last basket in basketList
        int basketIndex = basketList.Count-1;
        //get a reference to that Basket GameObject
        GameObject tBasketGO = basketList[basketIndex];
        //removes the basket from the list then destorys the GameObject
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);
        //if there are no baskets left then restart the game
        if(basketList.Count == 0){
            SceneManager.LoadScene("Scene0");
        }
    }
}
