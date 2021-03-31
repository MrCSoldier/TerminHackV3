using System;
using System.Collections.Generic;
using System.Text;

namespace TerminHackV3.HardwareHandlers
{
    class CPUsage : Hardware.IHardwareHandler
    {
        public float CPUusage(float slowdownProcessingSpeed) {
            return slowdownProcessingSpeed;
        }

        public float DelayCommand(float slowdownProcessingSpeed) {
            return slowdownProcessingSpeed;
        }
        /*if (CPusage >=  100) {
            
        }*/
    }
}
