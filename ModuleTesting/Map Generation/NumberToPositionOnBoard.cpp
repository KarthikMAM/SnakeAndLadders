#include<iostream>

using namespace std;

int main()
{
    int boardScheme[101];
    for(int i=0; i<100; i++)
    {
        if ((i / 10) % 2 == 0)
        {
            boardScheme[i+1] = ((9 - i / 10) * 10) + (i % 10);
        }
        else
        {
            boardScheme[i + 1] = ((9 - i / 10) * 10) + (9 - i % 10);
        }
    }
    for(int i=1; i<=100; i++)
    {
        cout<<"  "<<i<<"->"<<boardScheme[i];
        if(i % 10 == 0)
        {
            cout<<"\n\n";
        }
    }
    return 0;
}
