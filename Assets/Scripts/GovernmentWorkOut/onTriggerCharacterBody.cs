﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onTriggerCharacterBody : MonoBehaviour {


    public void OnTriggerExit(Collider other)
    {
            Destroy(other.gameObject);
    }

}