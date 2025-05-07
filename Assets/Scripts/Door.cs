using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject EventZone;
    public GameObject Close;
    [SerializeField] private BoxCollider2D DoorEvent;
    public TextMeshProUGUI DoorUI;
    private void Awake()
    {
        DoorEvent = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DoorUI.gameObject.SetActive(true);
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.F))
            Close.gameObject.SetActive(false);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        DoorUI.gameObject.SetActive(false);
    }

}
