using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody2d;
    public float flapStrength;
    public LogicScript logicScript;
    public bool birdIsAlive = true;

    public AudioSource source;
    public AudioClip flapSound;

    public void birdFlap()
    {
        source.clip = flapSound;
        source.Play();
    }
    // Start is called before the first frame update
    void Start()
    {

        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    
        if (!logicScript.gameState)
        {
            myRigidBody2d.gravityScale = 0;
            
        }
     
    }

    // Update is called once per frame
    void Update()
    {
        if (logicScript.gameState)
        {
            myRigidBody2d.gravityScale = 1;
        }
        Debug.Log("BirdScript" + birdIsAlive + " GameState " + logicScript.gameState);
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive && logicScript.gameState)
        {
            Debug.Log("keyDown");
            birdFlap();
            myRigidBody2d.velocity = Vector2.up * flapStrength;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logicScript.gameOver();
        birdIsAlive = false;
        Debug.Log("collision");
    }
}
