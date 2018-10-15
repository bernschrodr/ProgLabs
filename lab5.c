#include <stdio.h>
#include <stdlib.h>

int main() {
    int arr[9] = {99, 88, 77, 66, 55, 44, 33, 22, 11};
    int matrx[2][2] = {2, 5, 2, 2};
    int matrx2[2][2] = {1, 2, 0, 1};
    int matrx_res[2][2] = {0,0,0,0};

    for (int i = 0; i < 9; i++) {
        printf("%d ", arr[i]);
    }
    
    printf("\n");

	for (int i = 0; i < 2; i++) {
		for (int j = 0; j < 2; j++)
		{
			matrx_res[i][j] = 0;
			for (int k = 0; k < 2; k++)
				matrx_res[i][j] += matrx[i][k] * matrx2[k][j];
		}
	}

    for (int i = 0; i < 2; i++) {
        printf("%d ", matrx_res[0][i]);
    }
    printf("\n");

    for (int i = 0; i < 2; i++) {
        printf("%d ", matrx_res[i][0]);
    }

    return 0;
}
