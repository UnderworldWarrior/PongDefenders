/* restartLastGame.c#
 * by Julian Sangillo
 * This script will restart the last match played when the
 * restart button is pressed. The purpose of this is if the player
 * or players want to play again without having to go through the menu. */

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class restartLastGame : MonoBehaviour {

    //--------------------------Initialization------------------------------
    public Button restartBtn;
    private GameObject _countdown;

    void Start () {

        //------------------------------Button Click? Function Call-------------------------------
        restartBtn.onClick.AddListener(restartTheGame);
		
	}

    void restartTheGame() {

        //------------------------Restart Last Scene Using A Scene Tracker-------------------------
        if (GameObject.Find("Scene Tracker").GetComponent<sceneTracker>().singlePlayer == true) {

            SceneManager.LoadScene(2, LoadSceneMode.Single);
            Time.timeScale = 1;
            Time.fixedDeltaTime = 0.02f;

        }
        else {

            SceneManager.LoadScene(4, LoadSceneMode.Single);
            Time.timeScale = 1;
            Time.fixedDeltaTime = 0.02f;

        }

    }
}
