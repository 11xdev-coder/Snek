using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawMove : MonoBehaviour
{

    [SerializeField] Transform[] positions;
    [SerializeField] float speed;

    int NextPosIndex;
    Transform NextPos;

    // Start is called before the first frame update
    void Start()
    {
        NextPos = positions[0];
    }

    // Update is called once per frame
    void Update()
    {
        MoveSaw();
    }

    void MoveSaw()
    {
        if (transform.position == NextPos.position)
        {
            NextPosIndex++;
            if (NextPosIndex >= positions.Length)
            {
                NextPosIndex = 0;
            }

            NextPos = positions[NextPosIndex];
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, NextPos.position, speed * Time.deltaTime);
        }
    }
}