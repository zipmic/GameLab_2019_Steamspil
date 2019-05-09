using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code_EndBikiniQuest : MonoBehaviour
{

    public GameObject Player;
    public GameObject BikiniGirl;
    public GameObject CanvasBlack;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    bool once;

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && once == false)
        {
            once = true;
            Player.GetComponent<Collider2D>().enabled = false;
            Player.GetComponent<PlayerMovement>().enabled = false;
            BikiniGirl.GetComponent<Animator>().Play("EekAnimation");
            Player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Invoke("CanvasOn", 1.2f);
        }
    }

    void CanvasOn()
    {
        CanvasBlack.gameObject.SetActive(true);
    }
}
