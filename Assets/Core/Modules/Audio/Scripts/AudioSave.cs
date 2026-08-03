using System;

namespace Core
{
    public class AudioSave : ISavable
    {
        public VolumeData[] volumeDatas;

        public void Flush()
        {
            // TODO
            throw new NotImplementedException();
        }

        [Serializable]
        public class VolumeData
        {
            public AudioType AudioType;
            public float Volume;
        }
    }
}