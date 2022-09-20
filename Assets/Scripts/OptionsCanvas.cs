using UnityEngine;
using UnityEngine.UI;

public class OptionsCanvas : MonoBehaviour
{
    public Canvas OptionUI;

    public Slider MusicSlider;
    public Slider SoundSlider;

    public void onMusicChange()
    {
        SoundManagerUI.Instance.SetMusicVolume(MusicSlider.value);
    }

    public void onSoundChange()
    {
        SoundManagerUI.Instance.SetSoundVolume(SoundSlider.value);
    }

    public void Back()
    {
        OptionUI.enabled = false;
    }
}
