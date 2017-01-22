using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    string[] flavors = new string[] {
        "Olsen Twins Aren't Twins",
        "Azealia Banks Is Actually White",
        "Kim Kardashian Is Pregnant And Will Call Her Son 'Wild West'",
        "Madonna Reveals That Lady Gaga Is Her Clone",
        "Ellen Degeneres Throws A Man Out Of The Studio Because He Is Straight",
        "After The 'Ellen' Incident, A Gay Insurrection Is On The Rise",
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
        if (current == "Level1")
            labelLevel.text = "- Level 01 -";
        else if (current == "Level2")
            labelLevel.text = "- Level 02 -";
        else
            labelLevel.text = "- Level 03 -";

        labelFlavor.text = "\"" + flavors[curStory] + "\"";
    }

    // Update is called once per frame
    void Update() {

    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }

    public void StartLevel()
    {
        transform.Find("Start").gameObject.SetActive(false);
        transform.Find("HUD").gameObject.SetActive(true);
    }

    public void Advance()
    {
        var current = SceneManager.GetActiveScene().name;
        if (current == "Level1")
            SceneManager.LoadScene("Level2", LoadSceneMode.Single);
        else if (current == "Level2")
            SceneManager.LoadScene("Level3", LoadSceneMode.Single);
        else
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void Restart()
    {
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

    public void SetupEndScreen(bool isWin, int goalScore, int subGoalScore)
    {
        Transform which = gameObject.transform.Find(isWin ? "Win" : "Lose");
        which.Find("goalScore").GetComponent<Text>().text = goalScore.ToString();
        which.Find("subGoalScore").GetComponent<Text>().text = subGoalScore.ToString();
        which.gameObject.SetActive(true);
        gameObject.transform.Find("HUD").gameObject.SetActive(false);
    }
}
