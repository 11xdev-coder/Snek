using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Threading.Tasks;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Snake : MonoBehaviour
{
    private Vector2 dir = Vector2.right;
    private List<Transform> tail = new List<Transform>();

    private bool ate = false;

    public int score;
    public GameObject tailPrefab;
    public GameObject gameOverText;
    public GameObject winText;
    public ParticleSystem deathEffect;
    public ParticleSystem eatEffect;
    public TMP_Text scoreText;

    public int maxScore;
    // Start is called before the first frame update
    void Start()
    {
        eatEffect.Stop();
        deathEffect.Stop();
        InvokeRepeating("Move", 0.3f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        deathEffect.transform.position = transform.position;
        eatEffect.transform.position = transform.position;
        if(Input.GetKeyDown(KeyCode.RightArrow))
            dir = Vector2.right;
        else if (Input.GetKeyDown(KeyCode.UpArrow))
            dir = Vector2.up;
        else if(Input.GetKeyDown(KeyCode.DownArrow))
            dir = -Vector2.up;
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
            dir = -Vector2.right;
    }

    void Move()
    {
        // Save current position (gap will be here)
        Vector2 v = transform.position;

        // Move head into new direction (now there is a gap)
        transform.Translate(dir);

        // Ate something? Then insert new Element into gap
        if (ate)
        {
            // Load Prefab into the world
            GameObject g = (GameObject)Instantiate(tailPrefab,
                v,
                Quaternion.identity);

            // Keep track of it in our tail list
            tail.Insert(0, g.transform);

            // Reset the flag
            ate = false;
        }
        // Do we have a Tail?
        else if (tail.Count > 0)
        {
            // Move last Tail Element to where the Head was
            tail.Last().position = v;

            // Add to front of list, remove from the back
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        // Food?
        if (coll.name.StartsWith("FoodPrefab"))
        {
            // Get longer in next Move call
            ate = true;

            // Remove the Food
            Destroy(coll.gameObject);

            StartCoroutine(Eat());
        }
        else if (coll.CompareTag("platform"))
        {
            print("nope :D");
        }
        // Collided with Tail or Border
        else
        {
            StartCoroutine(Lose());
        }
    }

    IEnumerator Lose()
    {
        gameOverText.SetActive(true);
        deathEffect.Play();
        SoundManagerScript.PlaySound("game over");
        yield return new WaitForSeconds(0.2f);
        gameOverText.SetActive(false);
        deathEffect.Stop();
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator Win()
    {
        winText.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        winText.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator Eat()
    {
        eatEffect.Play();
        score += 1;
        scoreText.text = score.ToString();
        if (score == maxScore)
        {
            StartCoroutine(Win());
        }
        SoundManagerScript.PlaySound("eat");
        yield return new WaitForSeconds(0.5f);
        eatEffect.Stop();
    }
}
