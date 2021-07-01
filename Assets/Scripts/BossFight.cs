using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class BossFight : MonoBehaviour
{
    public GameObject boss;
    public GameObject bossSpawnPoint;
    public float spawnSpeed;
    public ParticleSystem spawnEffect;

    public Rigidbody2D bossRB;
    // Start is called before the first frame update
    void Awake()
    {
        bossRB = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        StartCoroutine("Spawn");
    }

    // Update is called once per frame
    void Update()
    {

    } 
    
    IEnumerator Spawn()
    {
        spawnEffect.Play();
        bossRB.isKinematic = false;
        yield return new WaitForSeconds(2f);
    }
}
