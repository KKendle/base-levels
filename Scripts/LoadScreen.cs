using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadScreen : MonoBehaviour {

	private bool loadScene = false;

	private Text loadingText;

//	[SerializeField]
//	private int scene;

	void Start() {
		// loadingText = GameObject.Find("Instructions").GetComponent<Text>();

		// Text scoreText = GameObject.Find("Score").GetComponent<Text>();
		// scoreText.text = ScoreKeeper.score.ToString();

		// Text scoreEnemyText = GameObject.Find("ScoreEnemy").GetComponent<Text>();
		// scoreEnemyText.text = EnemyBehavior.scoreEnemy.ToString();
		// Debug.Log("Enemy Score " + EnemyBehavior.scoreEnemy.ToString());

		// Text scoreCoinText = GameObject.Find("ScoreCoin").GetComponent<Text>();
		// scoreCoinText.text = Coin.scoreCoin.ToString();
		// Debug.Log("Enemy Score " + Coin.scoreCoin.ToString());
	}
	
	void Update () {
		if (Input.GetKeyUp(KeyCode.Space) && loadScene == false) {
			// ...set the loadScene boolean to true to prevent loading a new scene more than once...
			loadScene = true;
			
			// ...change the instruction text to read "Loading..."
			loadingText.text = "Loading...";
			
			// ...and start a coroutine that will load the desired scene.
			StartCoroutine(LoadNextScene());
		}

		if (loadScene == true) {
			// ...then pulse the transparency of the loading text to let the player know that the computer is still working.
			loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));	
		}
	}

	// The coroutine runs on its own at the same time as Update() and takes an integer indicating which scene to load.
	IEnumerator LoadNextScene() {
		// This line waits for 3 seconds before executing the next line in the coroutine.
		// This line is only necessary for this demo. The scenes are so simple that they load too fast to read the "Loading..." text.
		yield return new WaitForSeconds(2);

		LevelManager levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		levelManager.LoadNextLevel();

		// Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
//		AsyncOperation async = Application.LoadLevelAsync(scene);
//		
//		// While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
//		while (!async.isDone) {
//			yield return null;
//		}
	}
}
