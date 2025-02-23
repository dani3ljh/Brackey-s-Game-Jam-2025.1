using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public float mainVolume = 1f;
	
	public Sound[] sounds;
	
	private void Awake() {
        if (PlayerPrefs.GetInt("SetVolume") == 0)
			mainVolume = 1;
		else
			mainVolume = PlayerPrefs.GetFloat("Volume");

		foreach(Sound s in sounds){
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
			s.source.playOnAwake = s.playOnStart;
			if(s.playOnStart) {
				s.source.Play();
			}
		}
		
		UpdateSoundVolume();
	}
	
	public void UpdateSoundVolume()
	{
		foreach(Sound s in sounds){
			s.source.volume = mainVolume;
		}
	}
	
	/// <returns>Length of the sound clip</returns>
	public float PlaySound(string name)
	{
		Sound s = System.Array.Find(sounds, sound => sound.name == name);
		if(s == null)
		{
			Debug.LogWarning($"Sound {name} not found!");
			return 0f;
		}
		s.source.Play();
		return s.clip.length;
	}
}

[System.Serializable]
public class Sound
{
	public string name;
	
	public AudioClip clip;
	
	[Range(.1f, 3f)]
	public float pitch;
	public bool loop;
	public bool playOnStart;
	
	[HideInInspector]
	public AudioSource source;
}