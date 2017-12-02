using UnityEngine;
using System.Collections;
using System;

public class BaseCharacter : MonoBehaviour
{
    public BaseBlock currentBlock;
    public PlayerControls PlayerController;
    public CharacterStats stats;
    // Use this for initialization
    void Start()
    {

    }

    public void SetBlock(BaseBlock newPosition)
    {
        currentBlock = newPosition;
        
        Vector3 blockposition = currentBlock.transform.position;
        blockposition.y += 0.5f;
        this.transform.position = blockposition;
    }

    // Update is called once per frame
    void Update()
    {

    }

    internal void Attack(BaseCharacter target)
    {
        
    }

    internal void TryToMove(BaseBlock baseBlock)
    {
        int distance = 0;
        distance = (int)Mathf.Abs(baseBlock.Position.x - currentBlock.Position.x) + (int)Mathf.Abs(baseBlock.Position.y - currentBlock.Position.y);
        if(distance <= stats.movement)
        {
            SetBlock(baseBlock);
        }
    }
}
