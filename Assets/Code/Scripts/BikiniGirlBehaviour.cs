using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikiniGirlBehaviour : MonoBehaviour
{

    private Animator _anim;

    private bool _once;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public void Surprised()
    {
        if(_once == false)
        {
            _once = true;
            _anim.Play("Surprised_walkaway");

        }
    }
}
