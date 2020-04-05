using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequiredComponent(typeof(characterStats))]
public class characterController : MonoBehaviour
{
	Vector3 right;
	Vector3 left;
	Rigidbody body;
	characterStats armadillo;

	float turnTorque=500;

	bool directionRight = true;
	bool turning=false;
	int turnCounter=0;
	int turnThreshold=53;

	int doubleBounceThreshold=20;
	int doubleBounceCounter=0;

    // Start is called before the first frame update
    void Start()
    {
    	armadillo = GetComponent<characterStats>();
    	body = GetComponent<Rigidbody>();
    	right = new Vector3(armadillo.acceleration,0,0);
    	left = new Vector3(armadillo.acceleration*-1,0,0);
    }

    void Flip(float torque){
    	if(turnCounter<turnThreshold){
    		body.AddTorque(0,torque,0);
    		turnCounter++;
    	}
    	else{
    		turning=false;
    		turnCounter=0;
    	}
    }

    // Update is called once per frame
    void Update()
    {
    	if(!armadillo.rollMode){
	    	if(body.velocity.magnitude<armadillo.speed && !armadillo.rollMode){
	    		if(Input.GetKey(KeyCode.D)){
	    			body.AddForce(right);
	    			if(!turning && !directionRight){
	    				turning=true;
	    			}
	    			directionRight=true;
	    		}
	    		else if(Input.GetKey(KeyCode.A)){
	    			body.AddForce(left);
	    			if(!turning && directionRight){
	    				turning=true;
	    			}
    				directionRight=false;
    			}
    		}
    	}
    	else{
    		body.AddForce(armadillo.rollSpeed);
    	}
    	if(Input.GetKey(KeyCode.Space)){
    		if(doubleBounceCounter>doubleBounceThreshold){
    			armadillo.rollMode=!armadillo.rollMode;
    			armadillo.rollSpeed=3*body.velocity;
    			doubleBounceCounter=0;
    		}
    		doubleBounceCounter++;
    	}
    	if(turning)Flip(turnTorque);
    }
}
