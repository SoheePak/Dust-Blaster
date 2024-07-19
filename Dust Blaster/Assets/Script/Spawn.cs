using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using Unity.VisualScripting;
using UnityEngine;
public class Spawn : MonoBehaviour
{
    public GameObject prefab; //���� �������� �����ϴ� �迭(������ ������Ʈ�� (���� ����))
    AudioSource audio; // ����� �ҽ��� ������ ����
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
        //coroutine�� ��ȯ���� IEnumerator�� �ؾ���.
        //coroutine ���ÿ� ������ �� �ִ� �Լ�.
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator WaitAndSpawn()
    {
        while (!GameManager.instance.isEnd)
        {
            float waitTime = Random.Range(2.0f, 4.0f); //2~4�� ������ ������ ��� �ð�
            yield return new WaitForSeconds(waitTime);
            // yield return + ������ �ۼ�.
            //waitTime��ŭ ����� �� �� ���� �� ����
            // ������ ������ �ؿ� �Լ��� ������.���� ���ϱ�...?
            // �� ���ִٰ� ������.... ��...

            for (int i = 0; i < 3; i++)
            {
                float Xpos = Random.Range(Xmin, Xmax);
                float Ypos = Random.Range(Ymin, Ymax);
                float Zpos = Random.Range(Zmin, Zmax);
                // ������Ʈ�� ������ ��ġ�� �����ϰ� ����
                GameObject obj = Instantiate(prefab, new Vector3(Xpos, Ypos, Zpos),
                                Quaternion.identity);
                //���õ� �������� ���õ� ��ġ�� ����(���� ���������� ������, ��ġ�� ����.)
                Destroy(obj, 5f);
                // 5�� �ڿ� ������Ʈ �ı�
            }
        }
        //�ڷ�ƾ�� ������ ������� ���
        audio.Play();
    }
}
