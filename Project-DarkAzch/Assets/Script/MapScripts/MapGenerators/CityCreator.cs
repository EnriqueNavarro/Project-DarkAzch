using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityCreator : MonoBehaviour {
	[SerializeField] private GameObject city;//prefab of cities to generate
	public int numberOfCities=5;// number of cities to create, default is 5
	[SerializeField] private GameObject map; // map in which the cities are going to be created
	[SerializeField] private float height;//to get the height of the map and create the citis within
	[SerializeField] private float length;//to get the length
	public int sizeModifier=4; // we get a scale, with size modifier we can calculate it's size
	private float x=0;// pos x for new city
	private float y=0;// pos y for new city
	[SerializeField] Vector3 pos= new Vector3(0,0,0); // vector 3 to define city position
	[SerializeField] private float minDistance=2; // minimal distance between cities
	private List<GameObject> cities= new List<GameObject>(); // list of cities created to check distances and to pass onto gameManager
	private GameObject aux; // auxiliary GO to store the city to create in the list
	// Use this for initialization
	void Start () {
		map.transform.position = new Vector3 (0, 0, 0); //centers the map on the screen
		height = map.transform.localScale.z*sizeModifier-1; //gets height and cuts the edges as to not have a city on the edge
		length = map.transform.localScale.x*sizeModifier-1;
		aux=Instantiate (city, pos, Quaternion.identity);//instantiates city
		cities.Add (aux);//adds city to the list
		for(int i = 0 ; i<numberOfCities ; i++){// city creator
			int errorCounter=0; //keeps track of errors in case it cant find a pos that works
			if((cities.Count>0)){ // the first city will be in pos 0,0,0
				errorCounter=0;
				genPos ();
				bool range=false;// flag to check the city isnt too near to another
								//false means it's safe, true means we need another pos
				for (int j = 0; j < cities.Count; j++) {//checks distance with all existing cities
					do{
						range = minDistance>=Vector3.Distance (cities[j].transform.position,pos);// checks if the distance is greater or equal to minDistance
						if(range){
							errorCounter++;
							Debug.Log("Error counter : "+errorCounter+" with position "+ pos + " and distance "+Vector3.Distance (cities[j].transform.position,pos));//reports error
							genPos ();
							j=0;
						}
						if(errorCounter>10){
							Destroy(this.gameObject);//if it cant make all the cities, it stops the script
						}
					} while(range);
				}
				aux=Instantiate (city, pos, Quaternion.identity);//instantiates city
				cities.Add (aux);//adds city to the list
			}
		}
		Destroy(this.gameObject); // once it created all the cities it destroys the object
	}
	void genPos(){// get the coordinates to create a new city inside the map
		x = Random.Range (height*-1,height);
		y = Random.Range (length*-1,length);
		pos = new Vector3 (x, y, 0);
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
