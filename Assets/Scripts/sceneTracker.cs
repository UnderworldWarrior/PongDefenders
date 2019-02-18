/* sceneTrackerSingle.c#
 * by Julian Sangillo
 * This script will keep track of the scene the player was in
 * so the player or players can restart it later if they wish. */

using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneTracker : MonoBehaviour {

    public bool singlePlayer;

    void Awake() {

        DontDestroyOnLoad(gameObject);

    }

    void Update() {

        if (SceneManager.GetActiveScene().name == "Pong Singleplayer") {

            singlePlayer = true;

        }
        else if (SceneManager.GetActiveScene().name == "Pong Multiplayer") {

            singlePlayer = false;

        }

    }

}
