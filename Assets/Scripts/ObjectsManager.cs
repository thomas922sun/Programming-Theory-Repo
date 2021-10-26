using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsManager : MonoBehaviour
{
    // Start is called before the first frame update


    public float objectLiftspan;

    public int objectPoints;

    private MeshRenderer meshRenderer;
    private ParticleSystem pS;

    private UIManager UIm;

    public void Start()
    {
        //Start the coroutine we define below named ExampleCoroutine.
        StartCoroutine(DestoryItself());

        UIm = GameObject.Find("UIManager").GetComponent<UIManager>();

        meshRenderer = GetComponent<MeshRenderer>();
        pS = GetComponent<ParticleSystem>();
        pS.Stop();
    }

    //// Update is called once per frame
    //public void Update()
    //{

    //}

    IEnumerator DestoryItself()//what if not touched
    {
        yield return new WaitForSeconds(objectLiftspan);
       
        Destroy(gameObject);
    }

    public void AddScore()
    {
        ScoreManager.Instance.Scores += objectPoints;

        if (ScoreManager.Instance.Scores > ScoreManager.Instance.highestScore)
        {
            ScoreManager.Instance.highestScore = ScoreManager.Instance.Scores;
            ScoreManager.Instance.highScorePlayerName = ScoreManager.Instance.thisPlayerName;
            UpdateHighestScoreUI();

            ScoreManager.Instance.SaveHighestScore();
        }
    }

    public void OnMouseDown()
    {
        //add points
        AddScore();
        //Destory this gameobject
        meshRenderer.enabled = false;
        pS.Play();

        UIm.UpdateScoreUI();
        Destroy(gameObject, 2);
    }
    void UpdateHighestScoreUI()
    {
        //update the highestScoreTextUI in this scene
    }
}
