using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAL.EFLib
{
    // Singleton Pattern
    public class SALContext
    {
        #region Property 

        private readonly SALEntities _context;
        public SALEntities Context
        {
            get
            {
                return _context;
            }
        }

        private static SALContext _instance;
        public static SALContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SALContext();
                }

                return _instance;
            }
        }

        #endregion

        #region private Costructor

        private SALContext()
        {
            _context = new SALEntities();
        }

        #endregion
    }
    // end
}
