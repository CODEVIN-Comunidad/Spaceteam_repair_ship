using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip playerHitEnemySound, playerSwordSound, playerJumpSound, playerDeathSound, playerHitObjectSound, playerCollectSound, enemyHitSound, enemyDeathSound, endLevelSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        playerHitObjectSound = Resources.Load<AudioClip>("MDSFX_PlayerHitLight_1_0");
        playerHitEnemySound = Resources.Load<AudioClip>("MDSFX_PlayerHitHeavy_1_0");
        playerSwordSound = Resources.Load<AudioClip>("playerSword");
        playerJumpSound = Resources.Load<AudioClip>("playerJump");
        playerDeathSound = Resources.Load<AudioClip>("MDSFX_PlayerDown_1_0");
        playerCollectSound = Resources.Load<AudioClip>("MDSFX_Buy_1_0");
        enemyHitSound = Resources.Load<AudioClip>("MDSFX_FoeHit_1_0");
        enemyDeathSound = Resources.Load<AudioClip>("MDSFX_FoeDown_1_0");
        endLevelSound = Resources.Load<AudioClip>("MDME_Victory_1_0");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "MDSFX_PlayerHitLight_1_0":
                audioSrc.PlayOneShot(playerHitObjectSound);
                break;
            case "MDSFX_PlayerHitHeavy_1_0":
                audioSrc.PlayOneShot(playerHitEnemySound);
                break;
            case "playerSword":
                audioSrc.PlayOneShot(playerSwordSound);
                break;
            case "playerJump":
                audioSrc.PlayOneShot(playerJumpSound);
                break;
            case "MDSFX_PlayerDown_1_0":
                audioSrc.PlayOneShot(playerDeathSound);
                break;
            case "MDSFX_Buy_1_0":
                audioSrc.PlayOneShot(playerCollectSound);
                break;
            case "MDSFX_FoeHit_1_0":
                audioSrc.PlayOneShot(enemyHitSound);
                break;
            case "MDSFX_FoeDown_1_0":
                audioSrc.PlayOneShot(enemyDeathSound);
                break;
            case "MDME_Victory_1_0":
                audioSrc.PlayOneShot(endLevelSound);
                break;


        }
    }
}
