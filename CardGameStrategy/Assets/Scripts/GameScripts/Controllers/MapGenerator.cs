using Assets.Scripts.GameScripts.Model;
using Assets.Scripts.Tools.MapCreator;
using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    public string jsonString;
    public BaseBlock tilePrefab;
    public List<BaseBlock> currentMap = new List<BaseBlock>();
	// Use this for initialization
	void Start () {
        JSONNode jsonNode = JSON.Parse(jsonString);
        if (jsonNode["Level"] != null)
        {
            Debug.Log("Succesfully loaded a json");
        }
	}

    private void DestroyGrid()
    {
        for(int i = 0; i < currentMap.Count; i++)
        {
            BaseBlock block = currentMap[i];
            currentMap[i] = null;
            Destroy(block.gameObject);

        }
        currentMap.Clear();
        currentMap = new List<BaseBlock>();
    }

    public void GenerateMap()
    {
        Map map = new Map();
        map = JsonUtility.FromJson<Map>(jsonString);
        DestroyGrid();
        int index = 0;
        for (int i = 0; i < map.Width; i++)
        {
            for(int f = 0; f < map.Height; f++)
            {
                BaseBlock block = Instantiate(tilePrefab,new Vector3(i,0,f),Quaternion.identity);
                block.setType(map.blockTypes[index],new Vector2(i,f));
                index++;
                block.transform.SetParent(this.transform);
                currentMap.Add(block);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
