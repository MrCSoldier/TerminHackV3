using System;
using System.Collections.Generic;
using System.Text;

namespace TerminHackV3.Hardware
{
    public interface IHardwareHandler
    {
        public float CPUusage(float slowdownProcessingSpeed);
        public float DelayCommand(float slowdownProcessingSpeed);
    }
}