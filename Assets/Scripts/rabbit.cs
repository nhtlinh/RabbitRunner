using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class rabbit : MonoBehaviour
{
    //Create public variable jump force
    public float jumpForce;
    //Apply physic for rabbit
    Rigidbody2D m_rb;
    //Check rabbit is on ground and press space
    bool m_isGround;

    gameController m_gc;

    //Sound && Effect
    public AudioSource m_audioSource;
    public AudioClip m_jumpSound;
    public AudioClip m_gameOverSound;

    // Start is called before the first frame update
    void Start()
    {
        //Get component RigidBody
        m_rb = GetComponent<Rigidbody2D>();

        //Game Controller
        m_gc = FindObjectOfType<gameController>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isJumpedPress = Input.GetKeyDown(KeyCode.Space);

        //If rabbit is on ground and people press space and game is not over
        if (isJumpedPress == true && m_isGround == true && m_gc.getIsGameOver() == false)
        {
            m_rb.AddForce(Vector2.up * jumpForce);
            //Sound Jump
            if (m_audioSource && m_jumpSound)
            {
                m_audioSource.PlayOneShot(m_jumpSound);
            }
            m_isGround = false;
        }
    }

    //Catch collision rabbit with ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            m_isGround = true;
        }
    }

    //Catch collision rabbit with cactus
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cactus"))
        {
            m_gc.setIsGameOver(true);

            //Sound Game over
            if (m_audioSource && m_gameOverSound)
            {   
                //Stop BackGround Sound
                m_audioSource.Stop();
                //Play Sound GameOver 
                m_audioSource.PlayOneShot(m_gameOverSound);
            }
        }
    }
}
