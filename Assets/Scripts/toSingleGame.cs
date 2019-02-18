/* toSingleGame.c#
 * by Julian Sangillo
 * This script will proceed the player to the singleplayer game
 * when the next button is pressed. */

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class toSingleGame : MonoBehaviour {

    public Button btn;

    void Start () {

        //--------------------------Button Click? Function Call----------------------------
        btn.onClick.AddListener(pongSingleplayer);

	}

    void pongSingleplayer() {

        SceneManager.LoadScene(2, LoadSceneMode.Single);

    }
	
}
