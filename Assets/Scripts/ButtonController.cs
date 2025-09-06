using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
        //playButton : Load the GameScene
        public void PlayGame()
        {
            SceneManager.LoadScene("GameScene");

        }

        //exit button: Close application
        public void ExitGame()
        {
            Application.Quit();
        }
    }

   