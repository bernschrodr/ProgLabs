
struct comp {
        float z, zi;

        comp(float z, float zi) : z(z), zi(zi)
        {}

        const comp operator  + (comp first)
        {
            return comp(this->z += first.z, this->zi += first.zi);
        }

        comp operator * (float num)
        {
            return comp(this->z *= num, this->zi *= num);
        }

        friend comp operator * ( comp &first,  comp &second){
            float z = second.z * second.zi - first.z * first.zi;
            float zi = second.z * first.zi + second.zi * first.z;
            return comp(z, zi);
        }

        operator double () const{
            std::string str1 = " ";
            str1 = std::to_string(this->z);

            std::string str2 = " ";
            str2 = std::to_string(this->zi);

            int nulpos1 = 0;
            int nulpos2 = 0;
            bool dot1 = false,dot2 = false;
            for(int i = str1.length()-1; i > 0, --i;){
                if(str1[i] == '.')
                    dot1 = true;
                if(str1[i]== '0' & str1[i-1] == '0')
                {
                    nulpos1 = i;
                }
            }

            for(int i = str2.length()-1; i > 0, --i;){
                if(str2[i] == '.')
                    dot2 = true;
                if(str2[i] == '0' & str2[i-1] == '0')
                {
                    nulpos2 = i;
                }
            }

            int leng = 0;
            str1[0] == '-' ? leng += str1.length()-1 : leng += str1.length();
            str2[0] == '-' ? leng += str2.length()-1 : leng += str2.length();
            
            if(dot1)
                leng--;
            if(dot2)
                leng--;
            
            if(nulpos1>0 & nulpos2>0)
                leng -= str1.length() - nulpos1+1 + str2.length() - nulpos2+1;
            else
                if(nulpos1>0)
                   leng -= str1.length() - nulpos1+1;
                else
                    if(nulpos2>0)
                        leng -= str2.length() - nulpos2+1;

            

            return int(leng);
        }


    };