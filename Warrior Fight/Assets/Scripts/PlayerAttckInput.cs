using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttckInput : MonoBehaviour
{
    private CharacterAnimations playerAnimation;

    void Awake()
    {
        playerAnimation = GetComponent<CharacterAnimations>();
    }

    // Update is called once per frame
    void Update()
    {
        // J for Defence
        if (Input.GetKeyDown(KeyCode.J))
        {
            playerAnimation.Defend(true);
        }
        if (Input.GetKeyUp(KeyCode.J))
        {
            playerAnimation.Defend(false);
        }

        // K for Attack
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (Random.Range(0, 2) > 0)
            {
                playerAnimation.Attack_1();
            }
            else
            {
                playerAnimation.Attack_2();
            }
        }
    }
}
