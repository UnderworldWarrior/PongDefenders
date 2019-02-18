/* Player1_Movement.c#
 * by Julian Sangillo
 * This script controls the movement of player one upon keyboard input.
 * Controls for player one: W for up, S for down.*/

using UnityEngine;

public class Player1_Movement : MonoBehaviour {

    //-----------------------Initialization----------------------------
    public float moveSpeed;
    public Rigidbody2D rb;
    private TrailRenderer trail1;
    private TrailRenderer trail2;

    void Start() {

        trail1 = GameObject.Find("Ship Trail 1").GetComponent<TrailRenderer>();
        trail2 = GameObject.Find("Ship Trail 2").GetComponent<TrailRenderer>();

    }

    void FixedUpdate () {

        //----------------------------KeyBoard Input------------------------------
        if (Input.GetButton("Up1")) {

            //-----------------------------Player Translation----------------------------
            rb.MovePosition(rb.position + Vector2.up * Time.fixedDeltaTime * moveSpeed);

            trail1.enabled = true;
            trail2.enabled = false;

        }
        else if (Input.GetButton("Down1")) {

            rb.MovePosition(rb.position + Vector2.down * Time.fixedDeltaTime * moveSpeed);

            trail1.enabled = false;
            trail2.enabled = true;

        }
        else {

            rb.MovePosition(rb.position + Vector2.zero * Time.fixedDeltaTime * moveSpeed);

        }

        //---------------------------------Pause Input----------------------------------
        if (Input.GetButton("Pause")) {

            Time.timeScale = 0;
            Time.fixedDeltaTime = 0;
            GameObject.Find("Resume").GetComponent<resumeMyGame>().pauseEnable();

        }

	}
}
