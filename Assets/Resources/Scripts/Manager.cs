using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    [SerializeField] Text logLabel;
    int[,] mazeData;
    public Vector2 startPos, endPos, playerPos;
    int facing;
    [SerializeField] GameObject tempPlayer, actGroup, scrollView;
    [SerializeField] Image panel;
    void Start()
    {
        logLabel.text = "";
        mazeData = GetComponent<MazeGenerator>().getMazeData();
        playerPos = startPos;

        for (int i = 0; i < 4; i++)
        {
            switch (i)
            {
                case 0:
                    if (mazeData[(int)startPos.x, (int)startPos.y - 1] == 0)
                    {
                        facing = i;
                    }
                    break;
                case 1:
                    if (mazeData[(int)startPos.x + 1, (int)startPos.y] == 0)
                    {
                        facing = i;
                    }
                    break;
                case 2:
                    if (mazeData[(int)startPos.x, (int)startPos.y + 1] == 0)
                    {
                        facing = i;
                    }
                    break;
                case 3:
                    if (mazeData[(int)startPos.x - 1, (int)startPos.y] == 0)
                    {
                        facing = i;
                    }
                    break;
            }
        }

        tempPlayer.transform.position = new Vector3(playerPos.x, 0, playerPos.y) / 2;

        Debug.Log("facing: " + facing);
    }

    /*  void Update()
      {
          logLabel.text = Time.deltaTime.ToString() + "\n" + logLabel.text;
      }*/

    public void turnLeft()
    {
        if (facing != 0) facing--;
        else facing = 3;

        Debug.Log("facing: " + facing);
    }

    public void turnRight()
    {
        if (facing != 3) facing++;
        else facing = 0;

        Debug.Log("facing: " + facing);
    }

    public void goForward()
    {
        if (playerPos == startPos)
        {
            tempPlayer.GetComponent<TrailRenderer>().time = Mathf.Infinity;
        }

        switch (facing)
        {
            case 0:
                if (mazeData[(int)playerPos.x, (int)playerPos.y - 1] == 0)
                {
                    playerPos += Vector2.down * 2;
                    tempPlayer.transform.position += Vector3.back;
                }
                break;
            case 1:
                if (mazeData[(int)playerPos.x + 1, (int)playerPos.y] == 0)
                {
                    playerPos += Vector2.right * 2;
                    tempPlayer.transform.position += Vector3.right;

                }
                break;
            case 2:
                if (mazeData[(int)playerPos.x, (int)playerPos.y + 1] == 0)
                {
                    playerPos += Vector2.up * 2;
                    tempPlayer.transform.position += Vector3.forward;

                }
                break;
            case 3:
                if (mazeData[(int)playerPos.x - 1, (int)playerPos.y] == 0)
                {
                    playerPos += Vector2.left * 2;
                    tempPlayer.transform.position += Vector3.left;

                }
                break;
        }
        tempPlayer.transform.position = new Vector3(playerPos.x, 0, playerPos.y) / 2;

        if (playerPos == endPos)
        {
            logLabel.text = "\n" + logLabel.text;
            logLabel.text = "目的地に着きました。" + logLabel.text;
            actGroup.SetActive(false);
        }
    }

    public void checkAround()
    {
        logLabel.text = "\n" + logLabel.text;
        switch (facing)
        {
            case 0:
                if (mazeData[(int)playerPos.x + 1, (int)playerPos.y] == 1) logLabel.text = "右は壁です。" + logLabel.text;
                else if (new Vector2(playerPos.x + 2, playerPos.y) == startPos) logLabel.text = "右は開始地点です。" + logLabel.text;
                else if (new Vector2(playerPos.x + 2, playerPos.y) == endPos) logLabel.text = "右は目的地です。" + logLabel.text;
                else logLabel.text = "右は通路です。" + logLabel.text;

                if (mazeData[(int)playerPos.x, (int)playerPos.y - 1] == 1) logLabel.text = "前は壁です。" + logLabel.text;
                else if (new Vector2(playerPos.x, playerPos.y - 2) == startPos) logLabel.text = "前は開始地点です。" + logLabel.text;
                else if (new Vector2(playerPos.x, playerPos.y - 2) == endPos) logLabel.text = "前は目的地です。" + logLabel.text;
                else logLabel.text = "前は通路です。" + logLabel.text;

                if (mazeData[(int)playerPos.x - 1, (int)playerPos.y] == 1) logLabel.text = "左は壁です。" + logLabel.text;
                else if (new Vector2(playerPos.x - 2, playerPos.y) == startPos) logLabel.text = "左は開始地点です。" + logLabel.text;
                else if (new Vector2(playerPos.x - 2, playerPos.y) == endPos) logLabel.text = "左は目的地です。" + logLabel.text;
                else logLabel.text = "左は通路です。" + logLabel.text;
                break;

            case 1:
                if (mazeData[(int)playerPos.x, (int)playerPos.y + 1] == 1) logLabel.text = "右は壁です。" + logLabel.text;
                else if (new Vector2(playerPos.x, playerPos.y + 2) == startPos) logLabel.text = "右は開始地点です。" + logLabel.text;
                else if (new Vector2(playerPos.x, playerPos.y + 2) == endPos) logLabel.text = "右は目的地です。" + logLabel.text;
                else logLabel.text = "右は通路です。" + logLabel.text;

                if (mazeData[(int)playerPos.x + 1, (int)playerPos.y] == 1) logLabel.text = "前は壁です。" + logLabel.text;
                else if (new Vector2(playerPos.x + 2, playerPos.y) == startPos) logLabel.text = "前は開始地点です。" + logLabel.text;
                else if (new Vector2(playerPos.x + 2, playerPos.y) == endPos) logLabel.text = "前は目的地です。" + logLabel.text;
                else logLabel.text = "前は通路です。" + logLabel.text;

                if (mazeData[(int)playerPos.x, (int)playerPos.y - 1] == 1) logLabel.text = "左は壁です。" + logLabel.text;
                else if (new Vector2(playerPos.x, playerPos.y - 2) == startPos) logLabel.text = "左は開始地点です。" + logLabel.text;
                else if (new Vector2(playerPos.x, playerPos.y - 2) == endPos) logLabel.text = "左は目的地です。" + logLabel.text;
                else logLabel.text = "左は通路です。" + logLabel.text;
                break;

            case 2:
                if (mazeData[(int)playerPos.x - 1, (int)playerPos.y] == 1) logLabel.text = "右は壁です。" + logLabel.text;
                else if (new Vector2(playerPos.x - 2, playerPos.y) == startPos) logLabel.text = "右は開始地点です。" + logLabel.text;
                else if (new Vector2(playerPos.x - 2, playerPos.y) == endPos) logLabel.text = "右は目的地です。" + logLabel.text;
                else logLabel.text = "右は通路です。" + logLabel.text;

                if (mazeData[(int)playerPos.x, (int)playerPos.y + 1] == 1) logLabel.text = "前は壁です。" + logLabel.text;
                else if (new Vector2(playerPos.x, playerPos.y + 2) == startPos) logLabel.text = "前は開始地点です。" + logLabel.text;
                else if (new Vector2(playerPos.x, playerPos.y + 2) == endPos) logLabel.text = "前は目的地です。" + logLabel.text;
                else logLabel.text = "前は通路です。" + logLabel.text;

                if (mazeData[(int)playerPos.x + 1, (int)playerPos.y] == 1) logLabel.text = "左は壁です。" + logLabel.text;
                else if (new Vector2(playerPos.x + 2, playerPos.y) == startPos) logLabel.text = "左は開始地点です。" + logLabel.text;
                else if (new Vector2(playerPos.x + 2, playerPos.y) == endPos) logLabel.text = "左は目的地です。" + logLabel.text;
                else logLabel.text = "左は通路です。" + logLabel.text;
                break;

            case 3:
                if (mazeData[(int)playerPos.x, (int)playerPos.y - 1] == 1) logLabel.text = "右は壁です。" + logLabel.text;
                else if (new Vector2(playerPos.x, playerPos.y - 2) == startPos) logLabel.text = "右は開始地点です。" + logLabel.text;
                else if (new Vector2(playerPos.x, playerPos.y - 2) == endPos) logLabel.text = "右は目的地です。" + logLabel.text;
                else logLabel.text = "右は通路です。" + logLabel.text;

                if (mazeData[(int)playerPos.x - 1, (int)playerPos.y] == 1) logLabel.text = "前は壁です。" + logLabel.text;
                else if (new Vector2(playerPos.x - 2, playerPos.y) == startPos) logLabel.text = "前は開始地点です。" + logLabel.text;
                else if (new Vector2(playerPos.x - 2, playerPos.y) == endPos) logLabel.text = "前は目的地です。" + logLabel.text;
                else logLabel.text = "前は通路です。" + logLabel.text;

                if (mazeData[(int)playerPos.x, (int)playerPos.y + 1] == 1) logLabel.text = "左は壁です。" + logLabel.text;
                else if (new Vector2(playerPos.x, playerPos.y + 2) == startPos) logLabel.text = "左は開始地点です。" + logLabel.text;
                else if (new Vector2(playerPos.x, playerPos.y + 2) == endPos) logLabel.text = "左は目的地です。" + logLabel.text;
                else logLabel.text = "左は通路です。" + logLabel.text;
                break;
        }
    }

    public void seeAnswer()
    {
        panel.color = new Color(255, 255, 255, 0);
        scrollView.SetActive(false);
        actGroup.SetActive(false);
    }

    public void playAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
