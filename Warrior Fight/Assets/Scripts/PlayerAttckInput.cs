using UnityEngine;

public class PlayerAttckInput : MonoBehaviour
{
    private CharacterAnimations playerAnimation;
    public GameObject attackPoint;
    private PlayerShield shield;
    private CharacterSoundFX soundFX;

    void Start()
    {
        playerAnimation = GetComponent<CharacterAnimations>();
        shield = GetComponent<PlayerShield>();
        soundFX = GetComponentInChildren<CharacterSoundFX>();
    }

    // Update is called once per frame
    void Update()
    {
        // J for Defence
        if (Input.GetKeyDown(KeyCode.J))
        {
            playerAnimation.Defend(true);
            shield.ActivateShield(true);
        }
        if (Input.GetKeyUp(KeyCode.J))
        {
            playerAnimation.UnFreezeAnimation();
            playerAnimation.Defend(false);
            shield.ActivateShield(false);
        }

        // K for Attack
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (Random.Range(0, 2) > 0)
            {
                playerAnimation.Attack_1();
                soundFX.Attack_1();
            }
            else
            {
                playerAnimation.Attack_2();
                soundFX.Attack_2();
            }
        }
    }

    void Activate_AttackPoint()
    {
        attackPoint.SetActive(true);
    }

    void Deactivate_AttackPoint()
    {
        if (attackPoint.activeInHierarchy)
        {
            attackPoint.SetActive(false);
        }
    }
}