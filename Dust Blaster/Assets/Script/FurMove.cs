using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurMove : MonoBehaviour
{
    public Transform fur_trans;
    private float fur_Y;
    private float fur_Move;
    private float fur_Min;
    private bool movingDown = true; // ĳ���Ͱ� �Ʒ��� �̵� ������ ����

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
            fur_Move -= Time.deltaTime*2; // �Ʒ��� �̵�
            if (fur_Move <= fur_Min)
            {
                fur_Move = fur_Min;
                movingDown = false; // ������ ���� ����
            }
        }
        else
        {
            fur_Move += Time.deltaTime*2; // ���� �̵�
            if (fur_Move >= fur_Y)
            {
                fur_Move = fur_Y;
                movingDown = true; // ������ �Ʒ��� ����
            }
        }

        // fur_Move ���� Transform ��ġ�� �ݿ�
        fur_trans.position = new Vector3(fur_trans.position.x, fur_Move, fur_trans.position.z);
    }
}
