using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.PlayerSettings;

public class FollowCamera : MonoBehaviour
{
    GamesceneMove gamesceneMove;
    public UnityEngine.SceneManagement.Scene scene;
    public Transform target;//��ġ�� �ޱ�
    private float offsetX; //������ x��
    private float offsetY;
    // Start is called before the first frame update
    private void Start()
    {
        if (target == null)//Ÿ���� ������
            return;//����

        offsetX = transform.position.x - target.position.x; //ī�޶���X������ Ÿ����x���� ���� ����
        offsetY = transform.position.y - target.position.y; //ī�޶���X������ Ÿ����x���� ���� ����
    }

    private void FixedUpdate()
    {
        if (target == null)//Ÿ���� ������
            return;//����
        string currentScene = SceneManager.GetActiveScene().name;
        Vector3 pos = transform.position;//Pos�� ��(FllowCamera�� ���� ������Ʈ)��ġ ����
        pos.x = target.position.x + offsetX;//Ÿ���� x��ǥ + �����ų��(ī�޶� �󸶳� Ÿ�ٿ��� ��������)

        if (GamesceneMove.isMain)
        {
            pos.x = target.position.x + offsetX;
            pos.y = target.position.y + offsetY;
        }
        else if (!GamesceneMove.isMain)
        {
            pos.x = target.position.x + offsetX;
        }
        

        transform.position = pos;//�������� ���������� �����Ŵ 
    }

}
