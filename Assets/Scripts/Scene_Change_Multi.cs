/* Scene_Change_Multi.c#
 * by Julian Sangillo
 * This script will check for button input. When the 'Multiplayer'
 * button is pressed the pongMultiplayer function will be called
 * which will close the Main Menu scene and will load the controls
 * scene and then the Multiplayer game scene. */

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scene_Change_Multi : MonoBehaviour {

    //----------------------Declaration----------------------
    private Button multiBtn;

    void Start() {

        //--------------------------Button Input Check & Function Call------------------------------
        multiBtn = GetComponent<Button>();
        multiBtn.onClick.AddListener(pongMultiplayer);

    }

    //--------------------------------Function Declaration---------------------------------
    void pongMultiplayer() {

        SceneManager.LoadScene(3, LoadSceneMode.Single);

    }

}
