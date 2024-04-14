using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Damage : MonoBehaviour
{
    [SerializeField] private int Lives = 3;
    private int crystals = 4;
    [SerializeField] GameObject[] Hearts = new GameObject[3];
    [SerializeField] GameObject[] CrystalUI = new GameObject[4];
    [SerializeField] GameObject GameText;
    private float damageTimer;
    [SerializeField] Movement Movement;
    [SerializeField] GameObject EndPanel;

    void Start()
    {
        GameText.SetActive(false);

        foreach (GameObject i in Hearts)
        {
            i.SetActive(true);
        }

        foreach (GameObject i in CrystalUI)
        {
            i.SetActive(true);
        }
    }

    public void crystalcrash()
    {
        crystals--;
        CrystalUI[crystals].SetActive(false);

        if(crystals == 0)
        {
            Time.timeScale = 0f;
            EndPanel.SetActive(true);

        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (Lives > 0 && damageTimer < 0)
        {
            Lives--;
            damageTimer = 1f;

            if (Lives == 0)
            {
                Hearts[Lives].SetActive(false);

                GameText.SetActive(true);

                Movement.GameOver = true;

                StartCoroutine(ReloadScene());
            }
            else
            {
                Hearts[Lives].SetActive(false);
            }
        }

    }

    IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Update()
    {
        damageTimer = damageTimer - Time.deltaTime;
    }

}
