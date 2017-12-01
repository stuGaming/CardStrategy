using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    public string jsonString;
	// Use this for initialization
	void Start () {
        JSONNode jsonNode = JSON.Parse(jsonString);
        if (jsonNode["Level"] != null)
        {
            Debug.Log("Succesfully loaded a json");
        }
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
