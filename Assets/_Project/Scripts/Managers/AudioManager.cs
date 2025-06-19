using TreeEditor;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource machinegunShootAS;
    public AudioSource coinCollectedAS;
    public AudioSource getHitAS;
    public AudioSource playerGetHitAS;
    public AudioSource zombieGrowlAS;


    //(*)
    public AudioSource playerWalkAS;

    public void PlayMachinegunShootSFX()
    {
        machinegunShootAS.Play();
    }
    public void PlayCoinCollectedSFX()
    {
        coinCollectedAS.Play();
    }
    public void PlayGetHitSFX()
    {
        getHitAS.Play();
    }
    public void PlayPlayerGetHitSFX()
    {
        playerGetHitAS.Play();
    }
    public void PlayZombieGrowlSFX()
    {
        zombieGrowlAS.Play();
    }


    //(*)
    public void PlayPlayerWalkSFX()
    {
        playerWalkAS.Play();
    }


}
