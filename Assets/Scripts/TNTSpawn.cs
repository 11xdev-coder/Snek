using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNTSpawn : MonoBehaviour
{

    public ParticleSystem boomEffect;

    public BoxCollider2D deathCollider;
    // Start is called before the first frame update
    void Start()
    {
        boomEffect.transform.position = transform.position;
        boomEffect.Stop();
        deathCollider.enabled = false;
        InvokeRepeating("SpawnAndBoom", 3, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnAndBoom()
    {
        StartCoroutine(Boom());
    }
    IEnumerator Boom()
    {
        SoundManagerScript.PlaySound("boom");
        boomEffect.Play();
        deathCollider.enabled = true;
        yield return new WaitForSeconds(0.5f);
        deathCollider.enabled = false;
        boomEffect.Stop();
    }
}
