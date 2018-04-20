using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2
{
    public class ChessBoard
    {
        // Variables
        int row;
        int column;
        int targetRow;
        int targetColumn;
        int turn;
        int countPossibleMoves = 0;
        int drawCounter = 0;
        int threeMovesCounter = 0;
        string[] boards = new string[100];
        SoldierBase[,] board = new SoldierBase[8, 8];

        // Getters and Setters
        public bool setDrawCounter(int drawCounter)
        {
            this.drawCounter = drawCounter;
            return true;
        }
        public int getDrawCounter()
        {
            return drawCounter;
        }
        public bool setRow(int row)
        {
            this.row = row;
            return true;
        }
        public bool setTurn(int turn)
        {
            if (turn < 0)
            {
                return false;
            }
            this.turn = turn;
            return true;
        }
        public int getTrun()
        {
            return turn;
        }
        public int getRow()
        {
            return row;
        }
        public bool setColumn(int column)
        {
            this.column = column;
            return true;
        }
        public int getColumn()
        {
            return column;
        }
        public bool setTargetColumn(int targetColumn)
        {
            this.targetColumn = targetColumn;
            return true;
        }
        public int getTargetColumn()
        {
            return targetColumn;
        }
        public bool setTargetRow(int targetRow)
        {
            this.targetRow = targetRow;
            return true;
        }
        public int getTargetRow()
        {
            return targetRow;
        }
        // get the soldier type
        public SoldierBase GetSoldierByPosition(Coords start)
        {
            return board[start.getY(), start.getX()];
        }
        // move soldier to the target position and change the last position to empty
        public void basicMove(Coords start, Coords end)
        {
            SoldierBase temp = board[start.getY(), start.getX()];
            board[start.getY(), start.getX()] = new EmptySoldier(" ", " ", false, start.getY(), start.getX());
            temp.setY(end.getY());
            temp.setX(end.getX());
            board[end.getY(), end.getX()] = temp;
            board[end.getY(), end.getX()].isMoved(true);

        }
        public void doCastlingMove(Coords start, Coords end)
        {
            //temp soldier for the king  to clear the move for the rook

            if (start.getX() < end.getX() && GetSoldierByPosition(start).getColor() == "W")
            {
                SoldierBase tempKing = board[start.getY(), start.getX()];
                board[start.getY(), start.getX()] = new EmptySoldier(" ", " ", false, start.getY(), start.getX());
                basicMove(new Coords(7, 7), new Coords(7, 5));
                tempKing.setY(start.getY());
                tempKing.setX(start.getX() + 2);
                board[start.getY(), start.getX() + 2] = tempKing;
            }
            else if (start.getX() < end.getX() && GetSoldierByPosition(start).getColor() == "B")
            {
                SoldierBase tempKing = board[start.getY(), start.getX()];
                board[start.getY(), start.getX()] = new EmptySoldier(" ", " ", false, start.getY(), start.getX());
                basicMove(new Coords(0, 7), new Coords(0, 5));
                tempKing.setY(start.getY());
                tempKing.setX(start.getX() + 2);
                board[start.getY(), start.getX() + 2] = tempKing;
            }
            else if (start.getX() > end.getX() && GetSoldierByPosition(start).getColor() == "W")
            {
                SoldierBase tempKing = board[start.getY(), start.getX()];
                board[start.getY(), start.getX()] = new EmptySoldier(" ", " ", false, start.getY(), start.getX());
                basicMove(new Coords(7, 0), new Coords(7, 3));
                tempKing.setY(start.getY());
                tempKing.setX(start.getX() - 2);
                board[start.getY(), start.getX() - 2] = tempKing;
            }
            else if (start.getX() > end.getX() && GetSoldierByPosition(start).getColor() == "B")
            {
                SoldierBase tempKing = board[start.getY(), start.getX()];
                board[start.getY(), start.getX()] = new EmptySoldier(" ", " ", false, start.getY(), start.getX());
                basicMove(new Coords(0, 0), new Coords(0, 3));
                tempKing.setY(start.getY());
                tempKing.setX(start.getX() - 2);
                board[end.getY(), start.getX() - 2] = tempKing;
            }
        }
        // init func
        public void initSoldiers()
        {

            for (int x = 0; x < 8; x++)
            {
                board[1, x] = new PawnPiece("P", "B", false, false, 1, x);
                board[6, x] = new PawnPiece("P", "W", false, false, 6, x);

            }

            board[7, 7] = new RookPiece("R", "W", false, 7, 7);
            board[7, 0] = new RookPiece("R", "W", false, 7, 0);
            board[0, 0] = new RookPiece("R", "B", false, 0, 0);
            board[0, 7] = new RookPiece("R", "B", false, 0, 7);
            board[7, 2] = new BishopPiece("B", "W", false, 7, 2);
            board[7, 5] = new BishopPiece("B", "W", false, 7, 5);
            board[0, 2] = new BishopPiece("B", "B", false, 0, 2);
            board[0, 5] = new BishopPiece("B", "B", false, 0, 5);
            board[7, 3] = new QueenPiece("Q", "W", false, 7, 3);
            board[0, 3] = new QueenPiece("Q", "B", false, 0, 3);
            board[7, 1] = new KnightPiece("N", "W", false, 7, 1);
            board[7, 6] = new KnightPiece("N", "W", false, 7, 6);
            board[0, 1] = new KnightPiece("N", "B", false, 0, 1);
            board[0, 6] = new KnightPiece("N", "B", false, 0, 6);
            board[7, 4] = new KingPiece("K", "W", false, 7, 4);
            board[0, 4] = new KingPiece("K", "B", false, 0, 4);
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (board[y, x] == null)
                    {
                        board[y, x] = new EmptySoldier(" ", " ", false, y, x);
                    }
                }
            }
        }
        //print func
        public void PrintBoard()
        {
            string chessBoardCreateX = "+----";
            string chessBoardCreateY = "|";
            string linePrefix = "   ";
            //numbers top line
            Console.Write(linePrefix + " ");
            Console.Write(" a    b    c    d    e    f    g    h");
            Console.WriteLine();
            // top line
            Console.Write(linePrefix);
            for (int i = 0; i < 8; i++)
            {

                Console.Write(chessBoardCreateX);
            }
            Console.WriteLine("+");
            //side numbers
            for (int y = 0; y < 8; y++)
            {
                Console.Write(" {0} ", y + 1);
                // inner lines
                Console.Write(chessBoardCreateY);
                for (int x = 0; x < 8; x++)
                {
                    Console.Write(" {0} {1}", board[y, x].getColor() + board[y, x].getType(), chessBoardCreateY);
                }

                // buttom line
                Console.WriteLine();
                Console.Write(linePrefix);
                for (int i = 0; i < 8; i++)
                {

                    Console.Write(chessBoardCreateX);
                }
                Console.WriteLine("+");

            }
            Console.Write(linePrefix);
            Console.WriteLine("  a    b    c    d    e    f    g    h");
        }
        // convert chars to numbers
        public int ConvertX(char X)
        {

            return X - 97;
        }
        public int ConvertY(char Y)
        {

            return Y - 49;
        }
        //if input between 0 to 7
        public bool ValidInput(Coords start, Coords end)
        {


            if (start.getY() >= 0 && start.getY() <= 7 &&
                start.getX() >= 0 && start.getX() <= 7 &&
                end.getY() >= 0 && end.getY() <= 7 &&
                end.getX() >= 0 && end.getX() <= 7)
            {
                row = start.getY();
                column = start.getX();
                targetRow = end.getY();
                targetColumn = end.getX();
                return true;
            }




            return false;
        }
        //Castling
        public bool validCastling(Coords start, Coords end)
        {
            if (GetSoldierByPosition(start).getType() == "K" && GetSoldierByPosition(start).getMoved() == false)
            {
                //2 spaces castling 
                if (start.getX() < end.getX())
                {
                    //clear pass? then move the rook

                    if (GetSoldierByPosition(new Coords(start.getY(), GetValidIndex(start.getX() + 1, false))).getType() == " " &&
                       GetSoldierByPosition(new Coords(start.getY(), GetValidIndex(start.getX() + 2, false))).getType() == " " &&
                       GetSoldierByPosition(new Coords(start.getY(), GetValidIndex(start.getX() + 3, false))).getType() == "R" &&
                       GetSoldierByPosition(new Coords(start.getY(), GetValidIndex(start.getX() + 3, false))).getMoved() == false &&
                       GetSoldierByPosition(new Coords(start.getY(), GetValidIndex(start.getX() + 2, false))) ==
                       GetSoldierByPosition(new Coords(end.getY(), end.getX())) &&
                       !(inCheck(FindKing())))

                    {
                        return true;
                    }
                }
                else
                {

                    //clear pass? then move the rook
                    if (GetSoldierByPosition(new Coords(start.getY(), GetValidIndex(start.getX() - 1, true))).getType() == " " &&
                       GetSoldierByPosition(new Coords(start.getY(), GetValidIndex(start.getX() - 2, true))).getType() == " " &&
                       GetSoldierByPosition(new Coords(start.getY(), GetValidIndex(start.getX() - 3, true))).getType() == " " &&
                       GetSoldierByPosition(new Coords(start.getY(), GetValidIndex(start.getX() - 4, true))).getType() == "R" &&
                       GetSoldierByPosition(new Coords(start.getY(), GetValidIndex(start.getX() - 4, true))).getMoved() == false &&
                       GetSoldierByPosition(new Coords(start.getY(), GetValidIndex(start.getX() - 2, true))) ==
                       GetSoldierByPosition(new Coords(end.getY(), end.getX())) &&
                       !(inCheck(FindKing())))
                    {

                        return true;
                    }
                }
            }

            return false;
        }

        private int GetValidIndex(int index, bool isMin)
        {
            if (isMin && index < 0)
            {
                return 0;
            }
            if (!isMin && index > 7)
            {
                return 7;
            }
            return index;


        }

        //finding king
        public Coords FindKing()
        {
            if ((WhiteTurn()))
            {

                if (GetSoldierByPosition(new Coords(7, 4)).getType() == "K")
                {
                    return new Coords(7, 4);
                }
                else
                {
                    for (int y = 7; y >= 0; y--)
                    {
                        for (int x = 0; x < 8; x++)
                        {
                            if (GetSoldierByPosition(new Coords(y, x)).getType() == "K")
                            {
                                return new Coords(y, x);
                            }
                        }
                    }
                    return new Coords(7, 4);
                }

            }
            else
            {
                if (GetSoldierByPosition(new Coords(0, 4)).getType() == "K")
                {
                    return new Coords(0, 4);
                }
                else
                {
                    for (int y = 0; y < 8; y++)
                    {
                        for (int x = 0; x < 8; x++)
                        {
                            if (GetSoldierByPosition(new Coords(y, x)).getType() == "K")
                            {
                                return new Coords(y, x);
                            }
                        }
                    }
                    return new Coords(0, 4);
                }
            }
        }
        //white turn or not
        public bool WhiteTurn()
        {
            if ((getTrun() % 2 == 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //there is check?
        public bool inCheck(Coords kingCoords)
        {
            foreach (SoldierBase piece in board)
            {

                Coords pieceCoords = new Coords(piece.getY(), piece.getX());
                if (piece.getColor() == "B" && WhiteTurn())
                {
                    if (piece.validMove(this, pieceCoords, kingCoords))
                    {
                        return true;
                    }
                }
                if (piece.getColor() == "W" && !(WhiteTurn()))
                {
                    if (piece.validMove(this, pieceCoords, kingCoords))
                    {
                        return true;
                    }
                }

            }
            return false;
        }
        //possible move to cancel check?
        public bool PossibleToCancelCheck(Coords start, Coords end)

        {
            bool movePosition = false;
            if (GetSoldierByPosition(start).getMoved())
            {
                movePosition = true;
            }
            else
            {
                movePosition = false;
            }
            SoldierBase tempStart;
            SoldierBase tempEnd;

            if (GetSoldierByPosition(start).validMove(this, start, end))
            {

                tempStart = (GetSoldierByPosition(start));
                tempEnd = (GetSoldierByPosition(end));
                basicMove(start, end);
                tempStart.setY(start.getY());
                tempStart.setX(start.getX());
                if (!(inCheck(FindKing())))
                {

                    board[start.getY(), start.getX()] = tempStart;
                    board[end.getY(), end.getX()] = tempEnd;
                    board[start.getY(), start.getX()].isMoved(movePosition);
                    return true;
                }
                else
                {
                    board[start.getY(), start.getX()] = tempStart;
                    board[end.getY(), end.getX()] = tempEnd;
                    board[start.getY(), start.getX()].isMoved(movePosition);
                }
            }
            return false;


        }
        public int numberOfPossibleMoves(Coords kingCoords)
        {
            countPossibleMoves = 0;
            foreach (SoldierBase piece in board)
            {
                Coords start = new Coords(piece.getY(), piece.getX());
                foreach (SoldierBase pieceTarget in board)
                {

                    Coords end = new Coords(pieceTarget.getY(), pieceTarget.getX());
                    if (piece.getColor() == "W" && WhiteTurn())
                    {
                        if (PossibleToCancelCheck(start, end))
                        {

                            countPossibleMoves++;
                        }
                    }
                    if (piece.getColor() == "B" && !(WhiteTurn()))
                    {
                        if (PossibleToCancelCheck(start, end))
                        {

                            countPossibleMoves++;
                        }
                    }
                }
            }
            return countPossibleMoves;
        }
        public bool checkMate(Coords kingCoords)
        {
            if (inCheck(kingCoords) && numberOfPossibleMoves(kingCoords) == 0)
            {
                return true;
            }
            return false;
        }
        public bool isDraw(Coords KingCoords)
        {
            if (!(inCheck(KingCoords)) && numberOfPossibleMoves(KingCoords) == 0)
            {
                return true;
            }
            if (drawCounter == 50)
            {
                return true;
            }
            if (threeMovesRepetition())
            {
                return true;
            }
            return false;
        }
        public bool threeMovesRepetition()
        {
            string boardToString = "";
            foreach (SoldierBase index in board)
            {
                boardToString += index;
            }
            boards[turn] = boardToString;
            for (int i = 0; i < getTrun(); i++)
            {
                if (boards[turn] == boards[i])
                {
                    threeMovesCounter++;
                }
            }
            if (threeMovesCounter > 2)
            {
                return true;
            }
            threeMovesCounter = 0;
            return false;
        }
        public void nextTurn()
        {
            Console.Clear();
            PrintBoard();
            setTurn(getTrun() + 1);
            setDrawCounter(getDrawCounter() + 1);
            enPassantValidForOneTurnOnly();
        }
        public void removeObj(Coords start)
        {
            board[start.getY(), start.getX()] = new EmptySoldier(" ", " ", false, start.getY(), start.getX());
        }
        public bool validPawnPromotion(Coords start, Coords end)
        {
            if (WhiteTurn() && GetSoldierByPosition(start).getType() == "P" && end.getY() == 0)
            {
                return true;

            }
            if (!WhiteTurn() && GetSoldierByPosition(start).getType() == "P" && end.getY() == 7)
            {
                return true;
            }
            return false;
        }
        public void doPromotion(Coords start, Coords end)
        {
            removeObj(start);
            board[end.getY(), end.getX()] = new QueenPiece("Q", "W", false, start.getY(), start.getX());
        }
        public bool validEnPassant(Coords start, Coords end)
        {
            int direction;
            if (WhiteTurn())
            {
                direction = -1;
            }
            else
            {
                direction = 1;
            }
            if (((GetValidIndex(start.getX() + 1, false) == end.getX() || GetValidIndex(start.getX() - 1, true) == end.getX()) &&
                start.getY() + direction == end.getY() &&
                GetSoldierByPosition(end).getColor() == " "))
            {


                if (WhiteTurn() && start.getY() == 3 &&
                    GetSoldierByPosition(start).getType() == "P" &&
                    GetSoldierByPosition(start).getColor() == "W" &&
                    board[3, end.getX()].getType() == "P" &&
                    board[3, end.getX()].getColor() == "B")
                {
                    if (board[end.getY() - direction, end.getX()] is PawnPiece &&
                        ((PawnPiece)board[end.getY() - direction, end.getX()]).getMovedTwoSteps() == true)
                    {
                        return true;
                    }

                }
                if (!WhiteTurn() && start.getY() == 4 &&
                   GetSoldierByPosition(start).getType() == "P" &&
                   GetSoldierByPosition(start).getColor() == "W" &&

                   board[4, end.getX()].getType() == "P" &&
                   board[4, end.getX()].getColor() == "B")
                {
                    if (board[end.getY() - direction, end.getX()] is PawnPiece &&
                        ((PawnPiece)board[end.getY() - direction, end.getX()]).getMovedTwoSteps() == true)
                    {
                        return true;
                    }

                }
            }
            return false;
        }
        public void doEnPassant(Coords start, Coords end)
        {
            basicMove(start, end);
            if (WhiteTurn())
            {
                removeObj(new Coords(end.getY() + 1, end.getX()));
            }
            else
            {
                removeObj(new Coords(end.getY() - 1, end.getX()));
            }

        }
        public void enPassantValidForOneTurnOnly()
        {
            foreach (SoldierBase piece in board)
            {
                if (WhiteTurn()&&piece.getType()=="P"&&piece.getColor()=="W")
                {
                    ((PawnPiece)piece).isMovedTwoSteps(false);
                }
                if (!WhiteTurn() && piece.getType() == "P" && piece.getColor() == "B")
                {
                    ((PawnPiece)piece).isMovedTwoSteps(false);
                }
            }
        }
    }
}

