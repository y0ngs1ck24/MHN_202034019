#include <iostream>
using namespace std;

int main()
{
    int x, y, w, h;
    cin >> x >> y >> w >> h;

    int minDist = min(min(x, w - x), min(y, h - y));
    cout << minDist << endl;

    return 0;
}
