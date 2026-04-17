using UnityEngine;
using UnityEngine.UI;

public class DifficultyWindow : GenericWindow
{
    public Toggle[] toggles;
    public Toggle easy;
    public Toggle normal;
    public Toggle hard;
    public int selected;

    private void  Awake()
    {
        toggles[0].onValueChanged.AddListener(OnEasy);
        toggles[1].onValueChanged.AddListener(OnNormal);
        toggles[2].onValueChanged.AddListener(OnHard);
    }

    public override void Open()
    {
        base.Open();
        toggles[selected].isOn = true;
    }

    public override void Close()
    {
        base.Close();
    }

    public void OnEasy(bool active)
    {
        if (active)
        {
            Debug.Log("Easy");
        }
    }

    public void OnNormal(bool active)
    {
        if (active)
        {
            Debug.Log("Normal");
        }
    }

    public void OnHard(bool active)
    {
        if (active)
        {
            Debug.Log("Hard");
        }
    }

    public void OnCancle()
    {
        windowManager.Open(0);
    }

    public void OnApply()
    {
        windowManager.Open(0);
    }
}
