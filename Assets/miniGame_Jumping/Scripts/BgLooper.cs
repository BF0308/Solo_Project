using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int obestacleCount = 0; //방해물 갯수(초기값)
    public int numBgCount = 5;//백그라운드,탑그라운드,바텀그라운드 의 각각 총 갯수가 5개씩이라 5를 넣은것이다.
    public Vector3 obstacleLastPosition = Vector3.zero;//방해물 마지막위치는 0,0,0으로 설정

    void Start()
    {
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>();//방해물들을 배열에 저장 (Find같은 전체적으로 찾는 경우에는 무겁기때문에 start나Awake에서 많이 사용한다.)
        obstacleLastPosition = obstacles[0].transform.position;//첫번째로 받아온 방해물의 좌표값을 받아서 저장한다.
        obestacleCount = obstacles.Length;//방해물의 갯수는 배열의 갯수로 저장한다.

        for (int i = 0; i < obestacleCount; i++)//방해물의 갯수만큼 반복
        {
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obestacleCount);//방해물의 마지막좌표값은 각 방해물의 SetRandomPlace메서드를 활용해 계산과 생성을한다.
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)//충돌을 했을때(콜라이더2D에 Trigger가 On이 됐을때)
    {
        Debug.Log("Triggered: " + collision.name); //트리거가 발동한 롤라이더의 이름을 로그에남김

        if (collision.CompareTag("BackGround")) //태그가 BackGround라면 
        {
            float widthOfBgObject = ((BoxCollider2D)collision).size.x;//충돌체를 박스콜라이더2D형식으로 바꾸고 x값을 저장한다. 
            //여기서 박스콜라이더2D형식으로 바꾼이유는 백그라운드에 모두 박스콜라이더 2D를 달았기 때문이다.
            Vector3 pos = collision.transform.position;//충돌체의 위치값을 저장

            pos.x += widthOfBgObject * numBgCount;//충돌체의 x값을 오브젝트사이즈x값과 해당오브젝트의 총 갯수 를 곱해서 더해준다.
            collision.transform.position = pos;//충돌체의 좌표값을 지정한다.
            return;//리턴
        }

        Obstacle obstacle = collision.GetComponent<Obstacle>();//충돌했을때 충돌체가 방해물이면 obstacle이라는 변수에 선언한다.
        if (obstacle)//방해물이 있다면
        {
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obestacleCount);//다시 재생성
        }
    }
}
