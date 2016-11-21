using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{
    public int count;
    public Text countText;
    private GameObject StartButton;
    private GameObject StartButtonText;
    // Use this for initialization
    void Start()
    {
        StartButton = GameObject.FindGameObjectWithTag("StartButton");
        count = 0;
        transform.FindChild("ScoreText").GetComponent<TextMesh>().text = "Score: " + count;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ScoreIncrease(int score)
    {
        count += score;
        transform.FindChild("ScoreText").GetComponent<TextMesh>().text = "Score: " + count;
    }

    public void SetCastleIntegrity(int hp)
    {
        transform.FindChild("CastleIntegrityText").GetComponent<TextMesh>().text = "Castle Integrity: " + hp;
    }

    public void SetCurrentWave(int wave)
    {
        transform.FindChild("CurrentWaveText").GetComponent<TextMesh>().text = "Current wave: " + wave;
    }

    public void GameOver()
    {
        End();
        StartButton.transform.FindChild("StartText").GetComponent<TextMesh>().text = "Game Over. Try again?";
    }

    public void Victory()
    {
        End();
        StartButton.transform.FindChild("StartText").localPosition = new Vector3(-0.4f, 0.1f, 0);
        StartButton.transform.FindChild("StartText").GetComponent<TextMesh>().text = "Victory! Play again?";
    }

    public void End()
    {
        GameObject SpawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
        Destroy(SpawnPoint);
        StartButton.gameObject.GetComponent<MeshRenderer>().enabled = true;
        StartButton.transform.FindChild("StartText").gameObject.GetComponent<MeshRenderer>().enabled = true;
        StartButton.gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
