/* Player1_Goal_Script.c#
 * by Julian Sangillo
 * This script will destroy the pong ball upon activating the trigger and
 * will increment the first players score. */

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Player1_Goal_Script : MonoBehaviour {

    //-------------------------Declare and Initialize---------------------------
    public Text player1_Score;
    private int count;
    private Vector2 position;

    public Sprite[] powerSprite = new Sprite[6];

    public GameObject[] lightArray;

    void Awake() {

        lightArray = GameObject.Find("Game Countdown").GetComponent<countdown>().lightArray;
        count = 0;
        player1_Score.text = count.ToString();

    }

    //----------------------------Trigger Activated----------------------------------- 
    void OnTriggerEnter2D(Collider2D pongBall) {

        //-------------------------------Light Sequence Upon Scoring-----------------------------------
        if (pongBall.gameObject.tag == "Ball") {

            explode();

            pongBall.gameObject.GetComponent<Ball_Movement>().enabled = false;
            position = new Vector2(0, 3);
            pongBall.gameObject.transform.position = position;

            //----------------------Check For Player 1 Victory & End Game------------------------
            if (count == 9) {   //NOTE: This is actually a score of 10 to win because I had to add the score later in the
                                //reSpawn function. I account for this by adding the last point inside the if.
                gameOver();

            }
            else {

                scored();

            }
        }
    }

    //-----------------------------------Function Declarations--------------------------------------
    void explode() {

        //------------------------------Explosion Effect Upon Scoring---------------------------------
        GameObject.Find("Bomb").GetComponent<Transform>().position = new Vector2(gameObject.GetComponent<Transform>().position.x, GameObject.Find("Pong Ball").GetComponent<Transform>().position.y);
        GameObject.Find("Bomb").GetComponent<ParticleSystem>().Play();

    }

    void scored() {

        //--------------------------------Sound Effect Upon Scoring-----------------------------------
        GetComponent<AudioSource>().Play();

        //-----------------------------------------Damage---------------------------------------------
        Invoke("powerLeft", 0.1f);
        Invoke("powerRight", 0.2f);
        Invoke("powerLeft", 0.3f);
        Invoke("powerRight", 0.4f);
        Invoke("powerLeft", 0.5f);
        Invoke("powerRight", 0.6f);
        Invoke("powerLeft", 0.7f);
        Invoke("powerRight", 0.8f);
        Invoke("powerLeft", 0.9f);
        Invoke("powerRight", 1);

        if (count == 2) {

            GameObject.Find("Pong Power Source p2").GetComponent<SpriteRenderer>().sprite = powerSprite[0];

        }
        else if (count == 4) {

            GameObject.Find("Pong Power Source p2").GetComponent<SpriteRenderer>().sprite = powerSprite[1];

        }
        else if (count == 5) {

            GameObject.Find("Pong Power Source p2").GetComponent<SpriteRenderer>().sprite = powerSprite[2];

        }
        else if (count == 6) {

            GameObject.Find("Pong Power Source p2").GetComponent<SpriteRenderer>().sprite = powerSprite[3];

        }
        else if (count == 7) {

            GameObject.Find("Pong Power Source p2").GetComponent<SpriteRenderer>().sprite = powerSprite[4];

        }
        else if (count == 8) {

            GameObject.Find("Pong Power Source p2").GetComponent<SpriteRenderer>().sprite = powerSprite[5];

        }

        //---------------------------------Function Calls-----------------------------------
        Invoke("turnLightOn1", 0);
        Invoke("turnLightOff1", 1);
        Invoke("turnLightOn2", 1);
        Invoke("turnLightOff2", 2);
        Invoke("turnLightOn3", 2);
        Invoke("turnLightOff3", 3);
        Invoke("reSpawn", 3);

    }

    void gameOver() {

        count++;
        player1_Score.text = count.ToString();
        Pause();
        Destroy(GameObject.Find("Pong Ball"));
        GameObject.Find("Atomic Bomb 1").GetComponent<ParticleSystem>().Play();
        GameObject.Find("Atomic Bomb 1").GetComponent<AudioSource>().Play();
        Destroy(GameObject.Find("Pong Power Source p2"));
        GameObject.Find("Pong Player 1").GetComponent<Player1_Movement>().enabled = false;
        Destroy(GameObject.Find("Pong Player 2"));
        GameObject.Find("Player1 Victory").GetComponent<Text>().enabled = true;
        Invoke("turnAllLightsOn", 0);
        Invoke("turnAllLightsOff", 1);
        Invoke("turnAllLightsOn", 2);
        Invoke("turnAllLightsOff", 3);
        Invoke("turnAllLightsOn", 4);
        Invoke("turnAllLightsOff", 5);
        Invoke("turnAllLightsOn", 6);
        Invoke("turnAllLightsOff", 7);
        Invoke("turnAllLightsOn", 8);
        Invoke("turnAllLightsOff", 9);
        Invoke("turnAllLightsOn", 10);
        Invoke("turnAllLightsOff", 11);
        Invoke("endGame", 12);
        Invoke("unPause", 12);

    }

    void Pause() {

        try {

            GameObject.Find("Theme Audio Source").GetComponent<AudioSource>().Pause();

        }
        catch (NullReferenceException) { }

    }

    void unPause() {

        try {

            GameObject.Find("Theme Audio Source").GetComponent<AudioSource>().UnPause();

        }
        catch (NullReferenceException) { }

    }

    void reSpawn() {

        //-------------------------------Score Respawn Destroy-----------------------------------
        count++;
        player1_Score.text = count.ToString();
        GameObject.Find("Pong Ball").GetComponent<Ball_Movement>().enabled = true;
        GameObject.Find("Pong Ball").GetComponent<Ball_Movement>().direction = new Vector2(UnityEngine.Random.Range(-2, 2), UnityEngine.Random.Range(-2, 0));
        GameObject.Find("Pong Ball").GetComponent<Ball_Movement>().moveSpeed = 1.8f;

        //-----------------------------Error Check------------------------------
        while (GameObject.Find("Pong Ball").GetComponent<Ball_Movement>().direction.x == 0 || GameObject.Find("Pong Ball").GetComponent<Ball_Movement>().direction.y == 0)
        {

            GameObject.Find("Pong Ball").GetComponent<Ball_Movement>().direction = new Vector2(UnityEngine.Random.Range(-2, 2), UnityEngine.Random.Range(-2, 0));

        }
    }

    void powerLeft() {

        GameObject.Find("Pong Power Source p2").transform.Translate(Vector2.left * Time.deltaTime);

    }

    void powerRight() {

        GameObject.Find("Pong Power Source p2").transform.Translate(Vector2.right * Time.deltaTime);

    }

    void turnLightOn1() {

        lightArray[12].GetComponent<Light>().enabled = true; lightArray[13].GetComponent<Light>().enabled = true;
        lightArray[14].GetComponent<Light>().enabled = true; lightArray[15].GetComponent<Light>().enabled = true;
        lightArray[16].GetComponent<Light>().enabled = true; lightArray[17].GetComponent<Light>().enabled = true;
        lightArray[18].GetComponent<Light>().enabled = true; lightArray[19].GetComponent<Light>().enabled = true;

    }

    void turnLightOff1() {

        lightArray[12].GetComponent<Light>().enabled = false; lightArray[13].GetComponent<Light>().enabled = false;
        lightArray[14].GetComponent<Light>().enabled = false; lightArray[15].GetComponent<Light>().enabled = false;
        lightArray[16].GetComponent<Light>().enabled = false; lightArray[17].GetComponent<Light>().enabled = false;
        lightArray[18].GetComponent<Light>().enabled = false; lightArray[19].GetComponent<Light>().enabled = false;

    }

    void turnLightOn2() {

        lightArray[0].GetComponent<Light>().enabled = true; lightArray[1].GetComponent<Light>().enabled = true;
        lightArray[2].GetComponent<Light>().enabled = true; lightArray[3].GetComponent<Light>().enabled = true;
        lightArray[4].GetComponent<Light>().enabled = true; lightArray[5].GetComponent<Light>().enabled = true;
        lightArray[6].GetComponent<Light>().enabled = true; lightArray[7].GetComponent<Light>().enabled = true;
        lightArray[8].GetComponent<Light>().enabled = true; lightArray[9].GetComponent<Light>().enabled = true;
        lightArray[10].GetComponent<Light>().enabled = true; lightArray[11].GetComponent<Light>().enabled = true;
        lightArray[20].GetComponent<Light>().enabled = true; lightArray[21].GetComponent<Light>().enabled = true;
        lightArray[22].GetComponent<Light>().enabled = true; lightArray[23].GetComponent<Light>().enabled = true;
        lightArray[24].GetComponent<Light>().enabled = true; lightArray[25].GetComponent<Light>().enabled = true;
        lightArray[26].GetComponent<Light>().enabled = true; lightArray[27].GetComponent<Light>().enabled = true;
        lightArray[28].GetComponent<Light>().enabled = true; lightArray[29].GetComponent<Light>().enabled = true;
        lightArray[30].GetComponent<Light>().enabled = true; lightArray[31].GetComponent<Light>().enabled = true;

    }

    void turnLightOff2() {

        lightArray[0].GetComponent<Light>().enabled = false; lightArray[1].GetComponent<Light>().enabled = false;
        lightArray[2].GetComponent<Light>().enabled = false; lightArray[3].GetComponent<Light>().enabled = false;
        lightArray[4].GetComponent<Light>().enabled = false; lightArray[5].GetComponent<Light>().enabled = false;
        lightArray[6].GetComponent<Light>().enabled = false; lightArray[7].GetComponent<Light>().enabled = false;
        lightArray[8].GetComponent<Light>().enabled = false; lightArray[9].GetComponent<Light>().enabled = false;
        lightArray[10].GetComponent<Light>().enabled = false; lightArray[11].GetComponent<Light>().enabled = false;
        lightArray[20].GetComponent<Light>().enabled = false; lightArray[21].GetComponent<Light>().enabled = false;
        lightArray[22].GetComponent<Light>().enabled = false; lightArray[23].GetComponent<Light>().enabled = false;
        lightArray[24].GetComponent<Light>().enabled = false; lightArray[25].GetComponent<Light>().enabled = false;
        lightArray[26].GetComponent<Light>().enabled = false; lightArray[27].GetComponent<Light>().enabled = false;
        lightArray[28].GetComponent<Light>().enabled = false; lightArray[29].GetComponent<Light>().enabled = false;
        lightArray[30].GetComponent<Light>().enabled = false; lightArray[31].GetComponent<Light>().enabled = false;

    }

    void turnLightOn3() {

        lightArray[32].GetComponent<Light>().enabled = true; lightArray[33].GetComponent<Light>().enabled = true;
        lightArray[34].GetComponent<Light>().enabled = true; lightArray[35].GetComponent<Light>().enabled = true;
        lightArray[36].GetComponent<Light>().enabled = true; lightArray[37].GetComponent<Light>().enabled = true;
        lightArray[38].GetComponent<Light>().enabled = true; lightArray[39].GetComponent<Light>().enabled = true;

    }

    void turnLightOff3() {

        lightArray[32].GetComponent<Light>().enabled = false; lightArray[33].GetComponent<Light>().enabled = false;
        lightArray[34].GetComponent<Light>().enabled = false; lightArray[35].GetComponent<Light>().enabled = false;
        lightArray[36].GetComponent<Light>().enabled = false; lightArray[37].GetComponent<Light>().enabled = false;
        lightArray[38].GetComponent<Light>().enabled = false; lightArray[39].GetComponent<Light>().enabled = false;

    }

    //-------------------------------------More Function Declarations------------------------------------
    void turnAllLightsOn() {

        foreach (GameObject light in lightArray) {

            light.GetComponent<Light>().enabled = true;

        }
    }

    void turnAllLightsOff() {

        foreach (GameObject light in lightArray) {

            light.GetComponent<Light>().enabled = false;

        }
    }

    void endGame() {

        SceneManager.LoadScene(5, LoadSceneMode.Single);

    }
}
