using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : Enemy
{

    [SerializeField] float bounceAmount = 1000f;
    [SerializeField] int _bouncerAmount = 1;

    protected override void PlayerImpact(Player player)
    {
    
        Debug.Log("Player has entered");

        Rigidbody playerRigidbody = player.gameObject.GetComponent<Rigidbody>();

        if(playerRigidbody != null)
        {
            // get player velocity, revert it
            player.DecreaseHealth(_bouncerAmount);

            Vector3 bounceDirection = -playerRigidbody.velocity;

            playerRigidbody.AddForce(bounceDirection * bounceAmount);
        }
    }
}
