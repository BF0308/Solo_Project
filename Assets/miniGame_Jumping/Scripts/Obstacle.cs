using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float highPosY = 1f; //상,하Y값 최대값
    public float lowPosY = -1f; // 최소값

    public float holeSizeMin = 3f;//장애물 간 공간(탑과 바텀의 사이공간) 최소값
    public float holeSizeMax = 6f;//최대값

    public Transform topObject;//탑 오브젝트 의 위치값
    public Transform bottomObject;//바텀오브젝트의 위치값

    public float widthPadding = 4f;//방해물의 폭(좌우공간)을 정의
    GameManager gameManager;//게임매니저

    private void Start()
    {
        gameManager = GameManager.Instance; //게임매니저의 인스턴스를 가져온다.
    }
    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)//랜덤으로 방해물을 생성하는 메서드(마지막포지션,방해물의갯수)
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);//장애물간의 위아래 공간을 랜덤으로 지정
        float halfHoleSize = holeSize / 2f;//반으로 나눈다
        topObject.localPosition = new Vector3(0, halfHoleSize);//탑 오브젝트기준으로 y축을 반으로 나눈값으로 실질적인 배치를해준다.
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);//바텀 오브젝트기준으로 -y축을 반으로 나눈값으로 실질적인 배치를해준다.

        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);//생성되는 x축은 마지막포지션에 패딩값을 더해준다.
        placePosition.y = Random.Range(lowPosY, highPosY);//생성되는 방해물의 y값 위치는 최소값과 최대값 사이를 랜덤으로 돌려 정한다.

        transform.position = placePosition;//x,y값을 모두 넣어준다.

        return placePosition;//플레이스 포지션을 리턴한다.
    }

}
