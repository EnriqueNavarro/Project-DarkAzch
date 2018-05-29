using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour {
	private List<GameObject> cities= new List<GameObject>();
	public float[,] distances;
	public bool start = false;
	[SerializeField] private GameObject road;
	public void setCities(List<GameObject> c){
		cities = c;
		start = true;
		planRoads ();
	}
	void planRoads(){
		int[] adj = new int[cities.Count];
		calculateDistances ();
		for (int i = 0; i < cities.Count; i++) {
			adj[i]= findClosest (i);
		}
		for (int i = 0; i < cities.Count; i++) {
			buildRoads (i,adj[i]);
		}
	}

	void buildRoads(int from, int to){
		int i = 0;
		int to1=to;
		while (!cities [to].GetComponent<CityStats> ().checkSpace ()) {
			Debug.Log ("space not enough");
			i++;
			to = findClosest (from);
		}
		if (i > 0){
			Debug.Log ("WAS  From " + from + " to " + to1);
			Debug.Log ("IS:  From " + from + " to " + to);
		}

		GameObject aux = Instantiate (road, (cities [from].transform.position + cities [to].transform.position) / 2, Quaternion.identity);
		aux.GetComponent<Road> ().to = cities[to];
		aux.GetComponent<Road> ().from = cities[from];
		aux.transform.LookAt (cities [to].transform);
		aux.transform.localScale = new Vector3 (0.5f, (cities [to].transform.position - cities [from].transform.position).magnitude, 0.5f);
		aux.transform.Rotate (90, 0, 0);
		cities [to].GetComponent<CityStats> ().addRoad (aux);

	}

	int findClosest(int k){// finds the closest city to the city k
		float min= (distances[k,0]);
		int minIndex = 0;
		for (int i = 1; i < cities.Count; i++) {
			if (distances [k, i] < min) {
				minIndex = i;
				min = distances [k, i];
			}
		}
		distances [k, minIndex] = float.MaxValue;//sets distance to max value, to find the second closest city on the next iteration
		distances [minIndex, k] = float.MaxValue;
		return minIndex;//returns the index of the closest city
	}

	void calculateDistances(){//calculates the distances between all cities
		distances = new float[cities.Count,cities.Count];
		for (int i = 0; i < cities.Count; i++) {
			for (int j = i; j < cities.Count; j++) {
				distances [i,j] = Vector3.Distance (cities[i].transform.position,cities[j].transform.position);
				distances [j,i] = distances [i,j];//the distance between a,b is the same as b,a
			}
		}
		for(int i=0;i< cities.Count;i++){
			distances [i, i] = float.MaxValue;
		}
	}

}
