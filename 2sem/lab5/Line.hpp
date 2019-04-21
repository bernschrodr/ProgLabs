#include "BaseCObject.hpp"
#include "CVector2D.hpp"
#include "IDialogInitable.hpp"
#include "IGeoFig.hpp"
#include "IPhysObject.hpp"
#include "IPrintable.hpp"

using namespace std;

#ifndef LINE
#define LINE

class Line : BaseCObject, IDialogInitiable, IGeoFig, IPhysObject, IPrintable
{
  private:
    /* data */
  public:
    CVector2D *start;
    CVector2D *end;
    double mas;

    Line();
    Line(CVector2D &A, CVector2D &B);
    ~Line();

    const char* classname();
    unsigned int size();
    void initFromDialog();
    double square();
    double perimeter();
    double mass();
    CVector2D position();
    bool operator==(IPhysObject& ob );
    bool operator<(IPhysObject& ob );
    void draw();
};
#endif