using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThePlayerWatch : MonoBehaviour
{

    public GameObject Player;

    public float Speed = 10;
    public float FollowUntilDistance = 3;

    public float FollowAfterDistance = 6;

    private bool _follow = true;




    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(transform.position, Player.transform.position);
        print(distance);
        if(_follow == false)
        {
            if (distance > 6)
            {
                _follow = true;
            }
          
           
        }

        if(_follow)
        {
            transform.position = Vector3.Lerp(transform.position, Player.transform.position - Player.transform.up, Time.deltaTime*0.1f*Speed);

            if (distance < 3)
            {
                _follow = false;
            }
        }

    }
}
