using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementScale;
    public float jumpForce;
    private Rigidbody2D rigidBody;
    private bool bulletTimeToggle;
    public float slowDownFactor;
    private float translationSlowDown;
    private SpriteRenderer renderer;
    private bool facingRight;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        renderer = gameObject.GetComponent<SpriteRenderer>();
        facingRight = true;
        bulletTimeToggle = false;
        translationSlowDown = Time.timeScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            HandleInput();
        }
    }

    private void HandleInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-1 * movementScale * translationSlowDown, 0);
            facingRight = false;
            renderer.flipX = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(1 * movementScale * translationSlowDown, 0);
            facingRight = true;
            renderer.flipX = false;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.AddForce(new Vector3(0, jumpForce), ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            bulletTimeToggle = !bulletTimeToggle;
            if (bulletTimeToggle)
            {
                Time.timeScale = Time.timeScale * slowDownFactor;
                translationSlowDown = slowDownFactor;
                Time.fixedDeltaTime = Time.fixedDeltaTime * slowDownFactor;
            } else
            {
                Time.timeScale = Time.timeScale * (1 / slowDownFactor);
                translationSlowDown = Time.timeScale;
                Time.fixedDeltaTime = Time.fixedDeltaTime * (1 / slowDownFactor);
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            int direction = -1;
            if (facingRight) direction = 1;
            GameObject newBullet = Instantiate(bullet);
            newBullet.transform.position = transform.position + new Vector3(direction, 0);
            var controller = newBullet.GetComponent<BulletController>();
            controller.target = newBullet.transform.position + new Vector3(direction, 0);
            controller.owner = this.gameObject;
            controller.playerController = this.GetComponent<PlayerController>();
        }
    }

    public void resetTimeScale()
    {
        if(bulletTimeToggle)
        {
            Time.timeScale = Time.timeScale * (1 / slowDownFactor);
            translationSlowDown = Time.timeScale;
            Time.fixedDeltaTime = Time.fixedDeltaTime * (1 / slowDownFactor);
            bulletTimeToggle = !bulletTimeToggle;
        }
    }
}
