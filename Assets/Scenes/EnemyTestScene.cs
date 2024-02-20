using MyGame.PlayerControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyGame.UnitTest
{
    public class EnemyTestScene : MonoBehaviour
    {
        public Player player;

        private void Awake()
        {
            if(player == null)
            {
                player = FindObjectOfType<Player>();
            }
        }

        bool update = true;

        void Update()
        {
            if (update)
            {
                if (!ListenerManager.HasInstance)
                {
                    return;
                }
                player.gameObject.SetActive(true);
                update = false;
            }
            
        }
    }
}

