using MyGame.Input;
using MyGame.ObjectPool;
using System;
using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;
using UnityEngine.InputSystem;


namespace MyGame.PlayerControl
{
    public partial class Player : MonoBehaviour
    {
        [SerializeField] private InputReader _inputReader;
        public InputReader InputReader { get => _inputReader; }
    }
}

