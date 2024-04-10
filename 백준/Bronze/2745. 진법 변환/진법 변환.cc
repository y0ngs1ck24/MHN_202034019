#include<iostream>
using namespace std;

int v(int byun, int sibal)
{
	int a = 1;
	for (int i = 0; i < sibal; i++)
	{
		a *= byun;
	}
	return a;
}

int main()
{
	string n;
	int b;
	cin >> n >> b;
	int answer = 0;
	int sum;
	for (int i = 0; i < n.length(); i++)
	{
		if (n[i] >= 65 && n[i] <= 90)
		{
			n[i] = n[i] - 'A' + 10;
		}
		else
		{
			n[i] = n[i] - '0';
		}
		sum = n[i] * v(b, n.length() - i - 1);
		answer += sum;
	}
	cout << answer;
}

