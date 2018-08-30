using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float moveSpeed = 3f;
    public AudioSource audioSource;

    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
        transform.position = new Vector2(
            transform.position.x - (moveSpeed * Time.deltaTime),
            transform.position.y);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioSource.Play();


        
        Destroy(gameObject);
    }
}
