using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KroghPlayer : MonoBehaviour
{
    [SerializeField] private GameObject[] btns;
    [SerializeField] private GameObject[] blackBoards;
    private bool inRangeOfPlayer, MidChoice;
    private KroghNPC knpc;
    [SerializeField] private Sprite attackSprite;
    [SerializeField]  private SpriteRenderer sr;
    private int level = 0;
    private int EncountersDone = 0;
    private int mercypoints;
    [SerializeField]  private TextMeshProUGUI convotext,lvltext;
    private int[] levels = new int[7] {1, 5, 15, 30, 60, 100, 1000};
    private string[] ranks = new string[7] { "Noob", "Crook", "Man", "Gangster", "Capo", "Gang*star", "BOSS" };
    [SerializeField] private GameObject Knife, Blood, Saved;
    // Start is called before the first frame update

private void UpdateLvlText()
    {
        lvltext.text = levels[level].ToString() + " - " + ranks[level];
    }
    // Update is called once per frame
    void Update()
    {
        if (inRangeOfPlayer)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                btns[0].SetActive(false);
                Camera.main.orthographicSize = 2;
                blackBoards[0].SetActive(true);
                blackBoards[1].SetActive(true);
                convotext.enabled = true;
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                transform.position = knpc.transform.position + new Vector3(-1, 0, 0);
                GetComponent<PlayerMovement>().enabled = false;
                sr.sprite = attackSprite;
                inRangeOfPlayer = false;
                StartCoroutine(Convostart());
                lvltext.enabled = false;


            }
        }
        else if (MidChoice)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                StartCoroutine(ConvoKill());

            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                StartCoroutine(ConvoMercy());
            }
        }
    }
private void EndConvo()
    {
        
        Camera.main.orthographicSize = 5;
        blackBoards[0].SetActive(false);
        blackBoards[1].SetActive(false);
        convotext.enabled = false;
        GetComponent<PlayerMovement>().enabled = true;
        lvltext.enabled = true;
        EncountersDone += 1;

    }
private IEnumerator Convostart()
    {

        for (int i = 0; i < knpc.GetKNC().StartDialog.Length; i++)
        {
            convotext.text = knpc.GetKNC().StartDialog[i];
            yield return new WaitForSeconds(2);
        }
        btns[1].SetActive(true);
        btns[2].SetActive(true);
        MidChoice = true;
        
    }
 private IEnumerator ConvoKill()
    {
        MidChoice = false;
        btns[1].SetActive(false);
        btns[2].SetActive(false);
        if (level >= knpc.GetKNC().LevelToKill)
        {
            for (int i = 0; i < knpc.GetKNC().KillDialog.Length; i++)
            {
                convotext.text = knpc.GetKNC().KillDialog[i];
                yield return new WaitForSeconds(2);
            }
            convotext.enabled = false;
            Knife.SetActive(true);


            yield return new WaitForSeconds(2);
            knpc.Kill();
            Instantiate(Blood, knpc.transform.position, transform.rotation);
            level += 1;
            UpdateLvlText();
            EndConvo();
            Knife.SetActive(false);
            
        }
        else
        {
            for(int i = 0; i < knpc.GetKNC().OnKillFail.Length; i++)
            {
                convotext.text = knpc.GetKNC().OnKillFail[i];
                yield return new WaitForSeconds(2);
            }
            EndConvo();
        }
    }
 private IEnumerator ConvoMercy()
 {
        MidChoice = false;
        btns[1].SetActive(false);
        btns[2].SetActive(false);
        for (int i = 0; i < knpc.GetKNC().MercyDialog.Length; i++)
        {
            convotext.text = knpc.GetKNC().MercyDialog[i];
            yield return new WaitForSeconds(2);
        }
        convotext.enabled = false;
        EndConvo();
        knpc.Save();
        mercypoints += 1;
        Instantiate(Saved, knpc.transform.position, transform.rotation);
    }



    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("KroghNPC"))
        {
            knpc = col.GetComponent<KroghNPC>();
            if (!knpc.GetDead()) {
                btns[0].SetActive(true);
                inRangeOfPlayer = true;
            }
           
           
        }
    }
    void OnTriggerExit2D()
    {
        btns[0].SetActive(false);
        inRangeOfPlayer = false;
    }
}
