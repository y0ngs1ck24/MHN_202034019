#include <iostream>
using namespace std;

int main()
{
	int t, c;
	cin >> t;

	int D = 0;
	int dd = 0;
	int N = 0;
	int nn = 0;
	int P = 0;
	// Q = 25  D = 10  N = 5  P = 1
	for (int i = 0; i < t; i++)
	{
		cin >> c; //124

		int Q = c / 25; // 124 / 25 = 4.96
		int q = c - (Q * 25); // 124 - 100 == 24 ////////////9

		if (q < 10)
		{
			D = 0;
			dd = q; 
		}
		else
		{
			D = q / 10; // 24 / 10 == 2
			dd = q - (D * 10); // 24 - 20 == 4
		}

		if (dd < 5)
		{
			N = 0;
			P = dd / 1; // 4 / 1 == 4  
		}
		else
		{
			N = dd / 5; // 9 / 5 == 1
			nn = dd - (N * 5); // 9 - 5 = 4
			P = nn;
		}
		cout << Q << " " << D << " " << N << " " << P << endl;
	}
}