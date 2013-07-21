using UnityEngine;
using System.Collections;

public class TicTacToeLogic {

	public delegate void PlaceMarker(int x, int y);
	public delegate void EndGame(string result);
	
	private string[,] boardState;
	private PlaceMarker placeXMarker;
	private PlaceMarker placeOMarker;
	private EndGame endGameListener;
	private bool placeXNext;
	private bool gameOver;
	
	public TicTacToeLogic(PlaceMarker xMarker, PlaceMarker oMarker, EndGame endGame) {
		placeXMarker = xMarker;
		placeOMarker = oMarker;
		placeXNext = true;
		boardState = new string[3,3];
		endGameListener = endGame;
		gameOver = false;
	}
	
	public void Click(int x, int y) {
		if(boardState[x,y] != null || gameOver) {
			return;
		}
		if(placeXNext) {
			boardState[x,y] = "X";
			placeXMarker(x,y);
		} else {
			boardState[x,y] = "O";
			placeOMarker(x,y);
		}
		placeXNext = !placeXNext;
		
		checkForGameEnd();
	}
	
	private void checkForGameEnd() {
		CheckPieceWins ("X");
		CheckPieceWins ("O");
		if(IsBoardDraw ()) {
			gameOver = true;
			endGameListener("Draw");
		}
	}

	bool IsBoardDraw ()
	{
		foreach(string place in boardState) {
			if(place == null) {
				return false;
			}
		}
		return true;
	}
	
	void CheckPieceWins (string piece)
	{
		int[,,] possibleMatches = {
			{{0,0}, {0,1}, {0,2}},
			{{1,0}, {1,1}, {1,2}},
			{{2,0}, {2,1}, {2,2}},
			{{0,0}, {1,0}, {2,0}},
			{{0,1}, {1,1}, {2,1}},
			{{0,2}, {1,2}, {2,2}},
			{{0,0}, {1,1}, {2,2}},
			{{0,2}, {1,1}, {2,0}}
		};

		for(int x = 0; x < possibleMatches.GetLength(0); x ++) {
			if((boardState[possibleMatches[x,0,0], possibleMatches[x,0,1]] == piece) &&
				(boardState[possibleMatches[x,1,0], possibleMatches[x,1,1]] == piece) &&
				(boardState[possibleMatches[x,2,0], possibleMatches[x,2,1]] == piece)) {
				gameOver = true;
				endGameListener(piece + " Wins");
			}
		}
	}
}
