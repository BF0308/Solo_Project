using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float highPosY = 1.5f; //��,��Y�� �ִ밪
    public float lowPosY = -1.5f; // �ּҰ�

    public float holeSizeMin = 1f;//��ֹ� �� ����(ž�� ������ ���̰���) �ּҰ�
    public float holeSizeMax = 6f;//�ִ밪

    public Transform topObject;//ž ������Ʈ �� ��ġ��
    public Transform bottomObject;//���ҿ�����Ʈ�� ��ġ��

    public float widthPadding = 4f;//���ع��� ��(�¿����)�� ����
    GameManager gameManager;//���ӸŴ���
    Animator animator;
    Score score;
    ScoreUI scoreUI;
    bool scored = false;
    private void Awake()
    {
        gameManager = GameManager.Instance; //���ӸŴ����� �ν��Ͻ��� �����´�.
        animator = this.GetComponent<Animator>();
        score = Score.Instance;
    }
    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)//�������� ���ع��� �����ϴ� �޼���(������������,���ع��ǰ���)
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);//��ֹ����� ���Ʒ� ������ �������� ����
        float halfHoleSize = holeSize / 2f;//������ ������
        topObject.localPosition = new Vector3(0, halfHoleSize);//ž ������Ʈ�������� y���� ������ ���������� �������� ��ġ�����ش�.
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);//���� ������Ʈ�������� -y���� ������ ���������� �������� ��ġ�����ش�.

        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);//�����Ǵ� x���� �����������ǿ� �е����� �����ش�.
        placePosition.y = Random.Range(lowPosY, highPosY);//�����Ǵ� ���ع��� y�� ��ġ�� �ּҰ��� �ִ밪 ���̸� �������� ���� ���Ѵ�.

        transform.position = placePosition;//x,y���� ��� �־��ش�.

        return placePosition;//�÷��̽� �������� �����Ѵ�.
    }
    private void OnTriggerEnter2D(Collider2D collision)//Obstacle.cs�� ���� ���ӿ�����Ʈ�� �ݶ��̴� Ʈ���Ű� �ߵ��Ǹ�
    {
        if (scored) return;
        if (collision.CompareTag("Player")) 
        {
            animator.SetBool("IsLife", false);
            Score.Instance.AddScore(1);
            scoreUI.UpdateScoreUI();
            scored = true;
        }

    }
    public void CoinLife()
    {
        animator.SetBool("IsLife", true);
        scored = false;
    }

}
