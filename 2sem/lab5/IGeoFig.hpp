#ifndef I_GEO_FIG
#define I_GEO_FIG

class IGeoFig {
public:
// Площадь.
    virtual double square() = 0;
// Периметр.
    virtual double perimeter() = 0;
};

#endif
