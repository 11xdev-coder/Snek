using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{

    public GameObject foodPrefab;

    public Transform BorderTop;
    public Transform BorderBottom;
    public Transform BorderRight;
    public Transform BorderLeft;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 3, 4);
    }

    void Spawn()
    {
        int x = (int) Random.Range(BorderRight.position.x, BorderLeft.position.x);
        int y = (int)Random.Range(BorderTop.position.y, BorderBottom.position.y);

        Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity);
    }
}
