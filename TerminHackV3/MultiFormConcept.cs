using System;
using System.Threading;
using System.Windows.Forms;

namespace TerminHackV3
{
    public class MultiFormContext : ApplicationContext
    {
        private int openForms;
        public MultiFormContext(params Form[] forms)
        {
            openForms = forms.Length;

            foreach (var form in forms)
            {
                form.FormClosed += (s, args) =>
                {
                    //When we have closed the last of the "starting" forms, 
                    //end the program.
                    if (Interlocked.Decrement(ref openForms) == 0)
                    {
                        Environment.Exit(0);
                    }

                };
                form.Show();
            }
        }
    }
}
