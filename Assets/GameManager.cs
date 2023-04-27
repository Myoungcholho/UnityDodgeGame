using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI; // UI���� ������Ʈ�� ������ �����ϰ� ���
using UnityEngine.SceneManagement; // ���� ������ϴ� ���

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; // TEXT ������Ʈ
    public Text timeText; // 
    public Text recordText;

    private float surviveTime;
    private bool isGameover;

    void Start()
    {
        surviveTime = 0;
        isGameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameover)
        {
            surviveTime += Time.deltaTime;
            timeText.text = "Time :" + (int)surviveTime;
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public void EndGame()
    {
        // 1. ���ӿ����� �Ǵ¼��� �ð����� ����
        // 2. R �� ������ �� ���µǰ� , 
        // ---
        // 3. BestTime�� �������� ���� �� �ð��� ���� �ð����� �۴ٸ� ����
        // 4. Map�ڷᱸ���� Set
        // 5. bestTime�� ������ �ؽ�Ʈ�� ����
        
        isGameover = true;
        gameoverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if(surviveTime > bestTime)
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }
        recordText.text = "Best Time : " + (int)bestTime;

    }
}
