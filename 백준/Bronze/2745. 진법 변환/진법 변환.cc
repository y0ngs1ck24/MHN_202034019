#include <iostream>
#include <string>
using namespace std;

// 거듭제곱 함수 구현
int power(int base, int exponent) {
    int result = 1;
    for (int i = 0; i < exponent; ++i) {
        result *= base;
    }
    return result;
}

int main() {
    string n;
    int b;
    cin >> n >> b;

    int sum = 0;
    int length = n.length();

    // 문자열을 뒤에서부터 순회하여 각 자릿수를 10진수로 변환하여 합산
    for (int i = length - 1; i >= 0; i--) {
        int digit;
        if (isdigit(n[i])) {
            digit = n[i] - '0';
        } else {
            digit = n[i] - 'A' + 10;
        }
        sum += digit * power(b, length - 1 - i); // 현재 자릿수에 해당하는 진수의 거듭제곱을 곱하여 더함
    }

    cout << sum;
    return 0;
}
