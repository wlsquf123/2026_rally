using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public GameObject UIManagerObj;
    public GameObject StoreManagerObj;
    public GameObject MainObj;

    // 핵심: 모든 이동은 이 함수를 거칩니다.
    public void LoadStage(int index)
    {
        var gm = GameManager.Instance;
        gm.Stage = index; // 현재 스테이지 번호 저장

        Time.timeScale = 1f;
        gm.PlayerHp = gm.PlayerMaxHp;

        // UI 초기화 (씬 이동 시 꺼줌)
        if (gm.UIManager != null)
        {
            gm.UIManager.GameOverObj.SetActive(false);
            gm.UIManager.GameClearObj.SetActive(false);
        }

        if (index == 0) // 메인 메뉴 이동
        {
            MainObj?.SetActive(true);
            UIManagerObj?.SetActive(false);
            StoreManagerObj?.SetActive(false);
            gm.money = 0f;
            gm.KillCount = 0;
            SceneManager.LoadScene("Main");
        }
        else // 스테이지 이동 (Stage1, Stage2, Stage3...)
        {
            MainObj?.SetActive(false);
            UIManagerObj?.SetActive(true);
            StoreManagerObj?.SetActive(true);

            // 킬 카운트 설정 (1스테이지=3, 2스테이지=4...)
            gm.KillCountReset(index + 2);
            SceneManager.LoadScene("Stage" + index);
        }
    }

    // [게임 오버 시] "다시하기" 버튼에 연결
    public void RetryStage()
    {
        // GameManager에 저장된 현재 스테이지 번호로 다시 로드
        LoadStage(GameManager.Instance.Stage);
    }

    // [게임 클리어 시] "다음 스테이지" 버튼에 연결
    public void NextStage()
    {
        // 현재 스테이지 번호 + 1 로 이동
        LoadStage(GameManager.Instance.Stage + 1);
    }

    public void Exit() => Application.Quit();
}