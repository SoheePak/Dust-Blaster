using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurMove : MonoBehaviour
{
    public Transform fur_trans;
    private float fur_Y;
    private float fur_Move;
    private float fur_Min;
    private bool movingDown = true; // 캐릭터가 아래로 이동 중인지 여부

    // Start is called before the first frame update
    void Start()
    {
        fur_trans = GetComponent<Transform>();
        fur_Y = fur_trans.position.y;
        fur_Move = fur_Y;
        fur_Min = fur_Y - 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (movingDown)
        {
            fur_Move -= Time.deltaTime*2; // 아래로 이동
            if (fur_Move <= fur_Min)
            {
                fur_Move = fur_Min;
                movingDown = false; // 방향을 위로 변경
            }
        }
        else
        {
            fur_Move += Time.deltaTime*2; // 위로 이동
            if (fur_Move >= fur_Y)
            {
                fur_Move = fur_Y;
                movingDown = true; // 방향을 아래로 변경
            }
        }

        // fur_Move 값을 Transform 위치에 반영
        fur_trans.position = new Vector3(fur_trans.position.x, fur_Move, fur_trans.position.z);
    }
}
