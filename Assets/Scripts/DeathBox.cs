using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour
{
    public PlayerManager playerManager;

    private void OnTriggerEnter(Collider other)
    {
        playerManager.Dead();
    }
}
