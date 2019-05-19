using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IonosphereCorrection
{
    class CorrctionManger
    {
      private  List<OPoint> lisopoint;
      public  CePoint cpoint;
      public List<OPoint> lisOpoint
        {
            get
            {
                return lisopoint;
            }
            set
            {
                if(cpoint != null)
                {
                    foreach (var t in value )
                    {
                        t.InitP(cpoint);//初始化数据
                    }
                    lisopoint = value;
                }
            }
        }
    }
}
