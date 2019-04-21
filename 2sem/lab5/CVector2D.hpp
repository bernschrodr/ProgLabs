#ifndef C_VECTOR_2D
#define C_VECTOR_2D

class CVector2D {
public:
    double x, y;

    CVector2D(double x, double y) : x(x), y(y) {}
    CVector2D(const CVector2D &second){
        this-> x = second.x;
        this->y = second.y;
    }
    CVector2D(){
        x = 0;
        y = 0;
    }

    bool operator == ( CVector2D &ob){
        if(this->x == ob.x && this->y == ob.y)
            return true;
        else
            return false;
    }

    

};

#endif
