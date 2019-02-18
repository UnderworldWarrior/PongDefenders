/* AI_Movement.c#
 * by Julian Sangillo
 * This script provides the 2nd player with an AI that will
 * control player 2 and cause it to go after the ball. The AI
 * will also progressively get harder with each score the 1st player
 * earns. */

using UnityEngine;

public class AI_Movement : MonoBehaviour
{

    //-------------------------Declaration-------------------------------
    private float moveSpeed;
    public Rigidbody2D rb;
    public GameObject pongBall;
    private int count;
    public Vector2 ballDirection;
    private double y;
    public Ball_Movement script;
    private double length;
    private TrailRenderer trail3;
    private TrailRenderer trail4;

    void Awake()
    {

        length = GetComponent<EdgeCollider2D>().bounds.extents.y - 0.5;
        y = script.y;

    }

    void Start()
    {

        trail3 = GameObject.Find("Ship Trail 3").GetComponent<TrailRenderer>();
        trail4 = GameObject.Find("Ship Trail 4").GetComponent<TrailRenderer>();

    }

    void FixedUpdate()
    {

        //-----------------------------------Function Call---------------------------------------
        setup();

        //------------------------------Artificial Intelligence----------------------------------
        switch (count)
        {

            case 0:

                moveSpeed = 7.5f;
                break;

            case 1:

                moveSpeed = 8;
                break;

            case 2:

                moveSpeed = 8.5f;
                break;

            case 3:

                moveSpeed = 9;
                break;

            case 4:

                moveSpeed = 9.5f;
                break;

            case 5:

                moveSpeed = 10;
                break;

            case 6:

                moveSpeed = 10.5f;
                break;

            case 7:

                moveSpeed = 10.5f;
                break;

            case 8:

                moveSpeed = 10.5f;
                break;

            default:

                if (GameObject.Find("Player 2 Goal").GetComponent<AI_Goal_Script>().count <= 5) {

                    moveSpeed = 12;

                }
                else {

                    moveSpeed = 11;

                }

                break;

        }

        aiAlgorithm();

    }

    //---------------------------------Function Declaration----------------------------------------
    void setup() {

        //--------------------------------------Setup Variables----------------------------------------
        count = GameObject.Find("Player 1 Goal").GetComponent<Player_Goal_Script>().count;
        ballDirection = pongBall.GetComponent<Ball_Movement>().direction.normalized;
        y = script.y;

    }

    void aiAlgorithm() {

        //---------------------------------------Direction Check----------------------------------------
        if (ballDirection.x > 0) {

            //------------------------Moves AI In Respect To Ball Trajectory----------------------------
            if (y < gameObject.GetComponent<Transform>().position.y - length) {

                rb.MovePosition(rb.position + Vector2.down * Time.fixedDeltaTime * moveSpeed);

                trail3.enabled = false;
                trail4.enabled = true;

            }
            else if (y > gameObject.GetComponent<Transform>().position.y + length) {

                rb.MovePosition(rb.position + Vector2.up * Time.fixedDeltaTime * moveSpeed);

                trail3.enabled = true;
                trail4.enabled = false;

            }
            else {

                rb.MovePosition(rb.position + Vector2.zero * Time.fixedDeltaTime * moveSpeed);

            }
        }
    }
}