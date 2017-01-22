using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	// Use this for initialization
	void Start () {
		AudioSource fxSound = GetComponent<AudioSource> ();
		fxSound.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}