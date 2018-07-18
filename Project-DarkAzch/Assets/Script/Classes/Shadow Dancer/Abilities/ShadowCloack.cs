using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowCloack : Ability {
    public bool test = false;
    
    // Use this for initialization
    void Start () {
        SelfTarget = true;
        RequireTarget = false;
        name = "Shadow Cloack";
        Description = "Becomes stealthed";

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (test) useAbility();
        test = false;
        if(Timer!=0) {
            deltaTime = Time.fixedTime - Timer;
        }
	}

    public override void useAbility()
    {
        if (Timer == 0)
        {
            this.GetComponent<Stats>().Stealth = true;
            this.Particleflefx.SetActive(true);
            Invoke("endAbility", Duration);
            startCD();
            Invoke("refreshCD", getCd());
        }   
    }
    public override void endAbility() {
        this.GetComponent<Stats>().Stealth = false;
        this.Particleflefx.SetActive(false);
    }
}
