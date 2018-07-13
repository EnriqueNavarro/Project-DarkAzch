using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityStats : MonoBehaviour {
	[SerializeField] private bool roads = false;
	public int num;

	private List<GameObject> roadList= new List<GameObject>();
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}
	public bool checkSpace(){//returns true if there is space
		return roads;
	}
	// -------------------add or remove roads to the current city --------------------------------------------
	public void addRoad(GameObject road){
		roads = true;
		roadList.Add (road);
		
	}

	public void removeRoad(GameObject road){
		roads=false;
		roadList.Remove (road);
	}
	public void removeRoad(int i){
		roads=false;
		roadList.RemoveAt (i);
	}
	public List<GameObject> getRoads(){
		return roadList;
	}
	// -------------------------------------------------------------------------------------------------------
}
