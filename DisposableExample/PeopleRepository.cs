using System;
using System.IO;
using System.Runtime.InteropServices.ComTypes;

namespace DisposableExample
{
    public class PeopleRepository : IDisposable
    {
        private readonly MyContext _context;
        private readonly TextWriter _stream;
        private bool _isDisposed;

        public PeopleRepository(MyContext context, TextWriter stream)
        {
            _context = context;
            _stream = stream;
        }

        public Person Get(int id)
        {
            CheckIfDisposed();
            var result = _context.People.Find(id);
            _stream.WriteLine($"Getting Person: {id}");
            return result;
        }
        public void Create(Person person)
        {
            CheckIfDisposed();
            _context.People.Add(person);
            _context.SaveChanges();
            _stream.WriteLine($"Creating Person: {person}");
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                _context?.Dispose();
                _stream.WriteLine("Disposing");
                _stream?.Dispose();
                _isDisposed = true;
            }
        }

        protected void CheckIfDisposed()
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException("Object cannot be used. It has beeen already disposed");
            }
        }
    }
}
