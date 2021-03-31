using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using TerminHackV3.CommandHandlers;


namespace TerminHackV3
{
    public class HardwareHandler
    {
        public static float slowdownCPU;
        public static float slowdownRAM;
        public static float slowdownDisk;
        public static float slowdownProcessingSpeed;



        public float DelayCommand(float slowdownProcessingSpeed) 
        {
            return slowdownProcessingSpeed;
        }

                /*public void CPUsage(float CPUsage)
        {
            if (CPUsage > 100)
            {
                slowdownProcessingSpeed = slowdownProcessingSpeed + ((CPUsage / ThreadCount) * harwareScore);
                Console.WriteLine(slowdownProcessingSpeed);
            }

        public void RAMUsage(float RAMUsage)
        {
            if (RAMUsage > 100) {
                slowdownProcessingSpeed = slowdownProcessingSpeed + ((RAMUsage / memoryCapacity) * harwareScore)
            }
            await Task.Run(delayCommand(slowdownProcessingSpeed));
        }

        public async void delayCommand(float slowdownProcessingSpeed)
        {
            Task.Delay(slowdownProcessingSpeed);
        }

*/














        /* For Laer development (For iniial release)
        
        public void DiskUsage(float DiskUsage) 
        {
            if (RAMUsage > 100)
            {
                slowdownProcessingSpeed = slowdownProcessingSpeed + ((DiskUsage / ) * harwareScore)
            }
        }

        */

        

    }
}
