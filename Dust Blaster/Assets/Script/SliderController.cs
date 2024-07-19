using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    Slider slTimer;
    float fSliderBarTime;

    // Start is called before the first frame update
    void Start()
    {
        slTimer = GetComponent<Slider>();
        slTimer.value = float.MaxValue ;
    }

    // Update is called once per frame
    void Update()
    {
        if(slTimer.value > 0.0f)
        {
            slTimer.value -= Time.deltaTime;
        }
        else
        {
            GameManager.instance.End();
        }
    }
}
