#include <iostream>
#include <vector>
using namespace std;

int main()
{
    int n, m;
    cin >> n >> m;
    int num = 0;
    int sum = 0;
    int maxSum = 0;

    vector<int> vec(n);

    for (int i = 0; i < n; i++)
    {
        cin >> num;
        vec[i] = num;
    }

    for (int i = 0; i < n; i++)
    {
        for (int j = i + 1; j < n; j++)
        {
            for (int k = j + 1; k < n; k++)
            {
                sum = vec[i] + vec[j] + vec[k];
                if (sum > maxSum && sum <= m)
                {
                    maxSum = sum;
                }
            }
        }
    }
    cout << maxSum << endl;
}
