using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code_EndBikiniQuest : MonoBehaviour
{

    public GameObject Player;
    public GameObject BikiniGirl;
    
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
            Player.GetComponent<Collider>().enabled = false;

        }
    }
}
