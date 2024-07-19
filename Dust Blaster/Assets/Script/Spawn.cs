using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using Unity.VisualScripting;
using UnityEngine;
public class Spawn : MonoBehaviour
{
    public GameObject prefab; //여러 프리팹을 저장하는 배열(생성한 오브젝트들 (과일 종류))
    AudioSource audio; // 오디오 소스를 저장할 변수
    public float Xmax = 5f;
    public float Xmin = -5f;
    public float Ymax = 2.5f;
    public float Ymin = -2.5f;
    public float Zmax = 19f;
    public float Zmin = 10f;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        StartCoroutine(WaitAndSpawn());
        //coroutine은 반환형을 IEnumerator로 해야함.
        //coroutine 동시에 실행할 수 있는 함수.
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator WaitAndSpawn()
    {
        while (!GameManager.instance.isEnd)
        {
            float waitTime = Random.Range(2.0f, 4.0f); //2~4초 사이의 랜덤한 대기 시간
            yield return new WaitForSeconds(waitTime);
            // yield return + 조건을 작성.
            //waitTime만큼 대기한 후 그 다음 줄 실행
            // 리턴을 만나면 밑에 함수를 실행함.무슨 말일까...?
            // 몇 초있다가 수행함.... 음...

            for (int i = 0; i < 3; i++)
            {
                float Xpos = Random.Range(Xmin, Xmax);
                float Ypos = Random.Range(Ymin, Ymax);
                float Zpos = Random.Range(Zmin, Zmax);
                // 오브젝트를 생성할 위치를 랜덤하게 생성
                GameObject obj = Instantiate(prefab, new Vector3(Xpos, Ypos, Zpos),
                                Quaternion.identity);
                //선택된 프리팹을 선택된 위치에 생성(위에 랜덤값으로 프리팹, 위치를 정함.)
                Destroy(obj, 5f);
                // 5초 뒤에 오브젝트 파괴
            }
        }
        //코루틴이 끝나면 오디오를 재생
        audio.Play();
    }
}
