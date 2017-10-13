using System;
using System.Collections.Generic;
namespace mazeGame {

  class Program {
    //returns true if you can move from current coordonate to next 
    static public bool canMove (int currentRoomX, int currentRoomY, int nextRoomX, int nextRoomY) {
      double canMove = currentRoomY * 10 + currentRoomX;
      double canMove2 = nextRoomY * 10 + nextRoomX;
      double result = Math.Atan (canMove * canMove2);
      if (result >= 0.3) {
        return true;
      } else {
        return false;
      }
    }

    public class cardinalDirections {
      public static int currentRoomX = 1;
      public static int currentRoomY = 1;
      public static bool canMoveNorth = false;
      public static bool canMoveWest = false;
      public static bool canMoveEast = false;
      public static bool canMoveSouth = false;
      public static string input;
      public static bool gameWon = false;

      public virtual void move () {

      }

    }
    public static void checkBoundary () {
      //eliminating boundary positions
      if (cardinalDirections.currentRoomY == 1) {
        cardinalDirections.canMoveNorth = false;
      }
      if (cardinalDirections.currentRoomX == 1) {
        cardinalDirections.canMoveWest = false;
      }
      if (cardinalDirections.currentRoomX == 10) {
        cardinalDirections.canMoveEast = false;
      }
      if (cardinalDirections.currentRoomY == 10) {
        cardinalDirections.canMoveSouth = false;
      }
    }
    static public bool win (int currentRoomX, int currentRoomY) {
      //win condition 
      if (currentRoomX == 10 && currentRoomY == 10) {
        return true;
      } else {
        return false;
      }
    }

    class North : cardinalDirections {
      public override void move () {
        canMoveNorth = canMove (currentRoomX, currentRoomY, currentRoomX, currentRoomY - 1);
        checkBoundary ();
        if (canMoveNorth == true) {
          Console.WriteLine ("You can go North");
          base.move ();
        }
      }
    }

    class West : cardinalDirections {
      public override void move () {
        canMoveWest = canMove (currentRoomX, currentRoomY, currentRoomX - 1, currentRoomY);
        checkBoundary ();
        if (canMoveWest == true) {
          Console.WriteLine ("You can go West");
          base.move ();
        }
      }
    }

    class East : cardinalDirections {
      public override void move () {
        canMoveEast = canMove (currentRoomX, currentRoomY, currentRoomX + 1, currentRoomY);
        checkBoundary ();
        if (canMoveEast == true) {
          Console.WriteLine ("You can go East");
          base.move ();
        }
      }
    }

    class South : cardinalDirections {
      public override void move () {
        canMoveSouth = canMove (currentRoomX, currentRoomY, currentRoomX, currentRoomY + 1);
        checkBoundary ();
        if (canMoveSouth == true) {
          Console.WriteLine ("You can go South");
          base.move ();
        }
      }
    }
    static void Main (string[] args) {
      Console.WriteLine ("Enter North or West or East Or South");

      for (int currentTurn = 1; currentTurn <= 30; currentTurn++) {

        Console.WriteLine ("Current Room X {0}", cardinalDirections.currentRoomX);
        Console.WriteLine ("Current Room Y {0}", cardinalDirections.currentRoomY);

        var directions = new List<cardinalDirections> {
          new North (),
          new West (),
          new East (),
          new South ()
        };
        foreach (var direction in directions) {
          direction.move ();
        }
        cardinalDirections.input = Console.ReadLine ();

        //Checking the users input and seeing if they can move to that position
        if (cardinalDirections.input == "North" && cardinalDirections.canMoveNorth == true) {
          cardinalDirections.currentRoomY -= 1;
        }
        if (cardinalDirections.input == "West" && cardinalDirections.canMoveWest == true) {
          cardinalDirections.currentRoomX -= 1;
        }
        if (cardinalDirections.input == "East" && cardinalDirections.canMoveEast == true) {
          cardinalDirections.currentRoomX += 1;
        }
        if (cardinalDirections.input == "South" && cardinalDirections.canMoveSouth == true) {
          cardinalDirections.currentRoomY += 1;
        }

        cardinalDirections.gameWon = win (cardinalDirections.currentRoomX, cardinalDirections.currentRoomY);

        if (cardinalDirections.gameWon == true) {
          Console.WriteLine ("You Won");
          break;
        } else if (currentTurn == 30) {
          Console.WriteLine ("Sadly you died of dehydration");
          break;
        }
      }

    }
  }
}