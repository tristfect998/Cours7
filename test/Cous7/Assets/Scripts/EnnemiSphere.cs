using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiSphere : Ennemi {

    GameObject player;
    public float speed = 5;
    Rigidbody rgb;
    AudioSource audioSource;
    public AudioMusic audioMusic;
    public GameObject particleSystemDeath;
    public GameObject smallerBall;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rgb = GetComponent<Rigidbody>();
        audioSource = GameObject.FindGameObjectWithTag("SoundPlayer").GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        rgb.MovePosition(Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime));
    }

    public override void Die()
    {
        audioSource.PlayOneShot(audioMusic.soundToPlay);
        Instantiate(particleSystemDeath, gameObject.transform.position, Quaternion.identity);
        Instantiate(smallerBall, gameObject.transform.position, gameObject.transform.rotation);
        Instantiate(smallerBall, gameObject.transform.position + new Vector3(3,0,0), gameObject.transform.rotation);
        Destroy(gameObject);
    }
}
