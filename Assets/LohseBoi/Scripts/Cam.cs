using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{

    public GameObject Player;

    private Vector3 Offset;

    // Start is called before the first frame update
    void Start()
    {
        //Setting the offset-distance
        Offset = transform.position - Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Making the camera move with the player, and that the camera dosnet end up on the same lavel (z-axis) as the player (The offset-distance)
        transform.position = Player.transform.position + Offset;

        //Making sure the camera can't cross the maps borders
        if (transform.position.y <= -2) transform.position = new Vector3(transform.position.x, -2f, transform.position.z);
        if (transform.position.y >= 9.23) transform.position = new Vector3(transform.position.x, 9.23f, transform.position.z);
        if (transform.position.x <= -15.58) transform.position = new Vector3(-15.58f, transform.position.y, transform.position.z);
        if (transform.position.x >= 16.78) transform.position = new Vector3(16.78f, transform.position.y, transform.position.z);
    }
}
