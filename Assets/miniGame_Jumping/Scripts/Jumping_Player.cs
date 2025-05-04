using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping_Player : MonoBehaviour
{
    Animator animator = null;
    Rigidbody2D _rigidbody = null;

    public float flapForce = 6f; //�����ϴ� �� 
    public float forwardSpeed = 3f; //�̵��ϴ� �ӵ�
    public bool isDead = false; //��������
    private float deathCooldown = 0f; //�浹 �� �����ð��ִ� ����

    private bool isFlap = false; //��������Ȯ��

    public bool godMode = false; //�׽�Ʈ�� �����
    GameManager gameManager;
    void Start()
    {
        gameManager = GameManager.Instance;

        animator = transform.GetComponentInChildren<Animator>();//�� ��ũ��Ʈ�� �޸��� Player������Ʈ �Ʒ��� �ִ� Model������Ʈ�� �ִϸ����͸� �����ϱ����� ������
        _rigidbody = transform.GetComponent<Rigidbody2D>();//�� ��ũ��Ʈ�� �޷��ִ� Player������Ʈ�ȿ� �ִ� ������Ʈ�� ������ٵ�2D�� ������

        if (animator == null)//�ִϸ����Ͱ� ������ �����α׸� �ۼ�
        {
            Debug.LogError("Not Founded Animator");
        }

        if (_rigidbody == null)//������ٵ� ������ �����α׸� �ۼ�
        {
            Debug.LogError("Not Founded Rigidbody");
        }
    }

    void Update()
    {
        if (isDead)//�׾�����
        {
            if (deathCooldown <= 0)//��ٿ��� ��������
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))//�����̽��� Ȥ�� ���콺0��Ű�� ��������
                {
                    // ���� �����

                    gameManager.RestartGame();//������ ������Ѵ�.


                }
            }
            else//��ٿ��� ��������
            {
                deathCooldown -= Time.deltaTime;//��ٿ��� �������Ѵ�.
            }
        }
        else//�����ʾҿ��
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))//�����̽��� �Ǵ� ���콺��Ŭ���� ��������
            {
                isFlap = true; //������ true�� �ٲ��ش�
            }
        }
    }

    public void FixedUpdate()
    {
        if (isDead)//�׾�����
            return;//�ٷ� ����

        Vector3 velocity = _rigidbody.velocity;//������ٵ� �����ִ� ���ӵ��� �����´�.
        velocity.x = forwardSpeed;//�������� ������ �����̴¼ӵ��� ���������� ��ӹ޾� �������� �ӵ��� x���� �̵���Ų��.(���ӵ� �ȹ���)

        if (isFlap)//������ ������
        {
            velocity.y += flapForce;//y�࿡ ������ ������ �������� ���Ѵ�
            isFlap = false;//������ ����.(�̰ɾ��ϸ� �ѹ������ϸ� ��������Ǵ»�Ȳ �߻��� �� ����)
        }

        _rigidbody.velocity = velocity;//���ο��� ������ x���� �����ӵ��� y���� ���� ���������� �����Ų��.

        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90);//Clamp�� ���� �����ϴ� �� ���ذ��� ������ٵ��� y�࿡ 10f�� ���� ���̰� ���Ѱ��� -90~90����
        transform.rotation = Quaternion.Euler(0, 0, angle);//���� ���� ����� �̿��� z���� ���� ȸ����Ų��.
    }

    public void OnCollisionEnter2D(Collision2D collision) //�ݶ��̴�2DƮ���Ű�On������ 
    {
        if (godMode)//������
            return;//����

        if (isDead)//�׾�����
            return;//����
        //�� �ΰ��� �ƴ϶��
        isDead = true;//����Ű��
        deathCooldown = 1f; //�״½ð��� 1�ʷ� �����Ѵ�.

        animator.SetInteger("IsDie", 1);//�ִϸ����Ϳ� 
        gameManager.GameOver();//���ӸŴ������ִ� ���ӿ��� ȣ��
    }
}
