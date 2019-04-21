#include "BaseCObject.hpp"
#include "CVector2D.hpp"
#include "IDialogInitable.hpp"
#include "IGeoFig.hpp"
#include "IPhysObject.hpp"
#include "IPrintable.hpp"

#ifndef TRAPEZE
#define TRAPEZE

class Trapeze : BaseCObject, IDialogInitiable, IGeoFig, IPhysObject, IPrintable
{
  private:
    /* data */
  public:
    CVector2D lu_corner, ru_corner, ld_corner, rd_corner;
    double height, top_line, bottom_line, mas;

    Trapeze();
    Trapeze(CVector2D &lu_corner, CVector2D &ru_corner, CVector2D &ld_corner, CVector2D &rd_corner);
    ~Trapeze();

    const char *classname();
    unsigned int size();
    void initFromDialog();
    double square();
    double perimeter();
    double mass();
    CVector2D position();
    bool operator==(IPhysObject &ob);
    bool operator<(IPhysObject &ob);
    void draw();
};
#endif