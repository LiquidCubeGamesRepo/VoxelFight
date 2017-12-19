﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour {

    [SerializeField] float smoothTime = 0.3F;
    [SerializeField] Transform[] players;
    [SerializeField] Transform cameraGameOverTransform;

    Vector3 moveVelocity;
    Vector3 avaragePosition;

    void FixedUpdate(){

        Move ();
	}

    public void Move()
    {

        //Calculate acarage position of players
        avaragePosition = new Vector3 ();
        for (int i = 0; i < players.Length; i++)
            avaragePosition += players[i].position;

        avaragePosition /= players.Length;
        avaragePosition.y = 0f;

        //follow this position
        transform.position = Vector3.SmoothDamp (transform.position, avaragePosition, ref moveVelocity, smoothTime);
         
    }

    public Transform[] GetPlayers()
    {
        return players;
    }
    public void SetTransformTargets(List<Transform> targets)
    {
        players = targets.ToArray ();
    }


    public void GameOver(Transform t)
    {
        var cam = GetComponentInChildren<Camera> ();

        cam.orthographicSize = 15; // TODO make const
        cam.transform.position = cameraGameOverTransform.position;
        cam.transform.rotation = cameraGameOverTransform.rotation;
    }
}