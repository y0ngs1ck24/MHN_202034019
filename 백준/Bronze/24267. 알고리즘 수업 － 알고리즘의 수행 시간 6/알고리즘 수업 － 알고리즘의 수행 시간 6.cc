#include <iostream>
using namespace std;


int main()
{
    long long n; // 7
    cin >> n;
    long long a = 0;
    for (long long i = 0; i < n - 2; i++) // 1 ~ 6 
    {
        for (long long j = 0; j <= i; j++)
        {
            a += ((n - 2) - i);
        }
    }
    cout << a << endl;
    cout << 3 << endl;
}
