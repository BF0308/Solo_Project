using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    GameManager gameManager;


    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Jumping_Player player = collision.GetComponent<Jumping_Player>();//부딪친 객체의 컴포넌트Player를 선언
        if (player != null) //플레이어가 존재하면
            gameManager.AddScore(1); //스코어를 1올려준다
    }
}
