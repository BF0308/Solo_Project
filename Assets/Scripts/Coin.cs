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
        Jumping_Player player = collision.GetComponent<Jumping_Player>();//�ε�ģ ��ü�� ������ƮPlayer�� ����
        if (player != null) //�÷��̾ �����ϸ�
            gameManager.AddScore(1); //���ھ 1�÷��ش�
    }
}
