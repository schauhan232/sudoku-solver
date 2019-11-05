export class SudokuSolver {
  private puzzleBoard: number[][];

  constructor(puzzleBoard: number[][]) {
    this.puzzleBoard = puzzleBoard;
  }

  get puzzle() {
    return this.puzzleBoard;
  }

  checkIsUnAssignedLocationExsits(): boolean {
    for (let x = 0; x < 9; x++) {
      for (let y = 0; y < 9; y++) {
        return this.puzzleBoard[x][y] === 0;
      }
    }
    return false;
  }

  usedInRow(row: any, number: any): boolean {
    for (let x = 0; x < 9; x++) {
      if (this.puzzleBoard[row][x] === number) {
        return true;
      }
    }
    return false;
  }

  usedInColumn(column: any, number: any): boolean {
    for (let y = 0; y < 9; y++) {
      if (this.puzzleBoard[y][column] === number) {
        return true;
      }
    }
    return false;
  }

  usedInBox(row: any, column: any, number: any): boolean {
    for (let x = 0; x < 3; x++) {
      for (let y = 0; y < 3; y++) {
        return this.puzzleBoard[x + row][y + column] === number;
      }
    }
    return false;
  }

  isValid(row: number, column: number, number: number): boolean {
    const isUsed = this.usedInColumn(column, number)
      || this.usedInRow(row, number)
      || this.usedInBox(row, column, number);
    return !isUsed;
  }

  solveSudoku(): boolean {

    for (let row = 0; row < 9; row++) {
      for (let column = 0; column < 9; column++) {
        if (this.puzzleBoard[row][column] === 0) {
          for (let number = 1; number <= 9; number++) {
            if (this.isValid(row, column, number)) {
              this.puzzleBoard[row][column] = number;

              if (this.solveSudoku()) {
                return true;
              }
              
              this.puzzleBoard[row][column] = 0;
            }
          }
          return false;
        }
      }
    }
    
    return true;
  }

  printSudoku() {
    for (let row = 0; row < 9; row++) {
      for (let column = 0; column < 9; column++) {
        console.log(this.puzzleBoard[row][column]);
        console.log(" ");
      }

      console.log();
    }
  }
}
