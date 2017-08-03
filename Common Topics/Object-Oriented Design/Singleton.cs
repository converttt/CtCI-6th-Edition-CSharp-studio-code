using System;

namespace Common_Topics
{
    /*
        Thread-safe Singleton pattern
     */
    public sealed class OOD_Singleton
    {
        private static volatile OOD_Singleton instance;
        private static readonly Object padlock = new Object();

        private OOD_Singleton() {}

        public OOD_Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock(padlock)
                    {
                        if (instance == null)
                        {
                            instance = new OOD_Singleton();
                        }
                    }
                }

                return instance;
            }
        }
    }
}