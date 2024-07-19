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
            RaycastHit hit;//RaycastHit 구조체는 Raycast가 충돌한 정보를 저장함.

            //Raycast, 충돌 함수, 카메라가 바라보는 있는 위치에 과일이 부딪혔는지
            // 콜라이더가 없으면 Raycast를 사용할 수 없다.
            //Raycast는 카메라의 위치에서 카메라가 바라보는 방향으로 레이저를 쏘아 충돌을 감지함.
            if (Physics.Raycast(camera.transform.position,
                camera.transform.forward, out hit))
            {      // 결과가 hit라는 변수에 입력되어서 out(결과값을 돌려받는 키워드)
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
