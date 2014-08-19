using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appacitive.Sdk;
using Environment = Appacitive.Sdk.Environment;

namespace AppacitiveRepository
{
    public static class Repository
    {
        public static void InIt()
        {
            AppContext.Initialize("65545550151418706", "D71TN42oY7sBPQfA6jxTFHPJsxyX5OGls5araXa55Ug=",Environment.Sandbox);
            
            //for debugging, if on you may have to compromise performance 
            AppContext.Debug.ApiLogging.LogEverything();
        }
    }
}
