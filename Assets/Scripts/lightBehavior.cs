/* lightBehavior.c#
 * by Julian Sangillo
 * This script will cause all the lights during the main menu
 * scene to flash on and off at regular intervals until a button
 * to go to another scene is pressed. */

using UnityEngine;
using System;

public class lightBehavior : MonoBehaviour {

    //-------------------------Declaration and Initialization-----------------------------
    public GameObject[] lightArray = new GameObject[40];

    void Start() {

        //---------------------------------Begin Sequence---------------------------------
        Invoke("lightsOn", 1f);
        
    }

    //-----------------------------Function Declaration---------------------------------
    void lightsOn() {

        foreach (GameObject light in lightArray) {

            light.GetComponent<Light>().enabled = true;

        }

        Invoke("lightsOff", 1f);

    }

    void lightsOff() {

        foreach (GameObject light in lightArray) {

            light.GetComponent<Light>().enabled = false;

        }

        Invoke("lightsOn", 1f);

    }
}
