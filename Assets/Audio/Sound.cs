using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    public int volume = 1;
    public int pitch = 1;
    public bool loop = false;
    [HideInInspector] public AudioSource source;
}
