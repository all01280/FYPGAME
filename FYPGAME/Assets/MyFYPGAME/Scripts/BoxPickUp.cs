﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPickUp : MonoBehaviour
{
    public Transform theDest;

    private void OnMouseDown()
    {
        //GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = theDest.position;
        this.transform.parent = GameObject.Find("Dest").transform;
    }

    private void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
       // GetComponent<BoxCollider>().enabled = true;
    }
}
