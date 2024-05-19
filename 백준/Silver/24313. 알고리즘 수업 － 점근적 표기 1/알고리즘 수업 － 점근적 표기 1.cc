#include <iostream>
using namespace std;

int main()
{
	int a1, a0;
	cin >> a1 >> a0;

	int c;
	cin >> c;

	int n0;
	cin >> n0;


	int num = (a1 * n0) + a0;

	int num2 = c * n0;

	if (num <= num2 && a1 <= c)
	{
		cout << 1 << endl;
	}
	else
	{
		cout << 0 << endl;
	}

	
}