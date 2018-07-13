using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability  {

    private string name;
    private string description;
    private Sprite icon;
    private List<AbilityBehaviors> behaviors;
    private bool requireTarget;
    private bool selfTarget;
    private int cd; //secs
    private GameObject particleflefx;
    private int duration;
    private float range;

    public Ability(string name, string description, Sprite icon, List<AbilityBehaviors> behaviors, bool requireTarget, bool selfTarget, int cd, GameObject particleflefx, int duration, float range)
    {
        this.name = name;
        this.description = description;
        this.icon = icon;
        this.behaviors = behaviors;
        this.requireTarget = requireTarget;
        this.selfTarget = selfTarget;
        this.cd = cd;
        this.particleflefx = particleflefx;
        this.duration = duration;
        this.range = range;
    }

    public List<AbilityBehaviors> Behaviors
    {
        get
        {
            return behaviors;
        }

        set
        {
            behaviors = value;
        }
    }

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
    public void useAbility() {

    }

}
