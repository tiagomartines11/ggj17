using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
	AudioController audioController;

    string[] flavors = new string[] {
		"Sia Found Captive At Beyoncé's Basement",
        "Scientists discover Vitamin C actually gives you cancer!",
		"Olsen Twins not real twins (not even sisters)",
		"Switzerland is not real",
		"Gayvolution confirmed! 'We knew this was going to happen!'",
		"140 year-old woman says 'the secret is esating only olive oil'",
		"Yoga found out to be a form of satanic worship in disguise",
		"Kim Kardashian is actually Taylor Swift's BFF",
		"Kim Kardashian pregnant and calling her new son 'Wild West'",
		"Madonna reveals that Lady Gaga is her clone",
		"Donald Trump may secretely be Melania in disguise"
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
		"article11"
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

    public void ShowIntro()
    {
        if (audioController) audioController.playButton();
        SceneManager.LoadScene("GOSSIP", LoadSceneMode.Single);
    }

    public void StartGame()
    {
        if (audioController) audioController.playButton();
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

		PlayerPrefs.DeleteKey("curStory");
		PlayerPrefs.Save();

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

			Sprite newArticle = Resources.Load<Sprite>("articles/"+histories[PlayerPrefs.GetInt("curStory", 0)]);

			article.GetComponent<Image> ().overrideSprite = newArticle;
		}
    }
}