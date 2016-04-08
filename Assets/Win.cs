using UnityEngine;
using System.Collections;
using System.ComponentModel.Design;
using UnityEngine.UI;

public class Win : MonoBehaviour
{

    private Text[] board;
    public Text WinText;
	void Start ()
	{
	    board = GetComponentsInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    CheckWin();
	}

    void CheckWin()
    {
        if(CheckRow(0))
            HasWin(board[0].text);
        else if (CheckRow(1))
            HasWin(board[3].text);
        else if (CheckRow(2))
            HasWin(board[6].text);
        else if (CheckCol(0))
            HasWin(board[0].text);
        else if (CheckCol(1))
            HasWin(board[1].text);
        else if (CheckCol(2))
            HasWin(board[2].text);
        else if(CheckCross(0))
            HasWin(board[0].text);
        else if(CheckCross(2))
            HasWin(board[2].text);
        else
        {
            HasWin("No one");
        }

    }

    bool CheckRow(int row)
    {
        string player = board[row*3].text;
        if (board[row*3].text == player && board[row*3 + 1].text == player && board[row*3 + 2].text == player && player != "")
            return true;
        return false;
    }

    bool CheckCol(int col)
    {
        string player = board[col].text;
        if (board[col].text == player && board[col+3].text == player && board[col+6].text == player && player != "")
            return true;
        return false;
    }

    bool CheckCross(int cross)
    {
        string player = board[cross].text;
        if (cross == 0)
        {
            if (board[0].text == player && board[4].text == player && board[8].text == player)
                return true;
        }
        else if (cross == 2)
        {
            if (board[2].text == player && board[4].text == player && board[6].text == player)
                return true;
        }
        return false;
    }

    void HasWin(string player)
    {
        if(player != "X" && player != "O")
            WinText.text = "";
        else
            WinText.text = player + " has won";
        
    }
}
