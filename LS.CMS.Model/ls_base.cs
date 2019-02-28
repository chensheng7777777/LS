using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LS.CMS.Model
{
    [Serializable]
    public class ls_base
    {
        public virtual int id { get; set; }

        public  static bool operator==(ls_base entity1,ls_base entity2)
        {
            if (entity1==null && entity2==null)
            {
                return true;
            }
            if (entity1==null || entity2==null)
            {
                return false;
            }
            return entity1.id == entity2.id;
        }

        public  static bool operator !=(ls_base entity1, ls_base entity2)
        {
            return !(entity1==entity2);
        }

        public override int GetHashCode()
        {
            if (this==null)
            {
                return default(int);
            }
            return this.id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this == (obj as ls_base);
        }


    }
}
