using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI; // UI관련 컴포넌트를 변수로 선언하고 사용
using UnityEngine.SceneManagement; // 씬을 재시작하는 기능

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; // TEXT 오브젝트
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
        // 1. 게임오버가 되는순간 시간누적 중지
        // 2. R 로 눌렀을 때 리셋되게 , 
        // ---
        // 3. BestTime을 가져오고 만약 그 시간이 측정 시간보다 작다면 갱신
        // 4. Map자료구조에 Set
        // 5. bestTime을 가져와 텍스트에 셋팅
        
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
