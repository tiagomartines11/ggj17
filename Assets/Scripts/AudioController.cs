using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

	public AudioClip bgm;
	public AudioClip buttonSound;
	public AudioClip scoreSound;
	public AudioClip goalSound;
	public AudioClip starSound;
	public AudioClip shieldDestroy;
    public AudioClip shieldHit;
    public AudioClip shot;

    AudioSource fxSound;

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	// Use this for initialization
	void Start () {
		fxSound = GetComponent<AudioSource> ();
		//fxSound.PlayOneShot (bgm);
	}

	public void playButton()
	{
		fxSound.PlayOneShot (buttonSound);
	}

	public void playScore()
	{
		fxSound.PlayOneShot (scoreSound);
	}

	public void playGoal()
	{
		fxSound.PlayOneShot (goalSound);
	}

	public void playStar()
	{
		fxSound.PlayOneShot (starSound);
	}

	public void playShieldDestroy()
	{
		fxSound.PlayOneShot (shieldDestroy);
	}

    public void playShieldHit()
    {
        fxSound.PlayOneShot(shieldHit);
    }
    public void playShot()
    {
        fxSound.PlayOneShot(shot);
    }

    // Update is called once per frame
    void Update () {
		
	}
}