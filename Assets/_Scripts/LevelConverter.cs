using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class LevelConverter : MonoBehaviour
{
    public GameObject bubble4;
    public GameObject bubble1;
    public GameObject bubble2;
    public GameObject bubble3;
    [System.Serializable]
    public class Bubble
    {
        public int x;
        public int y;
        public int st;
    }

    [System.Serializable]
    public class Level
    {
        public int presses;
        public List<Bubble> bubbles;
    }

    [System.Serializable]
    public class LevelPack
    {
        public List<Level> levels;
    }

    void Start()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("1");

        if (jsonFile != null)
        {
            string jsonString = jsonFile.text;
            LevelPack levelPack = JsonUtility.FromJson<LevelPack>(jsonString);
            Debug.Log(levelPack.levels[0].bubbles[0]);
           for (int i = levelPack.levels[3].bubbles.Count - 1; i >= 0; i--)
            {
                var lv = levelPack.levels[3].bubbles[i];
                Vector3 position = ConvertPositionToUnity(lv.x, lv.y);
                CreateBubble(position, lv.st);
            }

            // foreach (Level level in levelPack.levels)
            // {
            //     foreach (Bubble bubble in level.bubbles)
            //     {
            //         // Debug.Log("Bubble at (" + bubble.x + ", " + bubble.y + ") with state " + bubble.st);
            //     }
            // }
        }
        else
        {
            Debug.LogError("Failed to load JSON file");
        }
    }
    private void CreateBubble(Vector3 position, int state)
    {
         GameObject bubble;
        switch (state)
        {
            case 1:
                bubble = Instantiate(bubble1, position, Quaternion.identity);
                break;
            case 2:
                bubble = Instantiate(bubble2, position, Quaternion.identity);
                break;
            case 3:
                bubble = Instantiate(bubble3, position, Quaternion.identity);
                break;
            case 4:
                bubble = Instantiate(bubble4, position, Quaternion.identity);
                break;
            default:
                bubble = Instantiate(bubble4, position, Quaternion.identity);
                break;
        }
    }
       private Vector3 ConvertPositionToUnity(int x, int y)
    {
        float scaledX = 32 + 64 * (x - 0.85f);
        float scaledY = 64 + 64 * (6 - y);
        
        float unityX = (scaledX / 352) * Screen.width;
        float unityY = (scaledY / 480) * Screen.height;

        return Camera.main.ScreenToWorldPoint(new Vector3(unityX, unityY, Camera.main.nearClipPlane));
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.A))
        {
            SceneManager.LoadScene(0);
        }
    }
}
