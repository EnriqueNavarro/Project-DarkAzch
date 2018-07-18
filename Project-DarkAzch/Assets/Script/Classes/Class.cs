using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class :MonoBehaviour {
    [SerializeField] private ClassName.ClassNames cName;
    [SerializeField] private Protection.ProtectionLevel armor;
    [SerializeField] private string name;
    [SerializeField] private Stats stats;
    [SerializeField] private List<Ability> passives; // each class has at *least* 1 passive
    [SerializeField] private List<Ability> actives; //each class has at *most* 4 actives
    [SerializeField] private bool stealth=false;
    public Stats Stats
    {
        get
        {
            return stats;
        }

        set
        {
            stats = value;
        }
    }

    public List<Ability> Passives
    {
        get
        {
            return passives;
        }

        set
        {
            passives = value;
        }
    }

    public List<Ability> Actives
    {
        get
        {
            return actives;
        }

        set
        {
            actives = value;
        }
    }

    public bool Stealth
    {
        get
        {
            return stealth;
        }

        set
        {
            stealth = value;
        }
    }

    public Protection.ProtectionLevel Armor
    {
        get
        {
            return armor;
        }

        set
        {
            armor = value;
        }
    }

    public void createNew(ClassName.ClassNames _cName, string _name) {
        this.stats = new Stats();
        stats.init(_cName);
    }
    

}
