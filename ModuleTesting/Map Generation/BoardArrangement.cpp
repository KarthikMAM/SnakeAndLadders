#include<iostream>

using namespace std;

int main()
{
    int boardMap[10][10];
    for (int i = 9; i >= 0; i--)
    {
        for (int j = 0; j < 10; j++)
        {
            boardMap[i][j] = (9 - i) * 10 + (j + 1);
        }
        i--;
        for (int j = 9; j >= 0; j--)
        {
            boardMap[i][j] = (9 - i) * 10 + (9 - j + 1);
        }
    }

    //Assign the ladder positions
    boardMap[2][0] = 100;
    boardMap[2][9] = 91;
    boardMap[4][9] = 67;
    boardMap[7][0] = 42;
    boardMap[7][7] = 84;
    boardMap[9][0] = 38;
    boardMap[9][3] = 14;
    boardMap[9][8] = 31;

    //Assign the snake positions
    boardMap[0][2] = 79;
    boardMap[0][5] = 75;
    boardMap[0][7] = 73;
    boardMap[1][6] = 24;
    boardMap[3][1] = 19;
    boardMap[3][3] = 60;
    boardMap[4][6] = 34;
    boardMap[8][3] = 7;

    for(int i=0; i<10; i++)
    {
        cout<<"\n\n";
        for(int j=0; j<10; j++)
        {
            cout<<"  "<<boardMap[i][j];
        }
    }
    return 0;
}
