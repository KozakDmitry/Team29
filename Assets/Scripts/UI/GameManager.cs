using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Scripts.Player;

public class GameManager : MonoBehaviour {
	
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
	

}
