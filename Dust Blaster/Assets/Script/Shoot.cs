using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject camera;
    public GameObject prefab;
    AudioSource audio;
    public AudioClip shoot;
    public AudioClip attack;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    public void Fire()
    {
        if(GameManager.instance.isEnd == false)
        {
            audio.PlayOneShot(shoot);
            RaycastHit hit;//RaycastHit ����ü�� Raycast�� �浹�� ������ ������.

            //Raycast, �浹 �Լ�, ī�޶� �ٶ󺸴� �ִ� ��ġ�� ������ �ε�������
            // �ݶ��̴��� ������ Raycast�� ����� �� ����.
            //Raycast�� ī�޶��� ��ġ���� ī�޶� �ٶ󺸴� �������� �������� ��� �浹�� ������.
            if (Physics.Raycast(camera.transform.position,
                camera.transform.forward, out hit))
            {      // ����� hit��� ������ �ԷµǾ out(������� �����޴� Ű����)
                if (hit.transform.tag == "Fur")
                {
                    Destroy(hit.transform.gameObject);
                    Instantiate(prefab, hit.point, Quaternion.LookRotation(hit.normal));
                    GameManager.instance.AddScore(1);
                    audio.PlayOneShot(attack);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
