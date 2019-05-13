using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MapClocks : MonoBehaviour
{
    public TextMeshPro Action;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Action.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y + 1f, -1);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Action.transform.position = new Vector3(Action.transform.position.x,Action.transform.position.y, -10f);
    }
}
