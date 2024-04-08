#include <iostream>
using namespace std;

int main()
{
	int arr[9][9] = { 0, 0 };
	int max = -1;
	int max1, max2 = 0;

	for (int i = 0; i < 9; i++)
	{
		for (int j = 0; j < 9; j++)
		{
			cin >> arr[i][j];
			if (arr[i][j] > max)
			{
				max = arr[i][j];
				max1 = i;
				max2 = j;
			}
		}
	}
	cout << max << endl;
	cout << max1 + 1 << " " << max2 + 1 << endl;
}