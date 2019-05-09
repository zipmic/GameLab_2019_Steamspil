using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "KroghNPC", menuName = "KroghNPC", order = 1)]
public class KroghNPCScriptable : ScriptableObject
{
    public string[] StartDialog;
    public string[] MercyDialog;
    public string[] KillDialog;
    public int LevelToKill;
    public string[] OnKillFail;
   
    
}
