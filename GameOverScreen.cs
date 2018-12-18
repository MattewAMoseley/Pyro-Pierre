using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverScreen : MonoBehaviour {

    //project created with historic GUI component methods
    private GUISkin skin;
	
	void Start()
	{
		skin = Resources.Load("TitleGUI") as GUISkin;
	}

    //project created with historic GUI component methods
    //alt method for remake - make a canvas item and make this into two functions each linked to a button.
    void OnGUI()
	{
		const int buttonWidth = 350;
		const int instrButtonWidth = 500;
		const int buttonHeight = 65;
		
		GUI.skin = skin;
		
		if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth / 2), (2 * Screen.height / 3) - (buttonHeight / 2)+100, buttonWidth, buttonHeight), "Play Again?"))
		{
            SceneManager.LoadScene("Level1", LoadSceneMode.Single);
            /*
            Obsoleted
            Application.LoadLevel("Level" + Levels.levelNum);
            */
		}
		
		if (GUI.Button(new Rect(Screen.width / 2 - (instrButtonWidth / 2), (2 * Screen.height / 3) - (buttonHeight / 2) + 180, instrButtonWidth, buttonHeight), "Return to Menu"))
		{
            SceneManager.LoadScene("TitleScreen", LoadSceneMode.Single);
            /*
            Obsoleted
            Application.LoadLevel("TitleScreen");
            */
        }
	}
}
