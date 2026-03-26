using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public void PlayGame()
	{
		SceneManager.LoadSceneAsync(1);
	}
	public void QuitGame()
	{
		Application.Quit();
	}

	public class PauseMenu : MonoBehaviour
	{
		public GameObject pauseMenuUI;
		public static bool GameIsPaused = false;

		void Start()
		{
			pauseMenuUI.SetActive(false); // menu is hidden at start
		}

		void Update()
		{
			if (Input.GetKeyDown(KeyCode.Escape)) // Check for Escape key press
			{
				if (GameIsPaused)
				{
					Resume();
				}
				else
				{
					Pause();
				}
			}
		}

		public void Resume()
		{
			pauseMenuUI.SetActive(false);
			Time.timeScale = 1f; // Resume normal time flow
			GameIsPaused = false;
		}

		void Pause()
		{
			pauseMenuUI.SetActive(true);
			Time.timeScale = 0f; // Freeze time
			GameIsPaused = true;
		}
		public void LoadMenu()
		{
			Time.timeScale = 1f; //reset time scale before loading a new scene
			SceneManager.LoadScene("PauseMenu"); 
		}
	}
}
