using UnityEngine;

public class Pause : MonoBehaviour
{
    [Header ("Настройки")]
    [SerializeField] private bool isPause = false;

    [Header ("Объекты")]
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private GameObject SettingsPanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (isPause == false)
            {
                PauseOn();
                isPause = true;
            }

            else
            {
                if (SettingsPanel.activeSelf)
                {
                    SettingsPanel.SetActive(false);
                    PauseOn();
                }

                else
                {
                    PauseOff();
                    isPause = false;
                }
            }
        }
    }

    public void PauseOn()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void PauseOff()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
