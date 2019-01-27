using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(AudioSource))]
public class TriggerSound : MonoBehaviour {

    BoxCollider2D trigger, playerCollider;
    AudioSource audioSrc;

    SpriteRenderer sRenderer;

    bool playedAudio;

	// Use this for initialization
	void Start ()
    {
        InitializeComponents();
    }

    // Update is called once per frame
    void Update () {
        if (playerCollider.bounds.max.x >= trigger.bounds.min.x && playerCollider.bounds.min.x <= trigger.bounds.max.x)
        {
            if (!playedAudio)
            {
                audioSrc.Play();
                print("inside trigger");
                playedAudio = true;
            }
            //sRenderer.sprit
        }
        else
        {
            playedAudio = false;
        }
	}

    private void InitializeComponents()
    {
        trigger = gameObject.GetComponent<BoxCollider2D>();
        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>();
        audioSrc = gameObject.GetComponent<AudioSource>();

        trigger.isTrigger = true;
    }
}
