using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class miniGame_Jumping_NPC : MonoBehaviour
{
    public Text talkUI;
    private Collider2D npccollider;
    public GameObject miniGameUI;
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI highScoreText;
    // Start is called before the first frame update
    private void Awake()
    {
        npccollider = GetComponent<Collider2D>();
        miniGameUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            talkUI.gameObject.SetActive(true);   
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && talkUI.gameObject.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                miniGameUI.SetActive(true);
            }
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            talkUI.gameObject.SetActive(false);
            miniGameUI.SetActive(false);
        }
    }

}
