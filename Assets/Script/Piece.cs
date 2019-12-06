using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
	public bool isWhite;
	public bool isKing;

	public bool IsForceToMove(Piece[,] board, int x, int y)
	{
		if (isWhite || isKing) 
		{
			//Левый верх
			if (x >= 2 && y <= 5) {
				Piece p = board [x - 1, y + 1];
				// если шашка не того цвета
				if (p != null && p.isWhite != isWhite) {
					//Проверка после сруба
					if (board [x - 2, y + 2] == null)
						return true;
				}
			}

			//правый вверх
			if (x <= 5 && y <= 5) {
				Piece p = board [x + 1, y + 1];
                // если шашка не того цвета
                if (p != null && p.isWhite != isWhite) {
                    //Проверка после сруба
                    if (board [x + 2, y + 2] == null)
						return true;
				}
			}
		} 
		if(!isWhite || isKing) 
		{
			
				//левый низ
				if (x >= 2 && y >= 2) 
				{
					Piece p = board [x - 1, y - 1];
                // если шашка не того цвета
                if (p != null && p.isWhite != isWhite) {
                    //Проверка после сруба
                    if (board [x - 2, y - 2] == null)
							return true;
					}
				}

				//ппавый низ
				if (x <= 5 && y >= 2) {
					Piece p = board [x + 1, y - 1];
                // если шашка не того цвета
                if (p != null && p.isWhite != isWhite) {
                    //Проверка после сруба
                    if (board [x + 2, y - 2] == null)
							return true;
					}
				}
		
	}
		return false;
	}
	public bool ValidMove(Piece[,] board, int x1, int y1, int x2, int y2)
	{
		//движение поверх другой шашки
		if (board [x2, y2] != null)
			return false;

		int deltaMove = Mathf.Abs (x1 - x2);
		int deltaMoveY =y2 - y1;

		if (isWhite || isKing) 
		{
			if (deltaMove == 1) 
			{
				if (deltaMoveY == 1)
					return true;
			} 

			else if (deltaMove == 2) 
			{
				if (deltaMoveY == 2) 
				{
					Piece p = board [(x1 + x2) / 2, (y1 + y2) / 2];
					if (p != null && p.isWhite != isWhite)
						return true;
				}

			}
		}

		if (!isWhite || isKing) 
		{
			if (deltaMove == 1) 
			{
				if (deltaMoveY == -1)
					return true;
			} 

			else if (deltaMove == 2) 
			{
				if (deltaMoveY == -2) 
				{
					Piece p = board [(x1 + x2) / 2, (y1 + y2) / 2];
					if (p != null && p.isWhite != isWhite)
						return true;
				}

			}
		}

		return false;
	}

}
