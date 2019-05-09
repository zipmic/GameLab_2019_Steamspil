using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class KroghNPC : MonoBehaviour
{
    [SerializeField] private KroghNPCScriptable knc;
    private bool dead = false;
    public KroghNPCScriptable GetKNC()
    {
        return knc;
    }
    public bool GetDead()
    {
        return dead;
    }
    public void Kill()
    {
        dead = true;
        transform.parent.GetComponent<Animator>().enabled = false;
        transform.Rotate(new Vector3(0, 0, -90));
    }
    public void Save()
    {
        dead = true;
    }
}
