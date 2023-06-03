using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cactus : MonoBehaviour
{
    public float moveSpeed;
    gameController m_gc;

    // Start is called before the first frame update
    void Start()
    {
        m_gc = FindObjectOfType<gameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_gc.getIsGameOver() == false)
        {
            transform.position = transform.position + Vector3.left * moveSpeed * Time.deltaTime;
        }
    }

    //Catch collision cactus with scenelimit (destroy cactus)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SceneLimit"))
        {
            m_gc.incrementScore();
            Destroy(gameObject);
        }
    }
}
