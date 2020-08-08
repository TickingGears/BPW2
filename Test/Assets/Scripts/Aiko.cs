using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Aiko : MonoBehaviour
{
    public GameObject mainCam;
    public GameObject bridgeCam;

    private Rigidbody2D myRigidbody;

    private Animator myAnimator;

    [SerializeField]
    private float movementSpeed;

    private bool facingRight;

    void Start()
    {
        facingRight = true;
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        HandleMovement(horizontal);

        Flip(horizontal);
    }

    private void HandleMovement(float horizontal)
    {
        myRigidbody.velocity = new Vector2(horizontal * movementSpeed,myRigidbody.velocity.y);

        myAnimator.SetFloat("speed", Mathf.Abs(horizontal));
    }

    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;

            theScale.x *= -1;

            transform.localScale = theScale;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "bridgeCam")
        {
            bridgeCam.SetActive(true);
            mainCam.SetActive(false);
        }

        if(col.gameObject.tag == "mainCam")
        {
            bridgeCam.SetActive(false);
            mainCam.SetActive(true);
        }

        if (col.gameObject.tag == "sceneTrigger1")
        {
            SceneManager.LoadScene(4);
        }

        if (col.gameObject.tag == "sceneTrigger2")
        {
            SceneManager.LoadScene(1);
        }

        if (col.gameObject.tag == "sceneTrigger3")
        {
            SceneManager.LoadScene(2);
        }

        if (col.gameObject.tag == "sceneTrigger4")
        {
            SceneManager.LoadScene(3);
        }
    }
}
