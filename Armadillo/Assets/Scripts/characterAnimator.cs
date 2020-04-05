using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequiredComponent(typeof(characterStats))]
public class characterAnimator : MonoBehaviour
{
	Rigidbody body;
	Animator animator;
	characterStats armadillo;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        armadillo = GetComponent<characterStats>();
    }

    // Update is called once per frame
    void Update()
    {
        float speedPercent = body.velocity.magnitude / armadillo.speed;
        animator.SetFloat("speedPercent",speedPercent,.1f,Time.deltaTime);
        animator.SetBool("rollMode",armadillo.rollMode);
        animator.SetFloat("rollSpeed",armadillo.rollSpeed.magnitude);
    }
}
