using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

        public float health = 100;

        public void LoseHealth (float amount) {
            health -= amount;
        }
}
