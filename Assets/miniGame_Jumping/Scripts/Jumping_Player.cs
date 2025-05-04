using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping_Player : MonoBehaviour
{
    Animator animator = null;
    Rigidbody2D _rigidbody = null;

    public float flapForce = 6f; //점프하는 힘 
    public float forwardSpeed = 3f; //이동하는 속도
    public bool isDead = false; //생존여부
    private float deathCooldown = 0f; //충돌 후 일정시간있다 죽음

    private bool isFlap = false; //점프여부확인

    public bool godMode = false; //테스트용 갓모드
    GameManager gameManager;
    void Start()
    {
        gameManager = GameManager.Instance;

        animator = transform.GetComponentInChildren<Animator>();//이 스크립트가 달리는 Player오브젝트 아래에 있는 Model오브젝트의 애니메이터를 조작하기위해 가져옴
        _rigidbody = transform.GetComponent<Rigidbody2D>();//이 스크립트가 달려있는 Player오브젝트안에 있는 컴포넌트중 리지드바디2D를 가져옴

        if (animator == null)//애니메이터가 없으면 에러로그를 작성
        {
            Debug.LogError("Not Founded Animator");
        }

        if (_rigidbody == null)//리지드바디가 없으면 에러로그를 작성
        {
            Debug.LogError("Not Founded Rigidbody");
        }
    }

    void Update()
    {
        if (isDead)//죽었으면
        {
            if (deathCooldown <= 0)//쿨다운이 돌았으면
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))//스페이스바 혹은 마우스0번키를 눌렀을때
                {
                    // 게임 재시작

                    gameManager.RestartGame();//게임을 재시작한다.


                }
            }
            else//쿨다운이 남았으면
            {
                deathCooldown -= Time.deltaTime;//쿨다운을 지나게한다.
            }
        }
        else//죽지않았우면
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))//스페이스바 또는 마우스왼클릭이 눌렸을때
            {
                isFlap = true; //점프를 true로 바꿔준다
            }
        }
    }

    public void FixedUpdate()
    {
        if (isDead)//죽었으면
            return;//바로 리턴

        Vector3 velocity = _rigidbody.velocity;//리지드바디가 갖고있는 가속도를 가져온다.
        velocity.x = forwardSpeed;//맨위에서 정의한 움직이는속도를 고정값으로 계속받아 고정적인 속도로 x값을 이동시킨다.(가속도 안받음)

        if (isFlap)//점프를 했을때
        {
            velocity.y += flapForce;//y축에 위에서 정의한 점프력을 더한다
            isFlap = false;//점프를 끈다.(이걸안하면 한번점프하면 계속점프되는상황 발생될 수 있음)
        }

        _rigidbody.velocity = velocity;//내부에서 정의한 x축의 고정속도와 y축의 값을 실질적으로 적용시킨다.

        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90);//Clamp는 값을 제한하는 값 기준값은 리지드바디의 y축에 10f를 곱한 값이고 제한값은 -90~90까지
        transform.rotation = Quaternion.Euler(0, 0, angle);//위에 계산된 결과를 이용해 z축의 값을 회전시킨다.
    }

    public void OnCollisionEnter2D(Collision2D collision) //콜라이더2D트리거가On됐을때 
    {
        if (godMode)//갓모드면
            return;//리턴

        if (isDead)//죽었으면
            return;//리턴
        //위 두개가 아니라면
        isDead = true;//죽음키고
        deathCooldown = 1f; //죽는시간을 1초로 지정한다.

        animator.SetInteger("IsDie", 1);//애니메이터에 
        gameManager.GameOver();//게임매니저에있는 게임오버 호출
    }
}
