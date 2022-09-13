using UnityEngine;

public class OptionsCanvas : MonoBehaviour
{
    public Canvas OptionUI;

    public void Back()
    {
        OptionUI.enabled = false;
    }
}
