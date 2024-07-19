using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_gun : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void move()
    {
        animator.SetTrigger("shoot");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
