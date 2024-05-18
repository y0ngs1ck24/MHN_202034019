#include <iostream>
using namespace std;


int main()
{
    long long n; 
    long long a = 0;
    cin >> n; 
    for(long long i = 1; i < n; i++) 
    {
        a += (n - i);
    }

    cout << a << endl;
    cout << 2 << endl;
}
