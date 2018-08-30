using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class listen : MonoBehaviour {

    AudioListener[] listeners;

    // Use this for initialization
    void Start() {
        listeners = FindObjectsOfType<AudioListener>();
        print(listeners.Length);

        foreach (var listener in listeners)
        {
            print(listener.gameObject.name);


        }
    }
}



