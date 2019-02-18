/* Player2_Movement.c#
 * by Julian Sangillo
 * This script controls the movement of player two upon keyboard input.
 * Controls for player two: UpArrow for up, DownArrow for down.*/

using UnityEngine;

public class Player2_Movement : MonoBehaviour {

    //-------------------------Initialization---------------------------
    public float moveSpeed;
    public Rigidbody2D rb;
    private TrailRenderer trail3;
    private TrailRenderer trail4;

    void Start() {

        trail3 = GameObject.Find("Ship Trail 3").GetComponent<TrailRenderer>();
        trail4 = GameObject.Find("Ship Trail 4").GetComponent<TrailRenderer>();

    }

    void FixedUpdate () {

        //----------------------------KeyBoard Input------------------------------
        if (Input.GetButton("Up2")) {

            //-----------------------------Player Translation----------------------------
            rb.MovePosition(rb.position + Vector2.up * Time.fixedDeltaTime * moveSpeed);

            trail3.enabled = true;
            trail4.enabled = false;

        }
        else if (Input.GetButton("Down2")) {

            rb.MovePosition(rb.position + Vector2.down * Time.fixedDeltaTime * moveSpeed);

            trail3.enabled = false;
            trail4.enabled = true;

        }
        else {

            rb.MovePosition(rb.position + Vector2.zero * Time.fixedDeltaTime * moveSpeed);

        }

    }
}
