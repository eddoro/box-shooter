﻿using UnityEngine;
using System.Collections;

public class ShotgunShooter : MonoBehaviour {

	// Reference to projectile prefab to shoot
	public GameObject projectile;
	public float power = 10.0f;
	
	// Reference to AudioClip to play
	public AudioClip shootSFX;
	
	// Update is called once per frame
	void Update () {
		// Detect if fire button is pressed
		if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump"))
		{	
			// if projectile is specified
			if (projectile)
			{
				// Instantiante projectile at the camera + 1 meter forward with camera rotation
				GameObject newProjectile = Instantiate(projectile, transform.position + transform.forward, transform.rotation) as GameObject;

                
                //create an array with the number of children                
                GameObject[] childs = new GameObject[newProjectile.transform.childCount]; // Example 5 childs.
                for (int i = 0; i < childs.Length; i++)
                {
                    childs[i] = newProjectile.transform.GetChild(i).gameObject;
                    childs[i].GetComponent<Rigidbody>().AddForce(childs[i].transform.forward * power, ForceMode.VelocityChange);
                }                    
				
				// play sound effect if set
				if (shootSFX)
				{
					if (newProjectile.GetComponent<AudioSource> ()) { 
                        // the projectile has an AudioSource component
                        // play the sound clip through the AudioSource component on the gameobject.
                        // note: The audio will travel with the gameobject.
                        newProjectile.GetComponent<AudioSource>().volume = 0.4f;
						newProjectile.GetComponent<AudioSource>().PlayOneShot (shootSFX);
					} else {
						// dynamically create a new gameObject with an AudioSource
						// this automatically destroys itself once the audio is done
						AudioSource.PlayClipAtPoint (shootSFX, newProjectile.transform.position);
					}
				}
			}
		}
	}
}
