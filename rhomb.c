#include "rhomb.h"

int init(struct rhomb *rh){
    rh->aLength = sqrt(pow(rh->b.x - rh->a.x, 2) + pow(rh->b.y - rh->a.y, 2));
    rh->bLength = sqrt(pow(rh->c.x - rh->b.x, 2) + pow(rh->b.y - rh->c.y, 2));
    rh->cLength = sqrt(pow(rh->c.x - rh->d.x, 2) + pow(rh->c.y - rh->d.y, 2));
    rh->dLength = sqrt(pow(rh->d.x - rh->a.x, 2) + pow(rh->a.y - rh->d.y, 2));
    rh->acDiag  = sqrt(pow(rh->c.x - rh->a.x, 2) + pow(rh->c.y - rh->a.y, 2));
    rh->bdDiag  = sqrt(pow(rh->b.y - rh->d.y, 2) + pow(rh->d.x - rh->b.x, 2));
    return 0;
}

double Square(struct rhomb rh)
{
    return (rh.acDiag * rh.bdDiag) / 2;
}

double Perimetr(struct rhomb rh)
{
    return rh.aLength + rh.bLength + rh.cLength + rh.dLength;
}
