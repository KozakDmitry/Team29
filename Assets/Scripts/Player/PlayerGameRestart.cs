using Scripts.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameRestart : MonoBehaviour
{
    public event Action Restart;

    private void Awake()
    {
        GetComponent<PlayerDeath>().Dying += RestartGame;
    }

    private void RestartGame()
    {
        StartCoroutine(SecondsToRestart());
    }

    private IEnumerator SecondsToRestart()
    {
        yield return new WaitForSeconds(2f);
        Restart?.Invoke();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
