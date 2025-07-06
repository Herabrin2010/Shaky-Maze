using Unity.VisualScripting;
using UnityEngine;

public class BallConroller : MonoBehaviour
{
    [SerializeField] private GameObject WinPanel;
    [SerializeField] private GameObject LosePanel;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            Time.timeScale = 0;
            WinPanel.SetActive(true);
            Debug.Log("Win");
        }

        else if (other.CompareTag("Obstracle"))
        {
            Time.timeScale = 0;
            LosePanel.SetActive(true);
            Debug.Log("Lose");
        }
    }
}
