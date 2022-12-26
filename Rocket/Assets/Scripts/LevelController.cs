using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    //rocket
    public GameObject playerController;

    public static LevelController Current;
    public bool gameActive = false;

    public GameObject startMenu, gameMenu, gameOverMenu, finishMenu;
    public Text scoreText, finishScoreText, currentLevelText, nextLevelText, startingMenuMoneyText, gameOverMenuMoneyText, finishGameMoneyText;

    public Slider levelProgresBar;
    public float maxDistance;
    public GameObject finishLine;

    public AudioSource gameMusicAudioSource;
    public AudioClip victoryAudioClip, gameOverAudioClip;

    int currentLevel;
    int score;

    public DailyReward dailyReward;

    public Text Guc;

    public Slider sliderGucslider;
    public Text gucText;



    // Start is called before the first frame update
    private void Awake()
    {
       Time.timeScale = 0;
        playerController = GameObject.FindGameObjectWithTag("charracter");
        PlayerPrefs.SetInt("Guc",40);
        PlayerPrefs.SetInt("oyunsuruyor", 0);

    }

    void Start()
    {
        sliderGucslider.maxValue = 100;
        PlayerPrefs.SetInt("currentLevel", 1);
        Current = this;
        currentLevel = PlayerPrefs.GetInt("currentLevel");
        if (SceneManager.GetActiveScene().name != "Level " + currentLevel)
        {
            SceneManager.LoadScene("Level " + currentLevel);
        }
        else
        {
            PlayerController.Current = GameObject.FindObjectOfType<PlayerController>();
            GameObject.FindObjectOfType<MarketController>().InitializeMarketController();
            dailyReward.InitializedDailyReward();
            currentLevelText.text = (currentLevel).ToString();
            nextLevelText.text = (currentLevel + 1).ToString();
            /*int money = PlayerPrefs.GetInt("money");
            startingMenuMoneyText.text = money.ToString();*/
            UpdateMoneyTexts();
        }
        gameMusicAudioSource = Camera.main.GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        if (gameActive)
        {
            Time.timeScale = 1;
            PlayerController Player = PlayerController.Current;
            // float distance = finishLine.transform.position.z - PlayerController.Current.transform.position.z;
            float distance = finishLine.transform.position.z - playerController.GetComponent<PlayerController>().transform.position.z;
            levelProgresBar.value = 1 - (distance / maxDistance); // Bu deðer karakteterimiz finish noktasýna ne kadar uzaksa max 1 vericek yakýnsa 0 vericek biz
                                                                  // bu kod finishe doðru giderken yukarýda ki progressbarýn dolmasýný saðlýyor.

            gucText.text = "%" + PlayerPrefs.GetInt("Guc");
            sliderGucslider.value = PlayerPrefs.GetInt("Guc");



        }

    }
    public void StartLevel()
    {

        PlayerPrefs.SetInt("oyunsuruyor", 1);
        playerController.GetComponent<PlayerController>().ChangedSpeed(playerController.GetComponent<PlayerController>().runningSpeed);
        startMenu.SetActive(false);
        gameMenu.SetActive(true);
        playerController.GetComponent<PlayerController>().animator.SetBool("running", true);

        gameActive = true;

        maxDistance = finishLine.transform.position.z - playerController.GetComponent<PlayerController>().transform.position.z;
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LoadNextLevel()
    {
        SceneManager.LoadScene("Level " + (currentLevel + 1));
    }
    public void GameOver()
    {
        gameMusicAudioSource.Stop();
        gameMusicAudioSource.PlayOneShot(gameOverAudioClip);
        UpdateMoneyTexts();
        gameMenu.SetActive(false);
        gameOverMenu.SetActive(true);
        gameActive = false;

    }
    public void FinishGame()
    {
        gameMusicAudioSource.Stop();
        gameMusicAudioSource.PlayOneShot(victoryAudioClip);
        GiveMoneyToPlayer(score);
        PlayerPrefs.SetInt("currentLevel", currentLevel + 1);
        finishScoreText.text = score.ToString();
        gameMenu.SetActive(false);
        finishMenu.SetActive(true);
        gameActive = false;
    }

    public void ChangeScore(int increment)
    {
        score += increment;
        scoreText.text = score.ToString();
    }
    public void GiveMoneyToPlayer(int increment)
    {
        int money = PlayerPrefs.GetInt("money");
        money = Mathf.Max(0, money + increment);
        PlayerPrefs.SetInt("money", money);
        UpdateMoneyTexts();
    }

    public void UpdateMoneyTexts()
    {
        int money = PlayerPrefs.GetInt("money");
        startingMenuMoneyText.text = money.ToString();
        gameOverMenuMoneyText.text = money.ToString();
        finishGameMoneyText.text = money.ToString();
    }
}
