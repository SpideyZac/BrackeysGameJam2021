﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternScript : MonoBehaviour
{
    public SpriteRenderer erenderer;
    private Transform playerTransform;
    public int maxDistance;
    public string enemytags;
    private bool beenToggled = false;
    private PlayerMovement player;
    public GameObject firefly;
    private GameObject newInstance;
    private Light flyLight;
    private GameObject withTag;

    private void Awake() {
        player = GameObject.Find("player").GetComponent<PlayerMovement>();
        playerTransform = GameObject.Find("player").GetComponent<Transform>();
        erenderer.color = new Color(1f, 1f, 1f, 0f);
    }

    private void Update() {
        withTag = GameObject.FindWithTag(enemytags);
        if (Mathf.Sqrt(Mathf.Pow(transform.position.x - playerTransform.position.x, 2) + Mathf.Pow(transform.position.y - playerTransform.position.y, 2) + Mathf.Pow(transform.position.z - playerTransform.position.z, 2)) <= maxDistance && !beenToggled && player.fireflys > 0 && withTag == null) {
            erenderer.color = new Color(1f, 1f, 1f, 1f);
            if (Input.GetKeyDown(KeyCode.E) && !beenToggled && player.fireflys > 0) {
                player.fireflys -= 1;
                beenToggled = true;
                newInstance = Instantiate(firefly, transform.position, new Quaternion(0, 0, 0, 0), transform);
                newInstance.GetComponent<Light>().range = 4;
                flyLight = newInstance.GetComponent<Light>();
            }
        } else {
            erenderer.color = new Color(1f, 1f, 1f, 0f);
        }

        if (beenToggled) {
            if (Mathf.Sqrt(Mathf.Pow(transform.position.x - playerTransform.position.x, 2) + Mathf.Pow(transform.position.y - playerTransform.position.y, 2) + Mathf.Pow(transform.position.z - playerTransform.position.z, 2)) <= flyLight.range && player.playerLight < player.maxPlayerLight) {
                player.playerLight += 0.02;
            }
        }
    }
}
