#include <iostream>
using namespace std;

string change(int n, int b)
{
    string result = " ";
    while (n > 0)
    {
        int fuck = n % b;
        char digit;
        if (fuck < 10)
        {
            digit = fuck + '0';
        }
        else
        {
            digit = fuck + 'A' - 10 ;
        }
        result = digit + result;
        n /= b;
    }
    return result;
}
int main() {
    int n, b;
    cin >> n >> b;

    string result = change(n, b);
    cout << result << endl;
}
