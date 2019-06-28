﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // CanvasGroup 컴포넌트를 저장할 변수
    public CanvasGroup fadeCg;

    // Fade in 처리 시간
    [Range(0.5f, 3.0f)]
    public float fadeDuration = 1.0f;

    // 호출할 씬과 씬 로드 방식을 저장할 딕셔너리
    public Dictionary<string, LoadSceneMode> loadScenes = new Dictionary<string, LoadSceneMode>();

    // 호출할 씬의 정보 설정
    void InitSceneInfo()
    {
        // 호출할 씬의 정보를 딕셔너리에 추가
        loadScenes.Add("Boss1", LoadSceneMode.Additive);
    }

    // Start is called before the first frame update
    IEnumerator Start()
    {
        InitSceneInfo();

        // 처음 알파값을 설정(불투명)
        fadeCg.alpha = 1.0f;

        // 여러개의 씬을 코루틴으로 호출
        foreach(var _loadScene in loadScenes)
        {
            yield return StartCoroutine(LoadScene(_loadScene.Key, _loadScene.Value));
        }
    }

    IEnumerator LoadScene(string sceneName, LoadSceneMode mode)
    {
        // 비동기 방식으로 씬을 로드하고 로드가 완료될 때 까지 대기함
        yield return SceneManager.LoadSceneAsync(sceneName, mode);

        // 호출된 씬을 활성화
        Scene loadedScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene(loadedScene);
    }

    // Fade In / Out 시키는 함수
    IEnumerator Fade(float finalAlpha)
    {
        // 라이트맵이 깨지는 것을 방지하기 위해 스테이지 씬을 활성화
        //SceneManager.SetActiveScene(SceneManager.GetSceneByName("Boss1"));
        //fadeCg.blocksRaycasts = true;

        // 절대값 함수로 백분율을 계산
        float fadeSpeed = Math.Abs(fadeCg.alpha - finalAlpha) / fadeDuration;

        // 알파값을 조정
        while(!Mathf.Approximately(fadeCg.alpha, finalAlpha))
        {
            // MoveToward 함수는 Lerp함수와 동일한 함수로 알파값을 보관한다.
            fadeCg.alpha = Mathf.MoveTowards(fadeCg.alpha, finalAlpha, fadeSpeed * Time.deltaTime);
            yield return null;
        }

        fadeCg.blocksRaycasts = false;

        // fade In이 완료된 후 SceneLoader 씬은 삭제(Unload)
        SceneManager.UnloadSceneAsync("SceneLoader");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
