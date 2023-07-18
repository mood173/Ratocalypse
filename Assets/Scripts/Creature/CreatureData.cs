using System.Collections.Generic;
using UnityEngine;

namespace TeamOdd.Ratocalypse.Creature
{
    public class CreatureData
    {
        public float Hp { get; private set; }

        public int Stamina { get; private set; }

        public List<string> StatusEffectList;

        public void SetHp(int value)
        {
            Hp = value;
        }
        public void SetStamina(int value)
        {
            Stamina = value;
        }

    }
}