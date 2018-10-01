#include <stdio.h>

int main() {
    int arr[9] = {99, 88, 77, 66, 55, 44, 33, 22, 11};
    int matrx[2][2] = {2, 5, 2, 2};
    int matrx2[2][2] = {1, 2, 0, 1};
    int matrx_res[2][2];

    for (int i = 0; i < 9; i++) {
        printf("%d ", arr[i]);
    }

    for (int i = 0; i < 2; i++) {
        for (int j = 0; i < 2; i++){

            matrx_res[i][j] += matrx[j][i] * matrx2[i][j];
        }
    }
    return 0;
}
