using Scripts.Infostructure.Factory;
using Scripts.Infostructure.Services;
using Scripts.Player;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{
    public Animator startPanel;
    public Animator gamePanel;
    public Animator gameOverPanel;
    public Animator startOverlay;
    public Animator tutorial;
    public Animator moveCamera;
    public Animator transition;

    public Text bestText;
    public Text scoreText;

    [HideInInspector]
    public bool gameStarted;

    private IGameFactory _gameFactory;

    PlayerMove player;

    void Start()
    {
        _gameFactory = AllServices.Container.Single<IGameFactory>();

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!gameStarted)
            {
                StartGame();
            }
            else if (!gamePanel.gameObject.activeSelf)
            {
                StartCoroutine(RestartGame());
            }
        }
    }

    void StartGame()
    {
        gameStarted = true;

        moveCamera.SetTrigger("MoveCamera");

        startPanel.SetTrigger("Fade");
        startOverlay.SetTrigger("Fade");

        tutorial.SetBool("Invisible", false);

        gamePanel.SetBool("Visible", true);

        
    }

    public void GameOver()
    {
        if (!gamePanel.gameObject.activeSelf)
            return;

        gamePanel.gameObject.SetActive(false);
        gameOverPanel.SetTrigger("Game over");

        
    }

    IEnumerator RestartGame()
    {
        transition.SetTrigger("Transition");

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
