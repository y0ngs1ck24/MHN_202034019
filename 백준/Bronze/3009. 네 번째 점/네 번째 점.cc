#include <iostream>
using namespace std;

int main()
{
	int x, y;
	int xx[4] = { 0 };
	int yy[4] = { 0 };
	
	int countX = 0;
	int countY = 0;
	
	for (int i = 0; i < 3; i++)
	{
		cin >> x >> y;
		xx[i] = x;
		yy[i] = y;
	}

	int maxX = xx[0], minX = xx[0];
	int maxY = yy[0], minY = yy[0];

	for (int i = 1; i < 3; i++)
	{
		maxX = max(maxX, xx[i]);
		minX = min(minX, xx[i]);
		maxY = max(maxY, yy[i]);
		minY = min(minY, yy[i]);
	}

	for (int i = 0; i < 3; i++)
	{
		if (xx[i] == maxX) 
		{
			countX++;
			if (countX > 1)
			{
				maxX = minX;
			}
		}
		if (yy[i] == maxY)
		{
			countY++;
			if (countY > 1)
			{
				maxY = minY;
			}
		}
	}

	cout << maxX << " " << maxY << endl;
}