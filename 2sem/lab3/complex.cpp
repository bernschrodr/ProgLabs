#include "complex.hpp"
#include <cmath>
#include <iostream>
#include <string>

//COMPLEX NUM
comp::comp() : z(2), zi(3){};

comp::comp(float z, float zi) : z(z), zi(zi){};

comp::comp(const comp &first)
{
    this->z = first.z;
    this->zi = first.zi;
}

void comp::sum(comp first)
{
    this->z += first.z;
    this->zi += first.zi;
}

void comp::multiply(float num)
{
    this->z *= num;
    this->zi *= num;
}

void comp::multiply(comp &second)
{
    this->z = second.z * second.zi - this->z * this->zi;
    this->zi = second.z * this->zi + second.zi * this->z;
}

const float comp::abs()
{
    return (sqrt(pow(this->z, 2) + pow(this->zi, 2)));
}

const void comp::prnt()
{
    std::cout << this->z;
    if (this->zi >= 0)
        std::cout << "+";
    std::cout << this->zi << "i" << std::endl;
    ;
}
