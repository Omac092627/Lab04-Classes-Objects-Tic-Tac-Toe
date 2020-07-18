using System;
using Xunit;
using static Lab04_TicTacToe.Program;
using Lab04_TicTacToe.Classes;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void FindHorizontalWinner()
        {
            //Arrange
            Board board = new Board();
            Player p1 = new Player();
            Player p2 = new Player();
            Game game = new Game(p1, p2);
            game.Board = board;

            //Act
            board.GameBoard[0, 0] = "X";
            board.GameBoard[0, 1] = "X";
            board.GameBoard[0, 2] = "X";

            bool answer = game.CheckForWinner(board);
            Assert.True(answer);

        }
        [Fact]
        public void FindVerticalWinner()
        {
            //Arrange
            Board board = new Board();
            Player p1 = new Player();
            Player p2 = new Player();
            Game game = new Game(p1, p2);
            game.Board = board;

            //Act
            board.GameBoard[0, 0] = "X";
            board.GameBoard[1, 0] = "X";
            board.GameBoard[2, 0] = "X";

            bool answer = game.CheckForWinner(board);
            Assert.True(answer);

        }

        [Fact]
        public void FindDiagonalWinner()
        {
            //Arrange
            Board board = new Board();
            Player p1 = new Player();
            Player p2 = new Player();
            Game game = new Game(p1, p2);
            game.Board = board;

            //Act
            board.GameBoard[0, 0] = "O";
            board.GameBoard[1, 1] = "O";
            board.GameBoard[2, 2] = "O";

            bool answer = game.CheckForWinner(board);
            Assert.True(answer);

        }

        [Fact]
        public void DoesPlayerSwitch()
        {
            Board board = new Board();
            Player p1 = new Player();
            p1.IsTurn = true;
            Player p2 = new Player();
            p2.IsTurn = false;
            Game game = new Game(p1, p2);
            game.Board = board;



            game.SwitchPlayer();
            bool answer = p2.IsTurn;
            Assert.True(answer);
        }


        [Fact]
        public void PositionIsIndexPosition()
        {
            Board board = new Board();
            Player p1 = new Player();
            p1.Marker = "X";
            p1.IsTurn = true;
            Player p2 = new Player();
            p1.Marker = "O";
            p2.IsTurn = false;

            Game game = new Game(p1, p2);
            game.Board = board;

            Position test = Player.PositionForNumber(3);

            Assert.Equal(0, test.Row);
            Assert.Equal(2, test.Column);
        }

        [Fact]
        public void NoWinner()
        {
            //arrange 
            Board board = new Board();
            Player p1 = new Player();
            Player p2 = new Player();
            Game game = new Game(p1, p2);

            //Act
            string[,] testBoard = new string[,]
            {
                {"X", "X", "O" },
                {"X", "X", "O" },
                {"O", "O", "X" }

            };

            board.GameBoard = testBoard;
            game.Board = board;

            bool answer = game.CheckForWinner(board);
            Assert.False(answer);
        }
    }
}
