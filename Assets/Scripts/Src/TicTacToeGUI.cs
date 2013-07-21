using UnityEngine;
using System.Collections;

public class TicTacToeGUI : MonoBehaviour {
	
	private TicTacToeLogic logic;
	private string[,] values;
	private string endString;
	
	void OnGUI() {
		if(endString != null) {
			GUI.TextField(new Rect(50, 160, 80, 20), endString, 25);
		}
		
		for(int x=0; x < 3; x++) {
			for(int y = 0; y < 3; y++) {
				if (GUI.Button(new Rect(x * 50, y * 50, 50,50), values[x, y])) {
					logic.Click(x,y);
				}
			}
		}
		
	}
	
	// Use this for initialization
	void Start () {
		values = new string[3,3];
		
		TicTacToeLogic.PlaceMarker placeX = (x, y) => {values[x, y] = "X";};
		TicTacToeLogic.PlaceMarker placeO = (x, y) => {values[x, y] = "O";};
		TicTacToeLogic.EndGame endGameListener= (result) => {endString = result;};
		
		logic = new TicTacToeLogic(placeX, placeO, endGameListener);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
