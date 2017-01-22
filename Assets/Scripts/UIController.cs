using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
	AudioController audioController;

    string[] flavors = new string[] {
        "Olsen Twins Aren't Twins",
        "Azealia Banks Is Actually White",
        "Kim Kardashian Is Pregnant And Will Call Her Son 'Wild West'",
        "Madonna Reveals That Lady Gaga Is Her Clone",
        "Ellen Throws A Man Out Of The Studio Coz He's Straight",
        "After 'Ellen' Incident, Gay Insurrection Is On The Rise",
        "Sia Found Captive At Beyoncé's Basement",
        "Beyoncé Found Captive At Sia's Basement",
        "Kim Kardashian Is Taylor Swift Bff",
        "Donald Trump May Secretly Be Melania Trump In Disguise",
    };

	string[] histories = new string[] {
		"article1",
		"article2",
		"article3",
		"article4",
		"article5",
		"article6",
		"article7",
		"article8",
		"article9",
		"article10",
	};

    // Use this for initialization
    void Start()
    {
		audioController = GameObject.FindObjectOfType<AudioController> ();

        if (transform.Find("Start"))
        {
            var labelLevel = transform.Find("Start").GetChild(0).Find("LevelLabel").GetComponent<Text>();
            var labelFlavor = transform.Find("Start").GetChild(0).Find("FlavorText").GetComponent<Text>();

            var curStory = PlayerPrefs.GetInt("curStory", -1);
            if (curStory == -1)
            {
                curStory = Random.Range(0, flavors.Length);
                PlayerPrefs.SetInt("curStory", curStory);
                PlayerPrefs.Save();
            }

            var current = SceneManager.GetActiveScene().name;
            labelLevel.text = "- " + current + " -";
            labelFlavor.text = "\"" + flavors[curStory] + "\"";

            gameObject.transform.Find("HUD").Find("Text").GetComponent<Text>().text = SceneManager.GetActiveScene().name;
        }
    }

    // Update is called once per frame
    void Update() {

    }

    public void StartGame()
    {
		if (audioController) audioController.playButton ();
        SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
    }

    public void StartLevel()
    {
        if (audioController) audioController.playButton ();
        transform.Find("Start").gameObject.SetActive(false);
        transform.Find("HUD").gameObject.SetActive(true);
    }

    public void Advance()
    {
        if (audioController) audioController.playButton ();
        var current = SceneManager.GetActiveScene().name;
        int currentId = System.Int32.Parse(current.Replace("Level", ""));
        currentId++;
        if (currentId >= 10)
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        else
            SceneManager.LoadScene("Level "+currentId, LoadSceneMode.Single);
    }

    public void Restart()
    {
        if (audioController) audioController.playButton ();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        PlayerPrefs.DeleteKey("curStory");
        PlayerPrefs.Save();
    }

    public void EndGame()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        PlayerPrefs.DeleteKey("curStory");
        PlayerPrefs.Save();
    }

    public void SetupEndScreen(bool isWin, int goalScore, int totalGoals, int subGoalScore, int totalSubGoals)
    {
        Transform which = gameObject.transform.Find(isWin ? "Win" : "Lose");
        which.Find("goalScore").GetComponent<Text>().text = goalScore + "/" + totalGoals;
        which.Find("subGoalScore").GetComponent<Text>().text = subGoalScore + "/" + totalSubGoals;
        which.gameObject.SetActive(true);
        gameObject.transform.Find("HUD").gameObject.SetActive(false);

		if (isWin) {
			GameObject article = which.Find("articleWin").gameObject;

			Sprite newArticle = Resources.Load<Sprite>(histories[PlayerPrefs.GetInt("curStory", 0)]);

			article.GetComponent<Image> ().overrideSprite = newArticle;
		}
    }
}
