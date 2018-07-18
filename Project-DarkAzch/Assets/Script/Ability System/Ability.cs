using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour  {

    [SerializeField] private string name;
    [SerializeField] private string description;
    [SerializeField] private Sprite icon;
    [SerializeField] private bool requireTarget;
    [SerializeField] private bool selfTarget;
    [SerializeField] private int cd; //secs
    [SerializeField] private GameObject particleflefx;
    [SerializeField] private int duration;
    [SerializeField] private float range;
    private float timer;
    public float deltaTime;
    public void startCD() {
        Timer = Time.fixedTime;
    }
    public void refreshCD() {
        timer = 0;
    }
    public abstract void useAbility();

    public abstract void endAbility();

    public bool RequireTarget
    {
        get
        {
            return requireTarget;
        }

        set
        {
            requireTarget = value;
        }
    }

    public bool SelfTarget
    {
        get
        {
            return selfTarget;
        }

        set
        {
            selfTarget = value;
        }
    }

    public GameObject Particleflefx
    {
        get
        {
            return particleflefx;
        }

        set
        {
            particleflefx = value;
        }
    }

    public int Duration
    {
        get
        {
            return duration;
        }

        set
        {
            duration = value;
        }
    }

    public float Range
    {
        get
        {
            return range;
        }

        set
        {
            range = value;
        }
    }

    public string Description
    {
        get
        {
            return description;
        }

        set
        {
            description = value;
        }
    }

    public float Timer
    {
        get
        {
            return timer;
        }

        set
        {
            timer = value;
        }
    }

    public string getName() {
        return name;
    }

    public string getDescription()
    {
        return description;
    }

    public Sprite getIcon()
    {
        return icon;
    }

    public int getCd()
    {
        return cd;
    }

    public void setCd(int _cd) {
        cd = _cd;
    }
    

}
