using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class TurorialHide : MonoBehaviour
{
    public GameObject keysSprite, tutorialText1, tutorialText2;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(HideObjects());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator HideObjects()
    {
        yield return new WaitForSeconds(6f);
        keysSprite.SetActive(false);
        tutorialText1.SetActive(false);
        tutorialText2.SetActive(false);
    }
}
