using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float highPosY = 1f; //��,��Y�� �ִ밪
    public float lowPosY = -1f; // �ּҰ�

    public float holeSizeMin = 3f;//��ֹ� �� ����(ž�� ������ ���̰���) �ּҰ�
    public float holeSizeMax = 6f;//�ִ밪

    public Transform topObject;//ž ������Ʈ �� ��ġ��
    public Transform bottomObject;//���ҿ�����Ʈ�� ��ġ��

    public float widthPadding = 4f;//���ع��� ��(�¿����)�� ����
    GameManager gameManager;//���ӸŴ���

    private void Start()
    {
        gameManager = GameManager.Instance; //���ӸŴ����� �ν��Ͻ��� �����´�.
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

}
