#include <iostream>
#include <vector>;
using namespace std;

int main()
{
	int a, b;
	cin >> a >> b;

	vector<vector<int>> vec(a, vector<int>(b));
	vector<vector<int>> arr(a, vector<int>(b));

	for (int i = 0; i < a; i++)
	{
		for (int j = 0; j < b; j++)
		{
			cin >> vec[i][j];
		}
	}

	for (int i = 0; i < a; i++)
	{
		for (int j = 0; j < b; j++)
		{
			cin >> arr[i][j];
		}
	}

	for (int i = 0; i < a; i++)
	{
		for (int j = 0; j < b; j++)
		{
			cout << vec[i][j] + arr[i][j] << " ";
		}
		cout << endl;
	}
}