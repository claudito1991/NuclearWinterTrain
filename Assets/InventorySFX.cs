using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySFX : MonoBehaviour
{
    [SerializeField] ContainMusic musicContainer;
    [SerializeField] AudioSource inventoryAudioSource;
    // Start is called before the first frame update
    void OnEnable()
    {
        inventoryAudioSource.PlayOneShot(musicContainer.audioClips[4]);
    }
    void OnDisable()
    {
        inventoryAudioSource.PlayOneShot(musicContainer.audioClips[5]);
    }

}
