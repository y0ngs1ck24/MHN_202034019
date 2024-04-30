#include <iostream>
using namespace std;
int main() {
    int A, B, V;
    int C;
    cin >> A >> B >> V;

    if (A >= V) C = 1;

    else {
        V -= A;
        if (V % (A - B)) C = V / (A - B) + 2;
        else C = V / (A - B) + 1;
    }
    cout << C;
}