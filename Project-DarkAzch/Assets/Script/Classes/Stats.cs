using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Stats : MonoBehaviour {
	[SerializeField] private int health;
    [SerializeField] private int maxHealth;
    [SerializeField] private int lvl;
    [SerializeField] private float speed;
    [SerializeField] private string className;
    [SerializeField] private string basePhysicalRes;
    [SerializeField] private int physicalRes;
    [SerializeField] private int baseMagicRes;
    [SerializeField] private int fireRes;
    [SerializeField] private int frostRes;
    [SerializeField] private int lightRes;
    [SerializeField] private int shadowRes;
    [SerializeField] private int poisonRes;
    [SerializeField] private int xp;
    [SerializeField] private int xpRequiered=0;
    [SerializeField] private int baseDmg;
    [SerializeField] private bool hybridAttacks;//50% physicall dmg on hit and 50% magical dmg on attack
    [SerializeField] private string hybridElement;
    public bool initialize = false;

    public int PhysicalRes
    {
        get
        {
            return physicalRes;
        }

        set
        {
            physicalRes = value;
        }
    }
    public int FireRes
    {
        get
        {
            return fireRes;
        }

        set
        {
            fireRes = value;
        }
    }
    public int FrostRes
    {
        get
        {
            return frostRes;
        }

        set
        {
            frostRes = value;
        }
    }
    public int LightRes
    {
        get
        {
            return lightRes;
        }

        set
        {
            lightRes = value;
        }
    }
    public int ShadowRes
    {
        get
        {
            return shadowRes;
        }

        set
        {
            shadowRes = value;
        }
    }
    public int PoisonRes
    {
        get
        {
            return poisonRes;
        }

        set
        {
            poisonRes = value;
        }
    }
    void setBaseStats(string _basePhysicalRes) {
        switch (_basePhysicalRes)
        {
            case "plate":
                maxHealth = 150;
                physicalRes = 3;
                baseMagicRes = 0;
                speed = 4;
                baseDmg = 10;
                break;
            case "mail":
                maxHealth = 100;
                physicalRes = 2;
                baseMagicRes = 1;
                speed = 6;
                baseDmg = 12;
                break;
            case "leather":
                maxHealth = 75;
                physicalRes = 1;
                baseMagicRes = 2;
                speed = 8;
                baseDmg = 14;
                break;
            case "cloth":
                maxHealth = 50;
                physicalRes = 0;
                baseMagicRes = 3;
                speed = 5;
                baseDmg = 16;
                break;
        }
        this.GetComponent<NavMeshAgent>().speed = speed;
    }
    void create() {
        health = maxHealth;
        xp = 0;
        xpRequiered = 100;
        lvl = 1;
        switch (className) {
            case "shadow dancer":
                setBaseStats("leather");
                fireRes = baseMagicRes-1;
                frostRes = baseMagicRes+1;
                lightRes = baseMagicRes-1;
                shadowRes = baseMagicRes+1;
                poisonRes = baseMagicRes+1;
                hybridAttacks = false;
                break;
            case "twilight guardian":
                setBaseStats("plate");
                fireRes = baseMagicRes;
                frostRes = baseMagicRes;
                lightRes = baseMagicRes;
                shadowRes = baseMagicRes;
                poisonRes = baseMagicRes;
                hybridAttacks = false;
                break;
            case "crystal sword":
                setBaseStats("mail");
                fireRes = baseMagicRes-1;
                frostRes = baseMagicRes+1;
                lightRes = baseMagicRes;
                shadowRes = baseMagicRes;
                poisonRes = baseMagicRes+1;
                hybridAttacks = false;
                break;
            case "unhinged flame":
                setBaseStats("mail");
                fireRes = baseMagicRes+1;
                frostRes = baseMagicRes+1;
                lightRes = baseMagicRes+1;
                shadowRes = baseMagicRes+1;
                poisonRes = baseMagicRes+1;
                hybridAttacks = true;
                hybridElement = "fire";
                maxHealth = 50;
                health = maxHealth;
                break;
        }
    }
    void death() {
     //to decide
    }
    void damage(int dmg) {
        dmg = health - (int)dmg/(physicalRes+1);
        health = Mathf.Clamp(dmg,0,maxHealth);
        if (health == 0) death();
    }
    void damage(int dmg, string element)
    {
        switch(element) {
            case "fire":
                dmg = health - (int)dmg / (fireRes + 1);
                break;
            case "frost":
                dmg = health - (int)dmg / (frostRes + 1);
                break;
            case "poison":
                dmg = health - (int)dmg / (poisonRes + 1);
                break;
            case "light":
                dmg = health - (int)dmg / (lightRes + 1);
                break;
            case "shadow":
                dmg = health - (int)dmg / (shadowRes + 1);
                break;
        }
        health = Mathf.Clamp(dmg, 0, maxHealth);
        if (health == 0) death();
    }
    void heal(int _heal) {
        _heal = health + _heal;
        health = Mathf.Clamp(_heal, 0, maxHealth);
    }
    int getHealth() {
        return health;
    }
    int setHealth(int _health) {
        return health=_health;
    }
    int addxp(int _xp) {
        if(_xp+xp>=xpRequiered) {
            xp = xpRequiered - (_xp + xp);
            xpRequiered *=(int) 1.2;
            lvlup();
            return xp;
        } else {
            return xp += _xp;
        }        
    }
    int getlvl() {
        return lvl;
    }
    private void lvlup() {
        lvl++;
        switch(basePhysicalRes) {
            case "plate":
                maxHealth += 10;
                health = maxHealth;
                baseDmg *= (int)1.07;
                break;
            case "mail":
                maxHealth += 8;
                health = maxHealth;
                baseDmg *= (int)1.1;
                break;
            case "leather":
                maxHealth += 5;
                health = maxHealth;
                baseDmg *= (int)1.12;
                break;
            case "cloth":
                maxHealth += 3;
                health = maxHealth;
                baseDmg *= (int)1.15;
                break;
        }
    }
    private void Update()
    {
        if (initialize) init();
    }
    public void init()
    {
        if(xpRequiered==0 && className!=null) {
            create();
            Debug.Log("starting creation");
        }
    }
}
