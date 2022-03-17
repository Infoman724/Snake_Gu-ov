using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Snake_Gužov
{
    class Params
    {
        private string resourcesFoler;

        public Params()
        {
            var ind = Directory.GetCurrentDirectory().ToString()                
                  .IndexOf("bin", StringComparison.Ordinal); // Nony4uTb NHAEKC nanKn bin
            string binFolder =
               Directory.GetCurrentDirectory().ToString().Substring(0, ind)
                    .ToString(); // путь до указанной в инкесе папки
            resourcesFoler = binFolder + "resources\\";
        }
        public string GetResourceFolder()
        {
            return resourcesFoler;
        }    
    }
}
