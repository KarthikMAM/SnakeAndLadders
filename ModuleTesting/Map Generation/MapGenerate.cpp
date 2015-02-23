#include<iostream>
#include<map>

using namespace std;

int boardMap[10][10];

void GenerateBoard()
{
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
}

int main()
{
    cout<<"\n\n\tINSTRUCTIONS : ";
    cout<<"\n\n\t\t1. ENTER THE START->END POSITION FOR BOTH THE SNAKES AND LADDERS ";
    cout<<"\n\t\t2. ENTER 0 0 TO EXIT\n\n\n";

    multimap<int, int>BoardSchema;
    int Start, End;

    do
    {
        cin>>Start>>End;

        BoardSchema.insert(pair<int, int>(Start-1, End));

        if(Start == 0 || End == 0)
        {
            break;
        }
    }while(true);

    for(map<int, int>::iterator i = --BoardSchema.end(); i != BoardSchema.begin(); i--)
    {
        cout<<"\n\t\t"<<9 - (i->first / 10)<<" , ";
        if((i->first / 10) % 2 == 0)
        {
            cout<<(i->first % 10)<<" ---> "<<i->second;
        }
        else
        {
            cout<<9 - (i->first % 10)<<" ---> "<<i->second;
        }
    }
    return 0;
}
