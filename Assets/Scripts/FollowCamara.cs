using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamara : MonoBehaviour
{
    public Transform target;//위치값 받기
    float offsetX; //적용할 x값
    // Start is called before the first frame update
    void Start()
    {
        if (target == null)//타겟이 없으면
            return;//리턴

        offsetX = transform.position.x - target.position.x; //카메라의X값에서 타겟의x값을 빼서 저장
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (target == null)//타겟이 없으면
            return;//리턴

        Vector3 pos = transform.position;//Pos에 내(FllowCamera가 붙은 오브젝트)위치 저장
        pos.x = target.position.x + offsetX;//타겟의 x좌표 + 적용시킬값(카메라를 얼마나 타겟에서 떨어질지)
        transform.position = pos;//포지션을 실질적으로 적용시킴
    }
}
