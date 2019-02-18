/* resumeMyGame.c#
 * by Julian Sangillo
 * This script will set up two functions for pausing and unpausing the game.
 * The pause function will be available for access by another script. The unpause
 * function will be used when the "Resume" button is pressed */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class resumeMyGame : MonoBehaviour {

    //----------------------------------Declaration-----------------------------------
    public GameObject _countdown;

    void Update() {

        //---------------------Function Call Upon Button Click------------------------
        GetComponent<Button>().onClick.AddListener(resume);

    }

    void resume() {

        //----------------------Pause Disable Function Call---------------------------
        pauseDisabled();

        StartCoroutine("resumeGame");
        
    }

    //-----------------------------------Function Declaration-----------------------------------
    IEnumerator resumeGame() {

        _countdown.SetActive(true);
        _countdown.GetComponent<Text>().enabled = true;

        for (float time = 5f; time > 0; time--) {

            _countdown.GetComponent<Text>().text = time.ToString("#");

            yield return new WaitForSecondsRealtime(1f);

        }

        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f;
        _countdown.SetActive(false);
        
    }

    public void pauseEnable() {

        GameObject.Find("Pause Text").GetComponent<Text>().enabled = true;
        GameObject.Find("Resume").GetComponent<Image>().enabled = true;
        GameObject.Find("Resume").GetComponent<Button>().enabled = true;
        GameObject.Find("Resume Text").GetComponent<Text>().enabled = true;
        GameObject.Find("Restart? Button").GetComponent<Image>().enabled = true;
        GameObject.Find("Restart? Button").GetComponent<Button>().enabled = true;
        GameObject.Find("Restart?").GetComponent<Text>().enabled = true;
        GameObject.Find("Quit").GetComponent<Image>().enabled = true;
        GameObject.Find("Quit").GetComponent<Button>().enabled = true;
        GameObject.Find("Quit Text").GetComponent<Text>().enabled = true;

    }

    void pauseDisabled() {

        GameObject.Find("Pause Text").GetComponent<Text>().enabled = false;
        GameObject.Find("Resume").GetComponent<Image>().enabled = false;
        GameObject.Find("Resume").GetComponent<Button>().enabled = false;
        GameObject.Find("Resume Text").GetComponent<Text>().enabled = false;
        GameObject.Find("Restart? Button").GetComponent<Image>().enabled = false;
        GameObject.Find("Restart? Button").GetComponent<Button>().enabled = false;
        GameObject.Find("Restart?").GetComponent<Text>().enabled = false;
        GameObject.Find("Quit").GetComponent<Image>().enabled = false;
        GameObject.Find("Quit").GetComponent<Button>().enabled = false;
        GameObject.Find("Quit Text").GetComponent<Text>().enabled = false;

    }

}
