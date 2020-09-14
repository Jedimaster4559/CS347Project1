using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagController : MonoBehaviour
{
    public float captureDistance;
    public Animator flagAnimation;
    public GameObject player;
    private bool started;
    private float distance;
    public GameObject victoryScreen;

    // Start is called before the first frame update
    void Start()
    {
        started = false;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance < captureDistance && !started)
        {
            flagAnimation.Play("Flag Animation");
            started = true;
            Invoke("DisplayVictory", 2.0f);
        }
    }

    void DisplayVictory()
    {
        victoryScreen.SetActive(true);
    }
}
