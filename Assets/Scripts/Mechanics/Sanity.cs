using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Sanity : MonoBehaviour
{
    [SerializeField] private float sanity;
    [SerializeField] private float minSanity;
    [SerializeField] private float maxSanity;
    [SerializeField] private Image sanityBar;
    [SerializeField] private Image backgroundBar;

    private void Start()
    {
        // sanity bar setup
        sanity = maxSanity;
        sanityBar.fillAmount = maxSanity;
        backgroundBar.fillAmount = maxSanity;
    }

    private void Update()
    {
        if (sanity <= minSanity)
        {
            // if you reach minimum sanity you lose the game
            SceneManager.LoadScene("Lose");
        }
    }

    public void LoseSanity(float amount)
    {
        // decrease sanity
        sanity -= amount;

        // update sanity bar
        sanityBar.fillAmount = sanity / 100;
    }

}
