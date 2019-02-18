/* Scene_Change_Single.c#
 * by Julian Sangillo
 * This script will check for button input. When the 'Singleplayer'
 * button is pressed the pongSingleplayer function will be called
 * which will close the Main Menu scene and will load the controls
 * scene and then the Singleplayer game scene. */

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scene_Change_Single : MonoBehaviour {

    //----------------------Declaration----------------------
    private Button singleBtn;

    void Start() {

        //-----------------------------Unpause game If Not Already----------------------------------
        if (Time.timeScale == 0) {

            Time.timeScale = 1;
            Time.fixedDeltaTime = 0.02f;

        }

        //--------------------------Button Input Check & Function Call------------------------------
        singleBtn = GetComponent<Button>();
        singleBtn.onClick.AddListener(pongSingleplayer);

    }

    //--------------------------------Function Declaration---------------------------------
    void pongSingleplayer() {

        SceneManager.LoadScene(1, LoadSceneMode.Single);

    }

}
