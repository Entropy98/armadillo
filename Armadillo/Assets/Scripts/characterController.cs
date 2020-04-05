using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{

	NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
    	agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
    	if(Input.GetKey(KeyCode.D))agent.Move(1,0,0);
    	else if(Input.GetKey(KeyCode.A))agent.Move(-1,0,0);
    }
}
