using UnityEngine;
using System.Collections;

public class TestTicTacToeLogic : UUnitTestCase {

	int xPlacedAtX, xPlacedAtY;
	TicTacToeLogic.PlaceMarker mockPlaceX;
	int oPlacedAtX, oPlacedAtY;
	TicTacToeLogic.PlaceMarker mockPlaceO;
	string endGameResult;
	TicTacToeLogic.EndGame mockEndGame;
	TicTacToeLogic underTest;
	
	protected override void SetUp() {
		mockEndGame = (result) => {endGameResult = result;};
		mockPlaceO = (x, y) => {oPlacedAtX = x; oPlacedAtY = y;};
		mockPlaceX = (x, y) => {xPlacedAtX = x; xPlacedAtY = y;};
		
		underTest = new TicTacToeLogic(mockPlaceX, mockPlaceO, mockEndGame);
	}
	
	[UUnitTest]
	public void shouldCallAnimateXAtFirstLocationIPlaceAt() {
		underTest.Click(0,1);
		
		UUnitAssert.Equals(0, xPlacedAtX);
		UUnitAssert.Equals(1, xPlacedAtY);
	}
	
	
	[UUnitTest]
	public void secondClickShouldCallPlaceO() {
		underTest.Click(2,2);
		
		UUnitAssert.Equals(2, xPlacedAtX);
		UUnitAssert.Equals(2, xPlacedAtY);
		
		underTest.Click(1,2);
		
		UUnitAssert.Equals(1, oPlacedAtX);
		UUnitAssert.Equals(2, oPlacedAtY);
	}
	
		
	[UUnitTest]
	public void shouldNotBeAbleToClickOnClickedSpace() {
		underTest.Click(2,2);
		underTest.Click(1,2);
		underTest.Click(1,2);
		
		UUnitAssert.Equals(1, oPlacedAtX);
		UUnitAssert.Equals(2, oPlacedAtY);
		UUnitAssert.Equals(2, xPlacedAtX);
		UUnitAssert.Equals(2, xPlacedAtY);
	}
	
	[UUnitTest]
	public void gameShouldEndIfXGetsThreeOnLeftSide() {
		underTest.Click(0,0);
		underTest.Click(1,2);
		underTest.Click(0,1);
		underTest.Click(1,1);
		underTest.Click(0,2);
		
		UUnitAssert.Equals("X Wins", endGameResult);
	}
	
		
	[UUnitTest]
	public void gameShouldEndIfXGetsThreeOnRightSide() {
		underTest.Click(2,0);
		underTest.Click(1,2);
		underTest.Click(2,1);
		underTest.Click(1,1);
		underTest.Click(2,2);
		
		UUnitAssert.Equals("X Wins", endGameResult);
	}
		
	[UUnitTest]
	public void gameShouldEndIfXGetsThreeVerticalInMiddle() {
		underTest.Click(1,0);
		underTest.Click(2,2);
		underTest.Click(1,1);
		underTest.Click(2,1);
		underTest.Click(1,2);
		
		UUnitAssert.Equals("X Wins", endGameResult);
	}
	
		
	[UUnitTest]
	public void gameShouldEndIfOGetsThreeVerticalInMiddle() {
		underTest.Click(2,0);
		underTest.Click(1,2);
		underTest.Click(2,1);
		underTest.Click(1,1);
		underTest.Click(0,2);
		underTest.Click(1,0);
		
		UUnitAssert.Equals("O Wins", endGameResult);
	}
			
	[UUnitTest]
	public void gameShouldNotAllowAnyMoreMovesAfterGameEnd() {
		underTest.Click(1,0);
		underTest.Click(2,2);
		underTest.Click(1,1);
		underTest.Click(2,1);
		underTest.Click(1,2);
		underTest.Click(2,0);
		
		UUnitAssert.Equals(2, oPlacedAtX);
		UUnitAssert.Equals(1, oPlacedAtY);
	}
	
	[UUnitTest]
	public void gameShouldEndIfOGetsThreeHorizontalInMiddle() {
		underTest.Click(2,0);
		underTest.Click(1,1);
		underTest.Click(0,0);
		underTest.Click(2,1);
		underTest.Click(0,2);
		underTest.Click(0,1);
		
		UUnitAssert.Equals("O Wins", endGameResult);
	}
	
	[UUnitTest]
	public void gameShouldEndIfXGetsThreeHorizontalInTop() {
		underTest.Click(0,0);
		underTest.Click(1,1);
		underTest.Click(1,0);
		underTest.Click(2,1);
		underTest.Click(2,0);
		
		UUnitAssert.Equals("X Wins", endGameResult);
	}
	
	[UUnitTest]
	public void gameShouldEndIfXGetsThreeHorizontalOnBottom() {
		underTest.Click(0,2);
		underTest.Click(1,1);
		underTest.Click(1,2);
		underTest.Click(2,1);
		underTest.Click(2,2);
		
		UUnitAssert.Equals("X Wins", endGameResult);
	}
	
	[UUnitTest]
	public void gameShouldEndIfXGetsThreeDiagonal() {
		underTest.Click(0,0);
		underTest.Click(1,0);
		underTest.Click(1,1);
		underTest.Click(2,1);
		underTest.Click(2,2);
		
		UUnitAssert.Equals("X Wins", endGameResult);
	}
	
	[UUnitTest]
	public void gameShouldEndIfXGetsThreeBackslashDiagonal() {
		underTest.Click(0,2);
		underTest.Click(1,0);
		underTest.Click(1,1);
		underTest.Click(2,1);
		underTest.Click(2,0);
		
		UUnitAssert.Equals("X Wins", endGameResult);
	}
	
	[UUnitTest]
	public void gameShouldDrawIfBoardFilledWithNoMovesLeft() {
		underTest.Click(0,0);
		underTest.Click(0,1);
		underTest.Click(0,2);
		underTest.Click(2,0);
		underTest.Click(2,1);
		underTest.Click(2,2);
		underTest.Click(1,0);
		underTest.Click(1,1);
		underTest.Click(1,2);
		
		UUnitAssert.Equals("Draw", endGameResult);
	}
}
