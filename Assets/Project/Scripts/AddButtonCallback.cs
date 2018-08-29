using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddButtonCallback : MonoBehaviour {

	[SerializeField]
	private bool physical;
    [SerializeField] private bool potion;


    // Use this for initialization
    void Start () {
		gameObject.GetComponent<Button> ().onClick.AddListener (() => AddCallback());
	}
	
	private void AddCallback() {

            GameObject playerParty = GameObject.Find("PlayerParty");
            playerParty.GetComponent<SelectUnit>().SelectAttack(physical, potion);
        
	}
}
