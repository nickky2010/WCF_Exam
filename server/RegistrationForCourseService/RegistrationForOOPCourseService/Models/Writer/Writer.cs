using RegistrationForOOPCourseService.Interfaces.Writer;

namespace RegistrationForOOPCourseService.Models.Writer
{
    public class Writer : IWriter
    {
        private IWriterTextFile _writerTextFile;

        public IWriterTextFile WriterTextFile
        {
            get
            {
                if (_writerTextFile == null)
                {
                    _writerTextFile = new WriterTextFile();
                }
                return _writerTextFile;
            }
        }
    }
}
