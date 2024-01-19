using Scripts.Infostructure.Factory;
using Scripts.Infostructure.Services;
using Scripts.Player;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Scripts.UI.Logic
{


    public class StartMenuManager : MonoBehaviour
    {

        public Animator moveCamera;


        [HideInInspector]
        public bool gameStarted;

        void Start()
        {


        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!gameStarted)
                {
                    StartGame();
                }
            }
        }

        void StartGame()
        {
            gameStarted = true;

            moveCamera.SetTrigger("MoveCamera");



        }


    }
}
