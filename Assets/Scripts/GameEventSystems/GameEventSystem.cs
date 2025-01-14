using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventSystems
{
    public static class GameEventSystem
    {
        public static event Action<string> OnPlayerPickUpCollectible;
        public static event Action OnPlayerHeal;

        public static void UpdateScore(string Name)
        {
            OnPlayerPickUpCollectible?.Invoke(Name);
        }

        public static void Heal()
        {
            OnPlayerHeal?.Invoke();
        }
    }
}
