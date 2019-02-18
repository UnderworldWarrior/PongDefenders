/* Ball_Movement.c#
 * by Julian Sangillo
 * This script will allow the ball to move across the 2D plane
 * once instantiated and will bounce in the reverse direction
 * upon collision with a paddle or border. */

using UnityEngine;
using System;

public class Ball_Movement : MonoBehaviour {

    //----------------------Initialization-----------------------
    public Rigidbody2D rb;
    public Vector2 direction;
    public float moveSpeed;
    private Vector2 ballDirection;
    private GameObject pongBall;
    public double y;
    private double theta;
    private float dot;
    private float x;

    void Awake() {

        direction = new Vector2(UnityEngine.Random.Range(-2, 2), UnityEngine.Random.Range(-2, 2));
        y = trajectory();

        //-----------------------------Error Check------------------------------
        while (direction.x == 0 || direction.y == 0) {

            direction = new Vector2(UnityEngine.Random.Range(-2, 2), UnityEngine.Random.Range(-2, 2));

        }

    }

	void FixedUpdate() {

        //----------------------------Ball Movement-------------------------------
        rb.MovePosition(rb.position + direction * Time.fixedDeltaTime * moveSpeed);

        //-----------Adjust Ball Vector If X Or Y Direction Too Close To Zero----------
        ballUpdate();

        //-----------------------Ball Trajectory Update---------------------------
        if (pongBall.transform.position.x == 0 && pongBall.transform.position.y == 3) {

            y = trajectory();

        }

    }

    //------------------------Reverse Ball Movement Upon Collision----------------------------
    void OnCollisionEnter2D(Collision2D collision) {

        if (collision.collider == true) {

            direction = Vector2.Reflect(direction, collision.contacts[0].normal);
            y = trajectory();

            //------------------------Increase speed of ball with each collision----------------------------
            if (moveSpeed <= 15 && (collision.contacts[0].normal == Vector2.right || collision.contacts[0].normal == Vector2.left)) {

                moveSpeed += 0.5f;

            }

            //--------------------------Repel Particle System Upon Collision--------------------------------
            if (collision.contacts[0].normal == Vector2.right) {

                GameObject.Find("repel 1").GetComponent<ParticleSystem>().Play();

            }
            else if (collision.contacts[0].normal == Vector2.left) {

                GameObject.Find("repel 2").GetComponent<ParticleSystem>().Play();

            }

            //----------------------------Light Effect Upon Collision-----------------------------
            GetComponent<Light>().enabled = true;

            //---------------------------Sound Effect Upon Collision------------------------------
            GetComponent<AudioSource>().Play();

        }
    }

    //------------------------------Disables Light After Collision--------------------------------
    void OnCollisionExit2D(Collision2D collision) {

        if (collision.collider == true) {

            GetComponent<Light>().enabled = false;

        }
    }

    void ballUpdate() {

        //-----------------------------Error Direction Corrector-----------------------------
        if (direction.x >= 0 && direction.x <= 0.2) {

            direction.x++;

        }
        else if (direction.x >= -0.2 && direction.x <= 0) {

            direction.x--;

        }
        else if (direction.y >= 0 && direction.y <= 0.2) {

            direction.y++;

        }
        else if (direction.y >= -0.2 && direction.y <= 0) {

            direction.y--;

        }
    }

    public double trajectory() {

        try {

            pongBall = GameObject.Find("Pong Ball");
            ballDirection = pongBall.GetComponent<Ball_Movement>().direction;

            x = GameObject.Find("Pong AI").GetComponent<Transform>().position.x - pongBall.GetComponent<Transform>().position.x;
            theta = Vector2.Angle(ballDirection, Vector2.right) * (Math.PI / 180);
            dot = Vector3.Dot(ballDirection, Vector2.up);

            if (dot < 0) {

                theta = -theta;

            }

            y = x * Math.Tan(theta);
            y = pongBall.transform.position.y + y;

            return y;

        } catch (NullReferenceException) { return 0; }

    }
}

