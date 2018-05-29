using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMvalues : MonoBehaviour {
	[SerializeField] List<GameObject> cities= new List<GameObject>();
	// Use this for initialization
	void Start () {
		
	}
	public void saveCities(List<GameObject> c){//recieves the cities list from city Creator, once its done
		cities = c;
		this.GetComponentInChildren<RoadGenerator> ().setCities (cities);
	}
	public List<GameObject> getCities(){
		return cities;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
