using UnityEngine;

namespace Raycastly.AudioManager
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance;

        [SerializeField]
        private SoundLibrary sfxLibrary;
        private AudioSource sfx2DSource;
        [SerializeField]

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        public void PlaySound3D(AudioClip clip, Vector3 pos)
        {
            if (clip != null)
            {
                var sound = Instantiate(sfx2DSource.gameObject, pos, Quaternion.identity);
                sound.GetComponent<AudioSource>().PlayOneShot(clip);
                Destroy(sound, clip.length);
            }
        }

        public void PlaySound3D(string soundName, Vector3 pos)
        {
            PlaySound3D(sfxLibrary.GetClipFromName(soundName), pos);
        }

        public void PlaySound2D(string soundName)
        {
            sfx2DSource.PlayOneShot(sfxLibrary.GetClipFromName(soundName));
        }
    }
}