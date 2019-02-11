#ifndef PROC_HEAD
#define PROC_HEAD

struct comp{
        int z;
        int zi;
    };
    
void suml (int &a, int b);
void sump (int *a, int b);
void negl(int &a);
void negp(int *a);
void multiplyMatrixl(int a[3][3], int b);
void multiplyMatrixp(int **a, int b);
void complexl(struct comp &a);
void complexp(struct comp *a);


#endif