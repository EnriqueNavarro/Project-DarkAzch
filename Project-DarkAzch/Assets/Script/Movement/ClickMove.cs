using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class ClickMove : MonoBehaviour {
	public Camera cam;
    public NavMeshAgent agent;
    public Vector3 dest = new Vector3(0, 0, 0);
    public Animation anim=null;
    private Vector3 previousPosition;
    public float curSpeed;
    // Update is called once per frame
    private void Start()
    {
        dest = this.transform.position;
        try
            {
            anim = this.GetComponent<Animation>();
            }
        catch (Exception e)
        {
            Debug.Log("No animator found"+e);
        }
    }
    private void FixedUpdate()
    {
        Vector3 curMove = transform.position - previousPosition;
        curSpeed = curMove.magnitude / Time.deltaTime;
        previousPosition = transform.position;
    }
    void Update () {
        
        if (anim!=null) {
            if(curSpeed>0) {                
                anim.Play("Walk");                        
            } else {
                anim.Play("idle");
            }
            
            
        }                
            if (Input.GetMouseButtonDown (0)) {
			    Ray ray=cam.ScreenPointToRay (Input.mousePosition);
			    RaycastHit hit;
                if(Physics.Raycast(ray, out hit)) {
                    dest = hit.point;
                    agent.SetDestination(hit.point);
            }
		}
	}
}
