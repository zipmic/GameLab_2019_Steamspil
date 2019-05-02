using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code_TriggerSurprisedBikini : MonoBehaviour
{

    public BikiniGirlBehaviour _bikiniGirl;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            _bikiniGirl.Surprised();
        }
    }
}
