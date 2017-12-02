using Assets.Scripts.GameScripts.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBlock : MonoBehaviour {

    public BlockType type;
    public Material[] materials;
    public MeshRenderer render = null;
    public Vector2 Position;
    // Use this for initialization
    void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void UpdateColour()
    {
        switch (type)
        {
            case BlockType.Normal:
                render.material = materials[0];
                break;
            case BlockType.Fire:
                render.material = materials[1];
                break;
            case BlockType.Water:
                render.material = materials[2];
                break;
            case BlockType.Grass:
                render.material = materials[3];
                break;
            
        }
    }

    internal void setType(BlockType t,Vector2 pos)
    {
        Position = pos;
        type = t;
        UpdateColour();
    }
}
