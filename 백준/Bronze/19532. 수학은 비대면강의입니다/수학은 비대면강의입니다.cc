#include <iostream>
using namespace std;

int main()
{
	int a, b, c, d, e, f;
	cin >> a >> b >> c >> d >> e >> f;

	int x = (f * b - c * e) / (d * b - a * e);
	int y = (f * a - c * d) / (e * a - b * d);
	
	cout << x << " " << y << endl;
}