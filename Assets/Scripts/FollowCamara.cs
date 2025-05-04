using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamara : MonoBehaviour
{
    public Transform target;//��ġ�� �ޱ�
    float offsetX; //������ x��
    // Start is called before the first frame update
    void Start()
    {
        if (target == null)//Ÿ���� ������
            return;//����

        offsetX = transform.position.x - target.position.x; //ī�޶���X������ Ÿ����x���� ���� ����
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (target == null)//Ÿ���� ������
            return;//����

        Vector3 pos = transform.position;//Pos�� ��(FllowCamera�� ���� ������Ʈ)��ġ ����
        pos.x = target.position.x + offsetX;//Ÿ���� x��ǥ + �����ų��(ī�޶� �󸶳� Ÿ�ٿ��� ��������)
        transform.position = pos;//�������� ���������� �����Ŵ
    }
}
