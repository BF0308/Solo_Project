using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int obestacleCount = 0; //���ع� ����(�ʱⰪ)
    public int numBgCount = 5;//��׶���,ž�׶���,���ұ׶��� �� ���� �� ������ 5�����̶� 5�� �������̴�.
    public Vector3 obstacleLastPosition = Vector3.zero;//���ع� ��������ġ�� 0,0,0���� ����

    void Start()
    {
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>();//���ع����� �迭�� ���� (Find���� ��ü������ ã�� ��쿡�� ���̱⶧���� start��Awake���� ���� ����Ѵ�.)
        obstacleLastPosition = obstacles[0].transform.position;//ù��°�� �޾ƿ� ���ع��� ��ǥ���� �޾Ƽ� �����Ѵ�.
        obestacleCount = obstacles.Length;//���ع��� ������ �迭�� ������ �����Ѵ�.

        for (int i = 0; i < obestacleCount; i++)//���ع��� ������ŭ �ݺ�
        {
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obestacleCount);//���ع��� ��������ǥ���� �� ���ع��� SetRandomPlace�޼��带 Ȱ���� ���� �������Ѵ�.
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)//�浹�� ������(�ݶ��̴�2D�� Trigger�� On�� ������)
    {
        Debug.Log("Triggered: " + collision.name); //Ʈ���Ű� �ߵ��� �Ѷ��̴��� �̸��� �α׿�����

        if (collision.CompareTag("BackGround")) //�±װ� BackGround��� 
        {
            float widthOfBgObject = ((BoxCollider2D)collision).size.x;//�浹ü�� �ڽ��ݶ��̴�2D�������� �ٲٰ� x���� �����Ѵ�. 
            //���⼭ �ڽ��ݶ��̴�2D�������� �ٲ������� ��׶��忡 ��� �ڽ��ݶ��̴� 2D�� �޾ұ� �����̴�.
            Vector3 pos = collision.transform.position;//�浹ü�� ��ġ���� ����

            pos.x += widthOfBgObject * numBgCount;//�浹ü�� x���� ������Ʈ������x���� �ش������Ʈ�� �� ���� �� ���ؼ� �����ش�.
            collision.transform.position = pos;//�浹ü�� ��ǥ���� �����Ѵ�.
            return;//����
        }

        Obstacle obstacle = collision.GetComponent<Obstacle>();//�浹������ �浹ü�� ���ع��̸� obstacle�̶�� ������ �����Ѵ�.
        if (obstacle)//���ع��� �ִٸ�
        {
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obestacleCount);//�ٽ� �����
        }
    }
}
