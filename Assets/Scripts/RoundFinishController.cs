﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundFinishController : MonoBehaviour {
    public bool isRoundFinished;
    public GameObject leaderboardPanel;
    public GameObject boulder;
    public EdgeCollider2D floor;

    private Rigidbody2D rb2d;
    private float timeToWait;
    // Use this for initialization
    void Start()
    {
        rb2d = boulder.GetComponent<Rigidbody2D>();
        timeToWait = boulder.GetComponent<HoleMaker>().timeToChisel;
        Invoke("StartGameFinishedCheck", timeToWait+1);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    private void StartGameFinishedCheck()
    {
        StartCoroutine(Check());
    }
    IEnumerator Check()
    {
        while(true)
        {
            //have to get the polyCollider here but it's constantly being destroyed and recreated
            if(rb2d.velocity == Vector2.zero && boulder.GetComponent<PolygonCollider2D>().IsTouching(floor))
            {
                break;
            }
            yield return null;
        }
        isRoundFinished = true;
        leaderboardPanel.SetActive(true);
    }
}
