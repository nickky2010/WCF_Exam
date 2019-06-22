using RegistrationForOOPCourseService.Interfaces.Reader;

namespace RegistrationForOOPCourseService.Models.Reader
{
    public class Reader : IReader
    {
        private IReaderTextFile _readerTextFile;

        public IReaderTextFile ReaderTextFile
        {
            get
            {
                if (_readerTextFile == null)
                {
                    _readerTextFile = new ReaderTextFile();
                }
                return _readerTextFile;
            }
        }
    }
}
