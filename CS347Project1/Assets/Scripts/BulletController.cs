using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletController : MonoBehaviour
{
    public Vector3 target;
    public float bulletSpeed;
    private Rigidbody2D rigidBody;
    public GameObject owner;
    public GameObject mainCamera;
    public PlayerController playerController;
    public TimeBarController timeBarController;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        rigidBody.AddForce(Vector3.Normalize(target - transform.position) * bulletSpeed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided");
        if (collision.gameObject.tag.Equals("Destructable"))
        {
            Debug.Log("Destroying Object");
            if (collision.gameObject.name.Equals("Player"))
            {
                if (SceneManager.GetActiveScene().name.Equals("Original"))
                {
                    playerController.resetTimeScale();
                } else
                {
                    timeBarController.resetTimeScale();
                }
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            collision.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
            //Destroy(collision.gameObject);
            //Destroy(this.gameObject);
            
            
        }
    }
}
