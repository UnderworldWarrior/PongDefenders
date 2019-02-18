/* countdown.c#
 * by Julian Sangillo
 * This script will add a countdown timer at the beginning of the game
 * signifying the start of the game when the countdown hits zero. When it
 * does hit zero the movement scripts on the two players and the ball 
 * will be enabled and the countdown will be disabled/removed. */

using UnityEngine;
using UnityEngine.UI;

public class countdown : MonoBehaviour {

    public GameObject _countdown;

    public GameObject[] lightArray = new GameObject[40];

	void Update() {

        //----------------Decrements Time by 5 and Puts It Through Textbox-----------------
        float time = 5 - Time.timeSinceLevelLoad;
        GetComponent<Text>().text = time.ToString("#");

        //-------------------Enable Game Disable Textbox When Time Is Up-------------------
        if (time <= 0f) {

            time = 0;
            clock();

        }
	}

    void FixedUpdate() {

        lightSequence();

    }

    void lightSequence() {

        //--------------------Control Light Sequence During Countdown----------------------
        Invoke("turnLightOn1", 0);
        Invoke("turnLightOff1", 1);
        Invoke("turnLightOn2", 1);
        Invoke("turnLightOff2", 2);
        Invoke("turnLightOn1", 2);
        Invoke("turnLightOff1", 3);
        Invoke("turnLightOn2", 3);
        Invoke("turnLightOff2", 4);

    }

    void clock() {

        GameObject.Find("Pong Ball").GetComponent<Ball_Movement>().enabled = true;
        GameObject.Find("Pong Player 1").GetComponent<Player1_Movement>().enabled = true;
        GameObject.Find("Pong Player 2").GetComponent<Player2_Movement>().enabled = true;
        turnLightOff1();
        _countdown.SetActive(false);
        Destroy(GetComponent<countdown>());

    }

    void turnLightOn1() {

        lightArray[0].GetComponent<Light>().enabled = true; lightArray[2].GetComponent<Light>().enabled = true;
        lightArray[4].GetComponent<Light>().enabled = true; lightArray[6].GetComponent<Light>().enabled = true;
        lightArray[8].GetComponent<Light>().enabled = true; lightArray[10].GetComponent<Light>().enabled = true;
        lightArray[12].GetComponent<Light>().enabled = true; lightArray[14].GetComponent<Light>().enabled = true;
        lightArray[16].GetComponent<Light>().enabled = true; lightArray[18].GetComponent<Light>().enabled = true;
        lightArray[20].GetComponent<Light>().enabled = true; lightArray[22].GetComponent<Light>().enabled = true;
        lightArray[24].GetComponent<Light>().enabled = true; lightArray[26].GetComponent<Light>().enabled = true;
        lightArray[28].GetComponent<Light>().enabled = true; lightArray[30].GetComponent<Light>().enabled = true;
        lightArray[32].GetComponent<Light>().enabled = true; lightArray[34].GetComponent<Light>().enabled = true;
        lightArray[36].GetComponent<Light>().enabled = true;  lightArray[38].GetComponent<Light>().enabled = true;

    }

    void turnLightOn2() {

        lightArray[1].GetComponent<Light>().enabled = true; lightArray[3].GetComponent<Light>().enabled = true;
        lightArray[5].GetComponent<Light>().enabled = true; lightArray[7].GetComponent<Light>().enabled = true;
        lightArray[9].GetComponent<Light>().enabled = true; lightArray[11].GetComponent<Light>().enabled = true;
        lightArray[13].GetComponent<Light>().enabled = true; lightArray[15].GetComponent<Light>().enabled = true;
        lightArray[17].GetComponent<Light>().enabled = true; lightArray[19].GetComponent<Light>().enabled = true;
        lightArray[21].GetComponent<Light>().enabled = true; lightArray[23].GetComponent<Light>().enabled = true;
        lightArray[25].GetComponent<Light>().enabled = true; lightArray[27].GetComponent<Light>().enabled = true;
        lightArray[29].GetComponent<Light>().enabled = true; lightArray[31].GetComponent<Light>().enabled = true;
        lightArray[33].GetComponent<Light>().enabled = true; lightArray[35].GetComponent<Light>().enabled = true;
        lightArray[37].GetComponent<Light>().enabled = true; lightArray[39].GetComponent<Light>().enabled = true;

    }

    void turnLightOff1() {

        lightArray[0].GetComponent<Light>().enabled = false; lightArray[2].GetComponent<Light>().enabled = false;
        lightArray[4].GetComponent<Light>().enabled = false; lightArray[6].GetComponent<Light>().enabled = false;
        lightArray[8].GetComponent<Light>().enabled = false; lightArray[10].GetComponent<Light>().enabled = false;
        lightArray[12].GetComponent<Light>().enabled = false; lightArray[14].GetComponent<Light>().enabled = false;
        lightArray[16].GetComponent<Light>().enabled = false; lightArray[18].GetComponent<Light>().enabled = false;
        lightArray[20].GetComponent<Light>().enabled = false; lightArray[22].GetComponent<Light>().enabled = false;
        lightArray[24].GetComponent<Light>().enabled = false; lightArray[26].GetComponent<Light>().enabled = false;
        lightArray[28].GetComponent<Light>().enabled = false; lightArray[30].GetComponent<Light>().enabled = false;
        lightArray[32].GetComponent<Light>().enabled = false; lightArray[34].GetComponent<Light>().enabled = false;
        lightArray[36].GetComponent<Light>().enabled = false; lightArray[38].GetComponent<Light>().enabled = false;

    }

    void turnLightOff2() {

        lightArray[1].GetComponent<Light>().enabled = false; lightArray[3].GetComponent<Light>().enabled = false;
        lightArray[5].GetComponent<Light>().enabled = false; lightArray[7].GetComponent<Light>().enabled = false;
        lightArray[9].GetComponent<Light>().enabled = false; lightArray[11].GetComponent<Light>().enabled = false;
        lightArray[13].GetComponent<Light>().enabled = false; lightArray[15].GetComponent<Light>().enabled = false;
        lightArray[17].GetComponent<Light>().enabled = false; lightArray[19].GetComponent<Light>().enabled = false;
        lightArray[21].GetComponent<Light>().enabled = false; lightArray[23].GetComponent<Light>().enabled = false;
        lightArray[25].GetComponent<Light>().enabled = false; lightArray[27].GetComponent<Light>().enabled = false;
        lightArray[29].GetComponent<Light>().enabled = false; lightArray[31].GetComponent<Light>().enabled = false;
        lightArray[33].GetComponent<Light>().enabled = false; lightArray[35].GetComponent<Light>().enabled = false;
        lightArray[37].GetComponent<Light>().enabled = false; lightArray[39].GetComponent<Light>().enabled = false;

    }
}
