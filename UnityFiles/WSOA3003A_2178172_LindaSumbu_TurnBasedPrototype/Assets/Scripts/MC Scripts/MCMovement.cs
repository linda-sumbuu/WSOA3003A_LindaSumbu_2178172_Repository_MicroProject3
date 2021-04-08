using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MCMovement : MonoBehaviour
{
    public float moveSpeed;

    public CameraFancyStuff cameraD;

    private bool isFacingR = true;

    private float dirX;

    private Vector3 localScale;

    public Animator sceneAnim;
    public Animator anim;

    public LevelLoaderScript levelLoader;

    public Rigidbody2D RB;

    public Image instructions;
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;
        moveSpeed = 5f;
    }

   
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        
        if (Input.GetButtonDown("Jump") && RB.velocity.y <= 0)
        {
            RB.AddForce(Vector2.up * 600f);
            anim.SetBool("Jump", true);
        }
        else
        {
            anim.SetBool("Jump", false);
            anim.SetBool("Idle", true);
           
        }





        if (Mathf.Abs(dirX) > 0 && RB.velocity.y <= 0)
            anim.SetBool("isWalk", true);

        else
        {
            anim.SetBool("isWalk", false);
            anim.SetBool("Idle", true);
        }

      
    }


    private void FixedUpdate()
    {
        RB.velocity = new Vector2(dirX, RB.velocity.y);
    }


    private void LateUpdate()
    {
        if (dirX > 0)
            isFacingR = true;

        else if (dirX < 0)
            isFacingR = false;

        if (((isFacingR) && (localScale.x < 0)) || ((!isFacingR) && localScale.x > 0))
            localScale.x *= -1;

        transform.localScale = localScale;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            cameraD.shouldShake = true;
            levelLoader.LoadNextLevel();
           
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sign"))
        {
            instructions.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Sign"))
        {
            instructions.gameObject.SetActive(false);
        }
    }

}
