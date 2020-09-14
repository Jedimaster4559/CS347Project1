using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    public GameObject bullet;
    public float maxShootingDistance;
    private float lastShot;
    public float shootingSpeed;

    // Start is called before the first frame update
    void Start()
    {
        float lastShot = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        lastShot += Time.deltaTime;
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if(lastShot > shootingSpeed && distance < maxShootingDistance)
        {
            Shoot();
            lastShot = 0.0f;
        }
    }

    void Shoot()
    {
        GameObject newBullet = Instantiate(bullet);
        newBullet.transform.position = transform.position + new Vector3(-1, 0);
        var controller = newBullet.GetComponent<BulletController>();
        controller.target = player.transform.position;
        controller.owner = this.gameObject;
        if (SceneManager.GetActiveScene().name.Equals("Original"))
        {
            controller.playerController = player.GetComponent<PlayerController>();
        } else
        {
            controller.timeBarController = player.GetComponent<TimeBarController>();
        }
    }


}
