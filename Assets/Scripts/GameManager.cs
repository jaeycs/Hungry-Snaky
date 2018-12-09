using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject player;
    public GameObject food;

    public GameObject playerTail;

    private List<Vector3> tailPositions;

    // Use this for initialization
    private void Start()
    {
        tailPositions = new List<Vector3>();
    }

    // Update is called once per frame
    private void Update()
    {

    }

    // puts the head position to the list (should be called in the player class
    public void copyHead (Vector3 pos)
    {
        tailPositions.Add(pos);
    }

    // copies last tail and add it to the list
    public void addNewTail()
    {
        int size = tailPositions.Count - 1;       
        tailPositions.Add(new Vector3(tailPositions[size].x, tailPositions[size].y, tailPositions[size].z));
    }

    // moves each tail position to the next position 
    public void updateTailPositions()
    {
        // add head pos to the list. it would be the first body pos

    }


}
