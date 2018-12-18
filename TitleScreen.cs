using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
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
		const int buttonWidth = 200;
		const int instrButtonWidth = 400;
		const int buttonHeight = 65;

		GUI.skin = skin;

		if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth / 2), (2 * Screen.height / 3) - (buttonHeight / 2), buttonWidth, buttonHeight), "START"))
		{

            SceneManager.LoadScene("Level1", LoadSceneMode.Single);
            /*
            Obsoleted
            Application.LoadLevel("Level1");
            */
		}

		if (GUI.Button(new Rect(Screen.width / 2 - (instrButtonWidth / 2), (2 * Screen.height / 3) - (buttonHeight / 2) + 80, instrButtonWidth, buttonHeight), "HOW TO PLAY"))
		{
            SceneManager.LoadScene("Instructions", LoadSceneMode.Single);
            /*
            Obsoleted
            Application.LoadLevel("Instructions");
            */
        }
	}
}