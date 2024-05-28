#include <iostream>
using namespace std;

int main()
{
    int n;
    cin >> n;

    int count = 0; // 필요한 봉지의 개수를 저장할 변수

    // n이 5의 배수가 될 때까지 3씩 빼주면서 반복
    while (n % 5 != 0 && n >= 0)
    {
        n -= 3;
        count++;
    }

    // n이 음수가 되었거나, 5의 배수인 경우
    if (n < 0)
    {
        cout << -1 << endl; // 봉지로 정확히 나눌 수 없는 경우
    }
    else
    {
        count += n / 5; // 5의 배수인 부분을 봉지로 나누고, 봉지 개수 추가
        cout << count << endl;
    }

    return 0;
}

