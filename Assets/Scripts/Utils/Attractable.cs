﻿using UnityEngine;
using System.Collections;

public class Attractable : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Captured(bool hasBeenCaptured)
    {
        //rigidbody.useGravity = !hasBeenCaptured;
    }

    void OnEnterCollision(Collider c)
    {
        if (c.tag=="Ground")
        {
            iTween.Stop();
        }
    }
}
